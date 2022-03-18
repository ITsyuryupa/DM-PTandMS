using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificationAxiomsPropositionalCalculus
{
    internal class Axiom8
    {
        public int varCount = 3;

        public string[] ColumnLinks = { "A", "B", "C", "3→1", "3→2", "5∨4", "1→4", "3→1", "5→1" };
        public string[] Column = { "A", "B", "C", "A→C", "B→C", "A∨B", "(A∨B)→C", "(B→C)→((A∨B)→C)", "(A→C)→((B→C)→((A∨B)→C))" };

        public int[,] values = { { 0, 0, 0, -1, -1, -1, -1, -1, -1}, { 0, 0, 1,-1, -1, -1, -1, -1, -1 }, { 0, 1, 0, -1, -1, -1, -1, -1, -1 },
                                 { 0, 1, 1, -1, -1, -1, -1, -1, -1 }, { 1, 0, 0, -1, -1, -1, -1, -1, -1 }, { 1, 0, 1, -1, -1, -1, -1, -1, -1 },
                                 { 1, 1, 0, -1, -1, -1, -1, -1, -1 }, { 1, 1, 1, -1, -1, -1, -1, -1, -1 }};
    }
}
