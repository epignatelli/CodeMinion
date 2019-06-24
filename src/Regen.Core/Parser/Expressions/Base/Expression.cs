﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Regen.Exceptions;
using Regen.Helpers;

namespace Regen.Parser.Expressions {
    public class Expression {
        protected static RegexResult _matchWhitespace = " ".AsResult();

        /// <summary>
        ///     An empty match, prefered alternative to null.
        /// </summary>
        public static EmptyExpression None { get; } = new EmptyExpression();

        /// <summary>
        ///     All matches that were used to assemble this expression, in order.
        /// </summary>
        [DebuggerHidden]
        public virtual IEnumerable<RegexResult> Matches() {
            yield break;
        }

        /// <summary>
        ///     Iterates all expressions in their evaluation order. (left to right).
        /// </summary>
        [DebuggerHidden]
        public virtual IEnumerable<Expression> Iterate() {
            yield return this;
        }

        [DebuggerNonUserCode]
        public override string ToString() {
            return $"{GetType().Name}: {AsString()}";
        }

        /// <summary>
        ///     Combines all <see cref="Match"/> that are in this <see cref="Expression"/> into an ordered string that resembles the real input.
        /// </summary>
        [DebuggerHidden]
        public virtual string AsString() {
            var matches = Matches().ToArray();
            if (matches.Length == 0)
                return "";

            return matches.Select(m => m.Value).StringJoin();
        }

        public static explicit operator Expression(string expr) {
            return ParseExpression(new ExpressionWalker(ExpressionLexer.Tokenize(expr)));
        }

        internal static (Expression Expression, ExpressionWalker ExpressionWalker) GetExpressionWithWalker(string expr) {
            var walker = new ExpressionWalker(ExpressionLexer.Tokenize(expr));
            var pexpr = ParseExpression(walker);
            walker.Reset();
            return (pexpr, walker);
        }

        #region Expression Parsing

        public static Expression ParseExpression(ExpressionWalker ew, Type caller = null) {
            Expression ret = null;
            var current = ew.Current.Token;
            if (current == ExpressionToken.Literal) {
                //cases like variable(.., variable[.., variable + .., variable
                if (ew.HasNext) {
                    var peak = ew.PeakNextOrThrow().Token;
                    if (peak == ExpressionToken.LeftParen) {
                        ret = CallExpression.Parse(ew);
                    } else if (peak == ExpressionToken.Period && caller != typeof(IdentityExpression) && caller != typeof(InteractableExpression)) {
                        ret = IdentityExpression.Parse(ew);
                    } else if (peak == ExpressionToken.LeftBracet) {
                        ret = IndexerCallExpression.Parse(ew);
                    } else if (peak == ExpressionToken.New) {
                        ret = NewExpression.Parse(ew);
                    } else if (RightOperatorExpression.IsNextAnRightUniOperation(ew, caller) && caller != typeof(RightOperatorExpression)) {
                        ret = RightOperatorExpression.Parse(ew);
                    } else if (OperatorExpression.IsNextAnOperation(ew)
                               && caller != typeof(OperatorExpression)
                               && caller != typeof(RightOperatorExpression)
                               && caller != typeof(ForeachExpression)) {
                        ret = OperatorExpression.Parse(ew);
                    } else {
                        ret = IdentityExpression.Parse(ew, caller);
                    }
                } else {
                    ret = IdentityExpression.Parse(ew, caller);
                }
            } else if (LeftOperatorExpression.IsCurrentAnLeftUniOperation(ew)) {
                ret = LeftOperatorExpression.Parse(ew);
            } else if (current == ExpressionToken.NumberLiteral) {
                ret = NumberLiteral.Parse(ew);
            } else if (current == ExpressionToken.StringLiteral) {
                ret = StringLiteral.Parse(ew);
            } else if (current == ExpressionToken.LeftParen) {
                ret = GroupExpression.Parse(ew, ExpressionToken.LeftParen, ExpressionToken.RightParen);
            } else if (current == ExpressionToken.LeftBracet) {
                ret = ArrayExpression.Parse(ew);
            } else if (current == ExpressionToken.New) {
                ret = NewExpression.Parse(ew);
            } else if (current == ExpressionToken.Boolean) {
                ret = BooleanLiteral.Parse(ew);
            } else if (current == ExpressionToken.CharLiteral) {
                ret = CharLiteral.Parse(ew);
            } else if (current == ExpressionToken.Throw) {
                ret = ThrowExpression.Parse(ew);
            } else if (current == ExpressionToken.Hashtag && ew.HasNext && ew.PeakNext.Token == ExpressionToken.NumberLiteral) {
                ret = HashtagReferenceExpression.Parse(ew, caller);
            } else if (current == ExpressionToken.Null) {
                ret = NullIdentity.Parse(ew);
            } else {
                throw new UnexpectedTokenException($"Token was expected to be an expression but got {ew.Current.Token}");
            }

            //here we parse chained math operations
            while (OperatorExpression.IsCurrentAnOperation(ew)) {
                if (RightOperatorExpression.IsCurrentAnRightUniOperation(ew) && caller != typeof(OperatorExpression)) {
                    ret = RightOperatorExpression.Parse(ew, ret);
                } else if (OperatorExpression.IsCurrentAnOperation(ew)) {
                    ret = OperatorExpression.Parse(ew, ret);
                }
            }

            return ret;
        }

        #endregion
    }

    public class EmptyExpression : Expression { }
}