using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificationAxiomsPropositionalCalculus
{
    internal class Axiom2
    {
        public int varCount = 3;

        public string[] ColumnLinks = { "A", "B", "C", "2→1", "4→1",     "5→4", "6→4", "2→1",         "4→1" };
        public string[] Column =      { "A", "B", "C", "B→C", "A→(B→C)", "A→B", "A→C", "(A→B)→(A→C)", "(A→(B→C))→((A→B)→(A→C))" };

        public int[,] values = { { 0, 0, 0, -1, -1, -1, -1, -1, -1}, { 0, 0, 1, -1,-1, -1, -1, -1, -1 }, { 0, 1, 0, -1, -1, -1, -1, -1, -1 },
                                 { 0, 1, 1, -1, -1, -1, -1, -1, -1 }, { 1, 0, 0, -1, -1, -1, -1, -1, -1 }, { 1, 0, 1, -1, -1, -1, -1, -1, -1 },
                                 { 1, 1, 0, -1, -1, -1, -1, -1, -1 }, { 1, 1, 1, -1, -1, -1, -1, -1, -1 }};
    }
}
