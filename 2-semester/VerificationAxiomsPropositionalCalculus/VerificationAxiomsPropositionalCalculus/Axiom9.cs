using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificationAxiomsPropositionalCalculus
{
    internal class Axiom9
    {
        public int varCount = 2;

        public string[] ColumnLinks = { "A", "B", "¬2", "3→2", "2→1" };
        public string[] Column = { "A", "B", "¬A", "A→B", "¬A→(A→B)" };

        public int[,] values = { { 0, 0, -1, -1, -1 }, { 0, 1, -1, -1, -1 },
            { 1, 0, -1, -1, -1 }, { 1, 1, -1, -1, -1 } };
    }
}
