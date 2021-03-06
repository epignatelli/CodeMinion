﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text.RegularExpressions;
using Regen.Compiler;
using Regen.Compiler.Helpers;
using Regen.DataTypes;
using Regen.Helpers;
using Regen.Parser;
using Regen.Parser.Expressions;

namespace Regen.Engine {
    /// <summary>
    ///     A file tempate engine that handles _REGEN_TEMPLATE
    /// </summary>
    public static class RegenFileTemplateEngine {
        private static RegenCompiler _prepareCompiler() {
            var compiler = new RegenCompiler();

            //compile all globals
            foreach (var glob in RegenEngine.Globals)
                compiler.CompileGlobal(glob);

            return compiler;
        }

        public static List<(string Path, string Content)> Compile(string code, string templatePath = null) {
            templatePath = string.IsNullOrEmpty(templatePath) ? null : Path.GetFullPath(templatePath);
            var compiler = _prepareCompiler();

            //handle the _REGEN_TEMPLATE as a global
            var template = CodeFrame.Create(code, "_REGEN_TEMPLATE").Single();
            compiler.CompileGlobal(ExpressionParser.Parse(template.Input));

            //we iterate the parser tokens and take action accordingly.
            var parsedCode = ExpressionParser.Parse(template.Input);
            var returnList = new List<(string Path, string Content)>();
            foreach (var act in parsedCode.ParseActions) {
                switch (act.Token) {
                    case ParserToken.Template:
                        returnList.AddRange(CompileFile(compiler, (TemplateExpression) act.Related[0], code, templatePath));
                        break;
                    case ParserToken.Declaration:
                    case ParserToken.Import:
                        compiler.CompileAction(act, parsedCode.ParseActions);
                        break;
                    case ParserToken.ForeachLoop:
                    case ParserToken.Expression:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            //return frame;
            return returnList;
        }

        private static (string Path, string Content)[] CompileFile(RegenCompiler compiler, TemplateExpression expr, string code, string templatePath) {
            var filePath = expr.Path;
            var Context = compiler.Context;
            var content = code;


            var iterateThese = expr.Arguments.Arguments.Select(parseExpr).ToList();
            unpackPackedArguments();

            //get smallest index and iterate it.
            var min = iterateThese.Min(i => i.Count);
            var vars = Context.Variables;
            var ret = new List<(string Path, string Content)>();

            for (int i = 0; i < min; i++) {
                //set variables
                vars["i"] = i;
                for (int j = 0; j < iterateThese.Count; j++) {
                    vars[$"__{j + 1}__"] = iterateThese[j][i];
                }

                //now here we iterate contents and set all variables in it.
                //iterate lines, one at a time 
                var resultContent = content.ToString();
                var resultPath = filePath.ToString();

                //replace all emit commands
                resultContent = ExpressionLexer.ReplaceRegex(resultContent, @"__(\d+)__", match => {
                    var key = $"__{match.Groups[1].Value}__";

                    return _emit(vars[key]);
                });

                //replace any #n in the path string
                resultPath = ExpressionLexer.ReplaceRegex(resultPath, @"(?<!\\)\#([0-9]+)", match => {
                    var key = $"__{match.Groups[1].Value}__";
                    return _emit(vars[key]);
                });

                //unescape any \#1
                resultPath = ExpressionLexer.ReplaceRegex(resultPath, @"\\\#([0-9]+)", match => $"#{match.Groups[1].Value}");

                //clear _REGEN_TEMPLATE
                resultContent = ExpressionLexer.ReplaceRegex(resultContent, Regexes.TemplateFrameRegex, $"//Generated by Regex Templating Engine at {DateTime.UtcNow} UTC{Environment.NewLine}//template source: {templatePath}{Environment.NewLine}{Environment.NewLine}");
                if (templatePath != null && resultPath.StartsWith(".")) resultPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(templatePath), resultPath));
                ret.Add((resultPath, resultContent));
            }

            Context.Variables.Remove("i");
            for (var i = 1; i <= iterateThese.Count; i++) {
                Context.Variables.Remove($"__{i}__");
            }

            return ret.ToArray();

            IList parseExpr(Expression arg) {
                var ev = compiler.EvaluateObject(arg);
                if (ev is ReferenceData d) {
                    ev = d.UnpackReference(Context);
                }

                if (ev is StringScalar ss) {
                    return ss.ToCharArray();
                }

                if (ev is NetObject no) {
                    ev = no.Value;
                }

                return (IList) ev;
            }

            void unpackPackedArguments() {
                //unpack PackedArguments
                for (var i = iterateThese.Count - 1; i >= 0; i--) {
                    if (iterateThese[i] is PackedArguments pa) {
                        iterateThese.InsertRange(i, pa.Objects.Select(o => (IList) o));
                    }
                }

                iterateThese.RemoveAll(it => it is PackedArguments);
            }

            string _emit(object val) => val is Data d ? d.Emit() : val.ToString();
        }
    }
}