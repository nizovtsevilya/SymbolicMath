using System;

namespace SymbolicMath.Evaluations
{
    internal sealed class FunctionEvaluation : Evaluation
    {
        private readonly FunctionOperation function;
        private readonly Evaluation argument;

        public FunctionEvaluation(FunctionOperation function, Evaluation argument)
        {
            this.function = function;
            this.argument = argument;
        }

        public override object Value
        {
            get
            {
                Console.WriteLine("Работает!");
                return 0;
            }
        }

        public override string ToString() => $"{function}({argument.ToString()})";
    }
}