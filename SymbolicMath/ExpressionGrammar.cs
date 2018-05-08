using System;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace SymbolicMath
{
    [Language("Expression")]
    public class ExpressionGrammar : Grammar
    {
        public ExpressionGrammar() : base(false)
        {
            var number = new NumberLiteral("Number");
            number.DefaultIntTypes = new TypeCode[] { TypeCode.Int16, TypeCode.Int32, TypeCode.Int64 };
            number.DefaultFloatType = TypeCode.Single;

            var identifier = new IdentifierTerminal("Identifier");
            var comma = ToTerm(",");

            var binaryOperation = new NonTerminal("BinaryOperator", "operator");
            var parenthesisExpression = new NonTerminal("ParenthesisExpression");
            var binaryExpression = new NonTerminal("BinaryExpression", typeof(BinaryOperationNode));
            var expression = new NonTerminal("Expression");
            var terminal = new NonTerminal("Term");

            var program = new NonTerminal("Program", typeof(StatementListNode));

            expression.Rule = terminal | parenthesisExpression | binaryExpression;
            terminal.Rule = number | identifier;

            parenthesisExpression.Rule = "(" + expression + ")";
            binaryExpression.Rule = expression + binaryOperation + expression;
            binaryOperation.Rule = ToTerm("+") | "-" | "*" | "/" | "^";

            RegisterOperators(10, "+", "-");
            RegisterOperators(20, "*", "/");
            RegisterOperators(30, Associativity.Right, "^");

            MarkPunctuation("(", ")");
            RegisterBracePair("(", ")");
            MarkTransient(expression, terminal, binaryOperation, parenthesisExpression);

            this.Root = expression;
        }
    }
}
