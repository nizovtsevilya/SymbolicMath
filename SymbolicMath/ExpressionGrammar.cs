using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace SymbolicMath
{
    [Language("Expression")]
    public class ExpressionGrammar : Grammar
    {
        public ExpressionGrammar()
        {
            var number = new NumberLiteral("number");
            var identifier = new IdentifierTerminal("identifier");

            var Expr = new NonTerminal("Expr");
            var Term = new NonTerminal("Term");
            var BinExpr = new NonTerminal("BinExpr");
            var ParExpr = new NonTerminal("ParExpr");
            var UnExpr = new NonTerminal("UnExpr");
            var UnOp = new NonTerminal("UnOp");
            var BinOp = new NonTerminal("BinOp", "operator");
            var PropertyAccess = new NonTerminal("PropertyAccess");
            var FunctionCall = new NonTerminal("FunctionCall");
            var CommaSeparatedIdentifierList = new NonTerminal("PointArgumentList");
            var ArgumentList = new NonTerminal("ArgumentList");
            var AssignmentStmt = new NonTerminal("AssignmentStmt", typeof(AssignmentNode));
            var AssignmentOp = new NonTerminal("AssignmentOp", "assignment operator");

            Expr.Rule = Term | UnExpr | BinExpr | AssignmentStmt;
            Term.Rule = number | identifier | ParExpr | FunctionCall | PropertyAccess;
            UnExpr.Rule = UnOp + Term;
            UnOp.Rule = ToTerm("-");
            BinExpr.Rule = Expr + BinOp + Expr;
            BinOp.Rule = ToTerm("+") | "-" | "*" | "/" | "^";
            PropertyAccess.Rule = identifier + "." + identifier;
            FunctionCall.Rule = identifier + "(" + ArgumentList + ")";
            ArgumentList.Rule = Expr | CommaSeparatedIdentifierList;
            ParExpr.Rule = "(" + Expr + ")";
            CommaSeparatedIdentifierList.Rule = MakePlusRule(CommaSeparatedIdentifierList, ToTerm(","), identifier);
            AssignmentStmt.Rule = identifier + AssignmentOp + Term;
            AssignmentOp.Rule = ToTerm("=");

            Root = Expr;

            RegisterOperators(1, "+", "-");
            RegisterOperators(2, "*", "/");
            RegisterOperators(3, Associativity.Right, "^");

            MarkPunctuation("(", ")", ".", ",");
            MarkTransient(Term, Expr, BinOp, UnOp, ParExpr, ArgumentList, CommaSeparatedIdentifierList, AssignmentOp);
        }
    }
}
