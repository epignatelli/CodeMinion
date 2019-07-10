﻿namespace Regen.Parser {
    public enum ExpressionToken {
        None = 0,
        [ExpressionToken(@"\//", -1, "//")] [Swallows(Div)] CommentRow, //swallow will 
        [ExpressionToken(@"(?<=^|\s|[^\w\d])import(?=(\s|$))", 0, "import")] [Swallows(StringLiteral)] Import,
        [ExpressionToken(@"(?<=^|\s|[^\w\d])as(?=(\s|$))", 1, "as")] [Swallows(StringLiteral)] As,
        [ExpressionToken(@"(?<=^|\s|[^\w\d])function(?=(\s|$|\(|\[|\{))", 5, "function")] [Swallows(StringLiteral)] Function,
        [ExpressionToken(@"(?<=^|\s|[^\w\d])new(?=(\s|$|\(|\[|\{))", 8, "new")] [Swallows(StringLiteral)] New,
        [ExpressionToken(@"(?<=^|\s|[^\w\d])throw(?=(\s|$|\(|\[|\{))", 9, "throw")] [Swallows(StringLiteral)] Throw,
        [ExpressionToken(@"(?<=^|\s|[^\w\d])if(?=(\s|$|\(|\[|\{))", 10, "if")] [Swallows(StringLiteral)] If,
        [ExpressionToken(@"(?<=^|\s|[^\w\d])else\s?if(?=(\s|$|\(|\[|\{))", 15, "else if")] [Swallows(StringLiteral)] ElseIf,
        [ExpressionToken(@"(?<=^|\s|[^\w\d])else(?=(\s|$|\(|\[|\{))", 20, "else")] [Swallows(StringLiteral)] Else,
        [ExpressionToken(@"(?<=(?:^|\s|[^\w\d]))(true|false)", 21, "$1")] [Swallows(StringLiteral)] Boolean,
        [ExpressionToken(@"(?<=^|\s|[^\w\d])foreach(?=(\s|$|\(|\[|\{))", 25, "foreach")] [Swallows(StringLiteral)] Foreach,
        [ExpressionToken(@"(?<=^|\s)while(?=(\s|$|\(|\[|\{))", 26, "while")] [Swallows(StringLiteral)] While,
        [ExpressionToken(@"(?<=^|\s)do(?=(\s|$|\(|\[|\{))", 27, "do")] [Swallows(StringLiteral)] Do,
        [ExpressionToken(@"(?<=^|\s)reset(?=(\s|$|\(|\[|\{))", 28, "reset")] [Swallows(StringLiteral)] Reset,
        [ExpressionToken(@"(?<=^|\s)return(?=(\s|$|\(|\[|\{|\;))", 30, "return")] [Swallows(StringLiteral)] Return,
        [ExpressionToken(@"(?<=^|\s)case(?=(\s|$|\(|\[|\{))", 31, "case")] [Swallows(StringLiteral)] Case,
        [ExpressionToken(@"(?<=^|\s)switch(?=(\s|$|\(|\[|\{))", 32, "switch")] [Swallows(StringLiteral)] Switch,
        [ExpressionToken(@"(?<=^|\s)break(?=(\s|$|\(|\[|\{)|\;)", 33, "break")] [Swallows(StringLiteral)] Break,
        [ExpressionToken(@"(?<=^|\s)continue(?=(\s|$|\(|\[|\{)|\;)", 34, "continue")] [Swallows(StringLiteral)] Continue,
        [ExpressionToken(@"(?<=^|\s)default(?=(\s|$|\(|\[|\{)|\;)", 35, "default")] [Swallows(StringLiteral)] Default,
        [ExpressionToken(@"(?<=(?:^|\s|[^\w\d]))null", 36, "null")] [Swallows(StringLiteral)] Null,
        [ExpressionToken(@"(?<=^|\s)var", 39, "var")] [Swallows(StringLiteral)] Declaration,
        [ExpressionToken(@"\'(.|\\.)\'", 40, "'$1'")] [Swallows(StringLiteral, Escape)] CharLiteral,
        [ExpressionToken(@"\""(.*?)\""", 41, "\"$1\"")] [Swallows(NumberLiteral, Comma)] StringLiteral,
        [ExpressionToken(@"([0-9]+(?:\.[0-9]+)?[fFdDmML]?)", 45, "$1")] [Swallows(Literal)] NumberLiteral,
        [ExpressionToken(@"([a-zA-Z_][a-zA-Z0-9_]*)", 50, "$1")] Literal,
        [ExpressionToken(@"[\s\t]+", 60, " ")] Whitespace,
        [ExpressionToken(@"[\r\n]{1,2}", 65, "\n")] [Swallows(UnixNewLine)] NewLine,
        [ExpressionToken(@"\r", 70, "\r")] UnixNewLine,
        [ExpressionToken(@"\%", 75, "%")] Mod,
        [ExpressionToken(@"\+\+", 80, "++")] [Swallows(Add)] Increment,
        [ExpressionToken(@"\-\-", 85, "--")] [Swallows(Sub)] Decrement,
        [ExpressionToken(@"\+", 90, "+")] Add,
        [ExpressionToken(@"\-", 95, "-")] Sub,
        [ExpressionToken(@"\*\*", 100, "**")] [Swallows(Mul)] Pow,
        [ExpressionToken(@"\*", 105, "*")] Mul,
        [ExpressionToken(@"\/", 110, "/")] Div,
        [ExpressionToken(@"\==", 115, "==")] [Swallows(Equal)] DoubleEqual,
        [ExpressionToken(@"\!=", 120, "!=")] [Swallows(Equal)] NotEqual,
        [ExpressionToken(@"\=", 125, "=")] Equal,
        [ExpressionToken(@"\&\&", 130, "&&")] [Swallows(And)] DoubleAnd,
        [ExpressionToken(@"\&", 135, "&")] And,
        [ExpressionToken(@"\|\|", 140, "||")] [Swallows(Or)] DoubleOr,
        [ExpressionToken(@"\|", 145, "|")] Or,
        [ExpressionToken(@"\~", 150, "~")] Not,
        [ExpressionToken(@"\!", 151, "!")] NotBoolean,
        [ExpressionToken(@"\^", 155, "^")] Xor,
        [ExpressionToken(@"\>\>", 160, ">>")] [Swallows(BiggerOrEqualThat)] ShiftRight,
        [ExpressionToken(@"\>\=", 165, ">=")] [Swallows(BiggerThan)] BiggerOrEqualThat,
        [ExpressionToken(@"\>", 170, ">")] BiggerThan,
        [ExpressionToken(@"\<\<", 175, "<<")] [Swallows(SmallerOrEqualThat)] ShiftLeft,
        [ExpressionToken(@"\<\=", 180, "<=")] [Swallows(SmallerThan)] SmallerOrEqualThat,
        [ExpressionToken(@"\<", 185, "<")] SmallerThan,
        [ExpressionToken(@"\(", 190, "(")] LeftParen,
        [ExpressionToken(@"\)", 195, ")")] RightParen,
        [ExpressionToken(@"\{", 200, "{")] LeftBrace,
        [ExpressionToken(@"\}", 205, "}")] RightBrace,
        [ExpressionToken(@"\[", 210, "[")] LeftBracet,
        [ExpressionToken(@"\]", 215, "]")] RightBracet,
        [ExpressionToken(@"(?<!\\)(\#)", 220, "#")] Hashtag,
        [ExpressionToken(@"\,", 225, ",")] Comma,
        [ExpressionToken(@"\.\.", 230, "..")] [Swallows(Period)] RangeTo,
        [ExpressionToken(@"\.", 235, ".")] Period,
        [ExpressionToken(@"\?\?", 240, "??")] [Swallows(QuestionMark)] NullCoalescing,
        [ExpressionToken(@"\?", 245, "?")] QuestionMark,
        [ExpressionToken(@"(?<!\\)\:", 250, ":")] Colon,
        [ExpressionToken(@"(?<!\\)(\\)(?!\\)", 251, "\\")] Escape,
        [ExpressionToken(@"\;", 255, ";")] SemiColon,
        [ExpressionToken(@"\@", 260, "@")] Shtrudel,
    }
}