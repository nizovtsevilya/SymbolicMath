using SymbolicMath.Evaluations;
using System;

namespace SymbolicMath
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var evaluator = new Evaluator();
            var evaluation = evaluator.Evaluate("2^5");
            Console.WriteLine(evaluation.Value);
        }
    }
}
