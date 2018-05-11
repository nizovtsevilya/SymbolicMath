using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolicMath.Evaluations
{
    internal sealed class NameEvaluation : Evaluation
    {
        public Dictionary<string, Evaluation> variables
            = new Dictionary<string, Evaluation>();
        
        public NameEvaluation(string name, Evaluation values)
        {
            variables.Add(name, values);
        }

        public override object Value
        {
            get
            {
                return 0;
            }
        }

        public override string ToString() => $"{variables.Keys.ToString()}={variables.Values.ToString()}";
    }
}
