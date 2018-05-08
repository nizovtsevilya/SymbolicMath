using System;

namespace SymbolicMath.Evaluations
{
    internal sealed class BinaryEvaluation : Evaluation
    {
        private readonly Evaluation left;
        private readonly Evaluation right;
        private readonly BinaryOperation operation;

        public BinaryEvaluation(Evaluation left, Evaluation right, BinaryOperation operation)
        {
            this.left = left;
            this.right = right;
            this.operation = operation;
        }

        public override object Value
        {
            get
            {
                if (left.Value == null || right.Value == null)
                {
                    throw new InvalidOperationException("Either left or right value of the binary evaluation has been evaluated to null.");
                }
                if (!float.TryParse(left.Value.ToString(), out float leftValue) ||
                    !float.TryParse(right.Value.ToString(), out float rightValue))
                {
                    throw new InvalidOperationException("Either left or right value of the binary evaluation cannot be evaluated as a float value.");
                }
                switch (operation)
                {
                    case BinaryOperation.Add:
                        return leftValue + rightValue;
                    case BinaryOperation.Sub:
                        return leftValue - rightValue;
                    case BinaryOperation.Mul:
                        return leftValue * rightValue;
                    case BinaryOperation.Div:
                        return leftValue / rightValue;
                    case BinaryOperation.Exp:
                        return Math.Pow(leftValue, rightValue);
                    default:
                        break;
                }

                throw new InvalidOperationException("Invalid binary operation.");
            }
        }

        public override string ToString() => $"{left?.ToString()} {operation} {right?.ToString()}";
    }
}
