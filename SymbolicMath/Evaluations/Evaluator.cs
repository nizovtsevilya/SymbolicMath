using System;
using System.Globalization;
using System.Text;
using Irony;
using Irony.Parsing;

namespace SymbolicMath.Evaluations
{
    internal sealed class Evaluator
    {
        public Evaluation Evaluate(string input)
        {
            var language = new LanguageData(new ExpressionGrammar());
            var parser = new Parser(language);
            var syntaxTree = parser.Parse(input);

            if (syntaxTree.HasErrors())
            {
                throw new InvalidOperationException(BuildParsingErrorMessage(syntaxTree.ParserMessages));
            }

            return PerformEvaluate(syntaxTree.Root);
        }

        private Evaluation PerformEvaluate(ParseTreeNode node)
        {
            switch (node.Term.Name)
            {
                case "BinExpr":
                    var leftNode = node.ChildNodes[0];
                    var operationNode = node.ChildNodes[1];
                    var rightNode = node.ChildNodes[2];
                    Evaluation left = PerformEvaluate(leftNode);
                    Evaluation right = PerformEvaluate(rightNode);
                    BinaryOperation operation = BinaryOperation.Add;
                    switch (operationNode.Term.Name)
                    {
                        case "+":
                            operation = BinaryOperation.Add;
                            break;
                        case "-":
                            operation = BinaryOperation.Sub;
                            break;
                        case "*":
                            operation = BinaryOperation.Mul;
                            break;
                        case "/":
                            operation = BinaryOperation.Div;
                            break;
                        case "^":
                            operation = BinaryOperation.Exp;
                            break;
                    }
                    return new BinaryEvaluation(left, right, operation);
                case "FunctionCall":
                    var functionNode = node.ChildNodes[0];
                    var argumentNode = node.ChildNodes[1];
                    Evaluation argument = PerformEvaluate(argumentNode);
                    FunctionOperation function = FunctionOperation.sin;
                    switch (functionNode.Token.Text)
                    {
                        case "sin":
                            function = FunctionOperation.sin;
                            break;
                        case "cos":
                            function = FunctionOperation.cos;
                            break;
                        case "tg":
                            function = FunctionOperation.tg;
                            break;
                        case "ctg":
                            function = FunctionOperation.ctg;
                            break;
                    }
                    return new FunctionEvaluation(function, argument);
                case "number":
                    CultureInfo culture = new CultureInfo("en-US");

                    var value = Convert.ToSingle(node.Token.Text, culture);
                    return new ConstantEvaluation(value);
            }

            throw new InvalidOperationException($"Unrecognizable term {node.Term.Name}");
        }

        private static string BuildParsingErrorMessage(LogMessageList messages)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Parsing failed with the following errors:");
            messages.ForEach(msg => sb.AppendLine($"\t{msg.Message}"));
            return sb.ToString();
        }
    }
}
