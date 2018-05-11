using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolicMath.Evaluations
{
    internal sealed class UnaryEvaluation : Evaluation
    {
        private readonly string op;
        private readonly Evaluation evaluation;


        public UnaryEvaluation(string op, Evaluation evaluation)
        {
            this.op = op;
            this.evaluation = evaluation;
        }

        public override object Value
        {
            get
            {
                return 0;
            }
        }

        public override string ToString() => $"{op}{evaluation.ToString()}";
    }
}
