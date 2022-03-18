using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerificationAxiomsPropositionalCalculus
{
    internal class Parser
    {
        public static void Start(ref int[,] arrValues, string[] columnlinks, int varCount)
        {
            for (int i = 0; i < arrValues.GetLength(0); i++)
            {
                
                for (int j = varCount; j < arrValues.GetLength(1); j++)
                {
                    arrValues[i , j] = Pars(columnlinks[j], arrValues, i , j);
                }
            }
        }
        public static int Pars(string expression, int[,] arrValues, int ii, int j)
        {
            char[] expArr = expression.ToCharArray();
            for (int i  = 0; i < expArr.Length; i++)
            {

                switch (expArr[i])
                {
                    case '¬':
                        int one = arrValues[ii, j - int.Parse(expArr[i + 1].ToString())];
                        int two = -1;
                        return Negation(one);
                    case '^':
                        one = arrValues[ii, j - int.Parse(expArr[i - 1].ToString())];
                        two = arrValues[ii, j - int.Parse(expArr[i + 1].ToString())];
                        return Multiply(one, two);
                    case '∨':
                        one = arrValues[ii, j - int.Parse(expArr[i - 1].ToString())];
                        two = arrValues[ii, j - int.Parse(expArr[i + 1].ToString())];
                        return Add(one, two);
                    case '→':
                        one = arrValues[ii, j - int.Parse(expArr[i - 1].ToString())];
                        two = arrValues[ii, j - int.Parse(expArr[i + 1].ToString())];
                        return Implicant(one, two);
                    default:
                        continue;
                }
            }
            return 0;
        }

        //public static int SearchVar(string expression, int[,] arrValues)
        //{
        //    char[] expArr = expression.ToCharArray();
        //    for (int i = 0; i < expArr.Length; i++)
        //    {
        //        switch (expArr[i])
        //        {
        //            case '→':
                        
        //                return Implicant(0, 0);
        //            default:
        //                continue;
        //        }
        //    }
        //    return 0;
        //}


        public static int Multiply(int A, int B)
        {
            if ((A * B) > 0)
                return (1);
            return (0);
        }
        public static int Add(int A, int B)
        {
            if ((A + B) > 0)
                return (1);
            return (0);
        }
        public static int Implicant(int A, int B)
        {
            if (A > B)
                return (0);
            return (1);
        }
        public static int Negation(int A)
        {
            if (A == 0)
                return (1);
            return (0);
        }
    }
}

