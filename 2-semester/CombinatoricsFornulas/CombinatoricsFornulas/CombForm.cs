using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatoricsFormulas
{
    internal class CombForm
    {
        static public double Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n-1);
            }
        }

        static public double TranspositionRepetition(int n, List<int> N)//перестановки с повторениями
        {
            double denominator = 1;
            foreach (var nk in N)
            {
                denominator *= Factorial(nk);
            }

            return Factorial(n)/ denominator;
        }

        static public double Combinations(int n, int m) //сочетания
        {
            return Factorial(n) / (Factorial(n - m) * Factorial(m));

        }
        static public double Permutations(int n, int m)//размещния
        {
            return Factorial(n) / Factorial(n - m);
        }

        static public double CombinationsRepetition(int n, int m) //сочетания c повторениями
        {
            return Factorial(n + m - 1) / (Factorial(n - 1) * Factorial(m));

        }
        static public double PermutationsRepetition(int n, int m)//размещния c повторениями
        {
            return Math.Pow(n, m);
        }
    }
}
