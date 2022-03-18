using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombinatoricsFormulas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n = 0;
            List<int> N = new List<int>();

            if (int.TryParse(maskedTextBoxN.Text, out n) == false)
            {
                MessageBox.Show("Введите n");
                return;
            }
            if (maskedTextBoxN1k.Text == "")
            {
                MessageBox.Show("Введите n(1, k)");
                return;
            }

            string[] input = maskedTextBoxN1k.Text.Split();
            int sum = 0;
            foreach (var c in input)
            {
                if (c != "")
                {
                    N.Add(int.Parse(c.ToString()));
                    sum += int.Parse(c.ToString());
                }
            }

            if (sum != n && sum + 1 != n)
            {
                MessageBox.Show("n1 + ... + nk = n");
                return;
            }

            richTextBoxResult.Text = CombForm.TranspositionRepetition(n, N).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;

            if (int.TryParse(maskedTextBoxN.Text, out n) == false)
            {
                MessageBox.Show("Введите n");
                return;
            }
            
            richTextBoxResult.Text = CombForm.Factorial(n).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = 0;
            int m = 0;

            if (int.TryParse(maskedTextBoxN.Text, out n) == false)
            {
                MessageBox.Show("Введите n");
                return;
            }
            if (int.TryParse(maskedTextBoxM.Text, out m) == false)
            {
                MessageBox.Show("Введите m");
                return;
            }
            if (n < m)
            {
                MessageBox.Show("0 <= m <= n");
                return;
            }
            richTextBoxResult.Text = CombForm.Combinations(n, m).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n = 0;
            int m = 0;

            if (int.TryParse(maskedTextBoxN.Text, out n) == false)
            {
                MessageBox.Show("Введите n");
                return;
            }
            if (int.TryParse(maskedTextBoxM.Text, out m) == false)
            {
                MessageBox.Show("Введите m");
                return;
            }
            if (n < m)
            {
                MessageBox.Show("0 <= m <= n");
                return;
            }
            richTextBoxResult.Text = CombForm.Permutations(n, m).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int n = 0;
            int m = 0;

            if (int.TryParse(maskedTextBoxN.Text, out n) == false)
            {
                MessageBox.Show("Введите n");
                return;
            }
            if (int.TryParse(maskedTextBoxM.Text, out m) == false)
            {
                MessageBox.Show("Введите m");
                return;
            }
            if (m + n - 1 < 0)
            {
                MessageBox.Show("m + n - 1 >= 0");
                return;
            }
            if (n - 1 < 0)
            {
                MessageBox.Show("n - 1 >= 0");
                return;
            }

            richTextBoxResult.Text = CombForm.CombinationsRepetition(n, m).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int n = 0;
            int m = 0;

            if (int.TryParse(maskedTextBoxN.Text, out n) == false)
            {
                MessageBox.Show("Введите n");
                return;
            }
            if (int.TryParse(maskedTextBoxM.Text, out m) == false)
            {
                MessageBox.Show("Введите m");
                return;
            }
            //if (n < m)
            //{
            //    MessageBox.Show("0 <= m <= n");
            //    return;
            //}
            richTextBoxResult.Text = CombForm.PermutationsRepetition(n, m).ToString();
        }
    }
}
