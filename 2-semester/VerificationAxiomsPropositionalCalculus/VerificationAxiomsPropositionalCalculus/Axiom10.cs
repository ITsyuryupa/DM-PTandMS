using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificationAxiomsPropositionalCalculus
{
    internal class Axiom10
    {
        public int varCount = 2;

        public string[] ColumnLinks = { "A", "B", "2→1", "¬2", "4→1", "¬5", "2→1", "5→1" };
        public string[] Column = { "A", "B", "A→B", "¬B", "A→¬B", "¬A", "(A→¬B)→¬A", "(A→B)→((A→¬B)→¬A)" };

        public int[,] values = { { 0, 0, 0, -1, -1, -1, -1, -1}, { 0, 0, 1, -1,-1, -1, -1, -1 }, { 0, 1, 0, -1, -1, -1, -1, -1 },
                                 { 0, 1, 1, -1, -1, -1, -1, -1 }, { 1, 0, 0, -1, -1, -1, -1, -1 }, { 1, 0, 1, -1, -1, -1, -1, -1 },
                                 { 1, 1, 0, -1, -1, -1, -1, -1 }, { 1, 1, 1, -1, -1, -1, -1, -1 }};
    }
}
