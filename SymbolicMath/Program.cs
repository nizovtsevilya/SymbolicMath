using System;
using System.IO;
using SymbolicMath.Evaluations;

namespace SymbolicMath
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("> ");
                TextReader tIn = Console.In;
                TextWriter tOut = Console.Out;
                var evaluator = new Evaluator();
                var evaluation = evaluator.Evaluate(tIn.ReadLine());
                Console.ForegroundColor = ConsoleColor.Green;
                tOut.WriteLine(evaluation.Value);
                Console.ResetColor();
            }
        }
    }
}