using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificationAxiomsPropositionalCalculus
{
    internal class Axiom11
    {
        public int varCount = 2;

        public string[] ColumnLinks = { "A", "B", "¬2", "3∨1" };
        public string[] Column = { "A", "B", "¬A", "A∨¬A" };

        public int[,] values = { { 0, 0, -1, -1 }, { 0, 1, -1, -1 }, { 1, 0, -1, -1 }, { 1, 1, -1, -1 } };
    }
}
