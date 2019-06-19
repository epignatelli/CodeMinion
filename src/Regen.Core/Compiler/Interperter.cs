﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Flee.PublicTypes;
using Regen.Builtins;
using Regen.Collections;
using Regen.DataTypes;
using Regen.Exceptions;
using Regen.Helpers;
using Array = Regen.DataTypes.Array;
using ExpressionCompileException = Regen.Exceptions.ExpressionCompileException;

namespace Regen.Compiler {
    /// <summary>
    ///     The interpreter parses, compiles and then converts given code and returns it as a string.
    /// </summary>
    public class Interperter {
        public Dictionary<string, Data> GlobalVariables { get; }
        public InterpreterOptions Options { get; set; } = new InterpreterOptions();

        public Interperter(string entireCode, string regenCode) {
            EntireCode = entireCode + Environment.NewLine;
            RegenCode = regenCode + Environment.NewLine;
            ReversedRegenCode = new string(regenCode.Reverse().ToArray());

            Context = new ExpressionContext();
            // Allow the expression to use all static public methods of System.Math
            Context.Imports.AddType(typeof(Math));
            Context.Imports.AddType(typeof(CommonExpressionFunctions));

            GlobalVariables = new Dictionary<string, Data>();
            string scriptFramed = Parser.GlobalFrameRegex;
            foreach (Match match in Regex.Matches(entireCode, scriptFramed, Regexes.DefaultRegexOptions)) {
                if (!match.Success) //I dont think that unsuccessful can even get here.
                    continue;

                var variables = RunGlobal(match.Groups[1].Value);
                GlobalVariables.AddRange(variables);
            }
        }

        public string EntireCode { get; }
        public string RegenCode { get; set; }
        private string ReversedRegenCode { get; set; }
        public ExpressionContext Context { get; set; }

        public class ForLoop {
            public int From { get; set; }
            public int To { get; set; }
            public int Index { get; set; }

            public bool CanNext() => Index < To;

            public int Next() {
                if (CanNext()) {
                    var currently = Index;
                    Index++;
                    return currently;
                }

                return 0;
            }
        }

        public string ExpandVariables(Line line, int stackIndex, Dictionary<int, StackDictionary> stacks) {
            var code = line.Content;
            var basicEmits = Lexer.FindTokens(TokenID.EmitVariable, code);
            var currentStack = stacks[stackIndex];

            //get tokens with expression in them.
            var offsetEmit = Lexer.FindTokens(TokenID.EmitVariableOffsetted, code);
            var expressionEmits = Lexer.FindTokens(TokenID.EmitExpression, code);
            int additionalIndex = 0;
            foreach (var emits in basicEmits.GroupBy(e => Convert.ToInt32(e.Match.Groups[1].Value))) {
                var index = emits.Key;

                foreach (var emit in emits.OrderBy(e => e.Match.Index)) {
                    if (!currentStack.ContainsKey(index))
                        throw new IndexOutOfRangeException($"Index #{index} at line {line.LineNumber} not found during emit at block: {code}");
                    var isnested = offsetEmit.Any(m => m.Match.IsMatchNestedTo(emit.Match)) || expressionEmits.Any(m => m.Match.IsMatchNestedTo(emit.Match));
                    code = code.Remove(emit.Match.Index + additionalIndex, emit.Match.Length);
                    var emit_text = isnested ? currentStack[index].EmitExpressive() : currentStack[index].Emit();
                    code = code.Insert(emit.Match.Index + additionalIndex, emit_text);
                    additionalIndex += emit_text.Length - emit.Match.Length;
                }
            }

            offsetEmit = Lexer.FindTokens(TokenID.EmitVariableOffsetted, code); //re-lex because of expressions that might have been expanded inside.
            additionalIndex = 0; //because we re-lexxed
            foreach (var emits in offsetEmit.GroupBy(e => Convert.ToInt32(e.Match.Groups[1].Value))) {
                var index = emits.Key;

                foreach (var emit in emits.OrderBy(e => e.Match.Index)) {
                    if (!currentStack.ContainsKey(index))
                        throw new IndexOutOfRangeException($"Index #{index} at line {line.LineNumber} not found during emit at block: {code}");

                    var expression = emit.Match.Groups[2].Value;
                    var accessorStackIndex = EvaluateInt32(expression, line) + 1; //during expressions for loop index is 0 based, but stack is 1.
                    string emit_text;
                    try {
                        emit_text = stacks[accessorStackIndex][index].Emit();
                    } catch (KeyNotFoundException) {
                        code = code.Remove(emit.Match.Index + additionalIndex, emit.Match.Length);
                        additionalIndex -= emit.Match.Length;

                        continue; //no emits now.
                    }

                    code = code.Remove(emit.Match.Index + additionalIndex, emit.Match.Length);
                    code = code.Insert(emit.Match.Index + additionalIndex, emit_text);
                    additionalIndex += emit_text.Length - emit.Match.Length;
                }
            }

            //by now everything should be expanded, so we just evaluate and replace.
            expressionEmits = Lexer.FindTokens(TokenID.EmitExpression, code);
            additionalIndex = 0;
            foreach (var expressionMatch in expressionEmits) {
                var expression = expressionMatch.Match.Groups[1].Value;
                string emit = EvaluateString(expression, line);

                code = code.Remove(expressionMatch.Match.Index + additionalIndex, expressionMatch.Match.Length);
                code = code.Insert(expressionMatch.Match.Index + additionalIndex, emit);
                additionalIndex += emit.Length - expressionMatch.Match.Length;
            }

            return code;
        }

        public string EvaluateString(string expression, Line line = null) {
            return Evaluate<string>(expression, line);
        }

        public Int32 EvaluateInt32(string expression, Line line = null) {
            return Evaluate<Int32>(expression, line);
        }

        public T Evaluate<T>(string expression, Line line = null) {
            var evaluated = EvaluateUnpackedObject(expression, line);
            if (typeof(T) == typeof(string))
                return (T) (object) ((evaluated as string) ?? evaluated.ToString());

            return (T) Convert.ChangeType(evaluated, typeof(T));
        }

        public object EvaluateUnpackedObject(string expression, Line line = null) {
            var evaluated = EvaluateObject(expression, line);
            if (evaluated is Data scalar)
                return scalar.Value;
            return evaluated;
        }

        public object EvaluateObject(string expression, Line line = null) {
            bool reattempted = false;
            _attemptReevaluate:
            try {
                return Context.CompileDynamic(expression).Evaluate();
            } catch (Flee.PublicTypes.ExpressionCompileException e) when (e.Message.Contains("ArithmeticElement") && e.Message.Contains("Null") && e.Message.Contains("Operation")) {
                if (reattempted)
                    throw;
                expression = expression.Replace("null", "0");
                reattempted = true;
                goto _attemptReevaluate;
            } catch (Flee.PublicTypes.ExpressionCompileException e) {
                throw new ExpressionCompileException($"Was unable to evaluate expression: {expression}\t  At line ({line?.LineNumber}): {line?.Content}", e);
            }
        }

        public Dictionary<string, Data> RunGlobal(string code, Dictionary<string, Data> variables = null) {
            return Interpret(code, variables).Variables;
        }

        public InterpredCode Interpret(Dictionary<string, Data> variables = null) {
            return Interpret(RegenCode, variables);
        }

        public InterpredCode Interpret(string code, Dictionary<string, Data> variables = null) {
            const string unescapeCommentRegex = @"(\\\#\/\/)";
            //clean code from comments
            code = Regex.Replace(code, TokenID.Commentrow.GetAttribute<DescriptionAttribute>().Description, new MatchEvaluator(match => { return match.Value.Replace(match.Groups[1].Value, ""); }), Regexes.DefaultRegexOptions);
            code = Regex.Replace(code, unescapeCommentRegex, @"//", Regexes.DefaultRegexOptions); //unescape escaped comments

            var lines = new LineBuilder(code);
            var output = lines.Clone();
            variables = variables != null ? new Dictionary<string, Data>(variables) : new Dictionary<string, Data>(); //all objects implement IData
            variables.AddRange(GlobalVariables);

            // Define the context of our expression

            var walker = Lexer.Tokenize(code).WrapWalker();
            if (walker.Count == 0) {
                //no tokens detected
                var comp = output.Compile(Options);
                return new InterpredCode() {OriginalCode = code, Output = comp, Variables = variables};
            }

            do {
                var current = walker.Current;
                switch (walker.Current.TokenId) {
                    case TokenID.Declaration: {
                        var name = walker.Current.Match.Groups[1].Value.Trim();
                        var line = output.GetLineAt(walker.Current.Match.Index);
                        line.MarkedForDeletion = true; //just because the line has declaration - regardless to whats inside.
                        if (!walker.Next())
                            throw new UnexpectedTokenException(current, TokenID.Array);

                        //check if name is valid (C# compliant)
                        if (!name.All(c => char.IsDigit(c) || char.IsLetter(c) || Regexes.VariableNameValidSymbols.Any(cc => cc == c)) || name.TakeWhile(char.IsDigit).Any()) {
                            throw new ExpressionCompileException($"Variable named '{name}' contains invalid characters. Name can only start with a letter or underscore and contain letters, numbers or underscores");
                        }

                        //check interpreter buildin keywords
                        var matchedTakenName = InterpreterOptions.BuiltinKeywords.FirstOrDefault(w => w.Equals(name, StringComparison.Ordinal));
                        if (matchedTakenName != null) {
                            throw new ExpressionCompileException($"Variable named '{name}' is taken by the interpreter.");
                        }

                        if (walker.Current.TokenId == TokenID.Array) {
                            var arrayToken = walker.Current;
                            var arrayStr = arrayToken.Match.Groups[0].Value;

                            var values = Array.Parse(arrayStr, this);
                            if (variables.ContainsKey(name))
                                Debug.WriteLine($"Warning: variable named {name} is already taken and is being overridden at TODO PRINT LINE");
                            variables[name] = values;
                            Context.Variables[name] = values;
                        } else if (walker.Current.TokenId == TokenID.Scalar) {
                            //todo detect if there is an expression inside, if so - evaluate it.
                            var scalarToken = walker.Current;
                            var scalarStr = scalarToken.Match.Groups[1].Value.TrimEnd('\n', '\r');

                            object value;
                            if (int.TryParse(scalarStr, out var @long)) {
                                value = @long;
                            } else if (decimal.TryParse(scalarStr, out var @decimal)) {
                                value = @decimal;
                            } else if (float.TryParse(scalarStr, out var @float)) {
                                value = @float;
                            } else {
                                value = EvaluateUnpackedObject(scalarStr);
                            }

                            if (variables.ContainsKey(name))
                                Debug.WriteLine($"Warning: variable named {name} is already taken and is being overridden at TODO PRINT LINE");
                            value = Data.Create(value);
                            variables[name] = (Data) value;
                            Context.Variables[name] = value;
                        }

                        break;
                    }

                    case TokenID.Expression: {
                        var line = output.GetLineAt(walker.Current.Match.Index);
                        GroupCollection groups;
                        bool originalToken = true;
                        if (line.ContentWasModified) {
                            //re-express
                            var tokens = Lexer.FindTokens(TokenID.Expression, line.Content);
                            if (tokens.Count == 0)
                                break;
                            groups = tokens[0].Match.Groups;
                            originalToken = false;
                        } else
                            groups = walker.Current.Match.Groups;

                        var expression = groups[1].Value;


                        var evaluation = EvaluateString(expression);
                        var lineStr = line.Content
                            .Remove(groups[0].Index - (originalToken ? line.StartIndex : 0), groups[0].Length)
                            .Insert(groups[0].Index - (originalToken ? line.StartIndex : 0), evaluation);
                        line.Replace(lineStr);
                        break;
                    }

                    case TokenID.ForEach: {
                        var line = lines.GetLineAt(walker.Current.Match.Index);
                        output.FindLine(line).MarkedForDeletion = true;
                        var content = line.Content.Replace("%foreach", "").Replace("%for", "").TrimStart('\t', ' ').TrimEnd('\n', '\r', ' ');
                        var usesBlock = content.EndsWith("%");
                        content = content.TrimEnd('%');

                        //find all relevant variables
                        var parsedVaraibles = new List<object>();
                        foreach (var name in content.Split('|').Select(n => n.Trim(' ', '\r', '\n').TrimEnd('%'))) {
                            //todo ignore escaped \|,
                            if (variables.ContainsKey(name)) {
                                var var = variables[name];
                                if (var is Array) {
                                    parsedVaraibles.Add(var);
                                    continue;
                                }
                            }

                            var obj = EvaluateUnpackedObject(name, line);
                            if (obj is PackedArguments args) {
                                parsedVaraibles.AddRange(args.Objects);
                            } else
                                parsedVaraibles.Add(obj);
                        }

                        var feInstance = new ForeachInstance(parsedVaraibles, ForeachInstance.StackLength.SmallestIndex);
                        var loop = feInstance.StartLoop();

                        if (!usesBlock) {
                            if (line.LineNumber >= lines.Lines.Count)
                                throw new UnexpectedTokenException("After non-block foreach, theres suppose to be a line that is replicated.");

                            var nextline = lines.Lines[line.LineNumber]; //linenumber is index+1 so we dont need to +1.
                            while (loop.CanNext()) {
                                var currentIndex = loop.Next();
                                Context.Variables["i"] = currentIndex;
                                var expand = ExpandVariables(nextline, currentIndex, feInstance.Stacks);
                                var expandedLine = output.Lines[line.LineNumber]; //no need to do +1, line number is 1 based.

                                expandedLine.ReplaceOrAppend(expand);
                            }

                            Context.Variables.Remove("i");
                        } else {
                            var block = lines.Lines.Skip(line.LineNumber).TakeWhileIncluding(l => l.CleanContent() != "%").ToArray();
                            output.FindLine(block.Last()).MarkedForDeletion = true; //the last marker that will be marked for deletion.

                            block = block.SkipLast(1).ToArray();

                            if (block.Length > 1)
                                foreach (var todeleteLine in block.Skip(1)) {
                                    output.Lines.Single(l => l == todeleteLine).MarkedForDeletion = true;
                                }

                            var appender = output.Lines.Single(l => l == block[0]); //the line we append to

                            while (loop.CanNext()) {
                                var currentIndex = loop.Next();
                                Context.Variables["i"] = currentIndex;
                                foreach (var lineInBlock in block) {
                                    var expanded = ExpandVariables(lineInBlock, currentIndex, feInstance.Stacks);
                                    appender.ReplaceOrAppend(expanded);
                                }
                            }

                            Context.Variables.Remove("i");
                        }

                        break;
                    }

                    case TokenID.Scalar:
                    case TokenID.Array:
                    case TokenID.EmitVariable:
                    case TokenID.EmitVariableOffsetted:
                    case TokenID.BlockMark:
                        //there are tokens that are handles internally by the tokens implemented above.
                        //if they are not inside, they are to be skipped
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } while (walker.Next());

            var compiled = output.Compile(Options);
            return new InterpredCode() {OriginalCode = code, Output = compiled, Variables = variables};
        }
    }
}