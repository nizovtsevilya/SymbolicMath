using System;
using SymbolicMath.Evaluations;

namespace SymbolicMath
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var evaluator = new Evaluator();
            var evaluation = evaluator.Evaluate("sin(0) + 2");
            Console.WriteLine(evaluation.Value);
            Console.Read();
        }
    }
}
