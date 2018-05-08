namespace SymbolicMath.Evaluations
{
    internal abstract class Evaluation
    {
        public abstract object Value { get; }
        public override string ToString() => Value?.ToString();
    }
}
