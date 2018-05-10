using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (!float.TryParse(argument.Value.ToString(), out float argumentValue))
                {
                    throw new InvalidOperationException("Error");
                }

                switch (function)
                {
                    case FunctionOperation.sin:
                       return Math.Sin(argumentValue);
                    case FunctionOperation.cos:
                        return Math.Cos(argumentValue);
                    case FunctionOperation.tg:
                        return Math.Tan(argumentValue);
                    case FunctionOperation.ctg:
                        return 1f / Math.Tan(argumentValue);
                }

                throw new InvalidOperationException("Invalid function operation.");
            }
        }

        public override string ToString() => $"{function}({argument.ToString()})";
    }
}