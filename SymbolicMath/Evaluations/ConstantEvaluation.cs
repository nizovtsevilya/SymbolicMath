namespace SymbolicMath.Evaluations
{
    internal sealed class ConstantEvaluation : Evaluation
    {
        private readonly object value;

        public ConstantEvaluation(object value)
        {
            this.value = value;
        }

        public override object Value => value;
    }
}
