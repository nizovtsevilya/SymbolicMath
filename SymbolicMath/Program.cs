using System;
using SymbolicMath.Evaluations;

namespace SymbolicMath
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var evaluator = new Evaluator();
            var evaluation = evaluator.Evaluate("tg(30+30)");
            Console.WriteLine(evaluation.Value);
            Console.Read();
        }
    }
}
