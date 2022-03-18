using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerificationAxiomsPropositionalCalculus
{
    internal class Axiom1
    {

        public int varCount = 2;

        public string[] ColumnLinks = {"A", "B", "1→2", "3→1" };
        public string[] Column = { "A", "B", "B→A", "A→(B→A)" };

        public int[,] values = { {0, 0, -1, -1}, {0, 1, -1, -1}, {1, 0, -1, -1}, {1, 1, -1, -1} };
    }
}
