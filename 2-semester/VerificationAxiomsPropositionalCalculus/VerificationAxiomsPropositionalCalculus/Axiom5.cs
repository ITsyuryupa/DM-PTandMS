using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificationAxiomsPropositionalCalculus
{
    internal class Axiom5
    {
        public int varCount = 2;

        public string[] ColumnLinks = { "A", "B", "2^1", "2→1", "4→1" };
        public string[] Column = { "A", "B", "A^B", "B→(A^B)", "A→(B→(A^B))" };

        public int[,] values = { { 0, 0, -1, -1, -1}, { 0, 1, -1, -1, -1 }, { 1, 0, -1, -1, -1 }, { 1, 1, -1, -1, -1 } };
    }
}
