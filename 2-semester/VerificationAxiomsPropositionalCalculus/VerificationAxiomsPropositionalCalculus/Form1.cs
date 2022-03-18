using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace VerificationAxiomsPropositionalCalculus
{
    public partial class Form1 : Form
    {
        public void FillDataGrid(DataGridView data, int[,] varArr, string[] column, Label l)
        {
            data.Columns.Clear();
            data.Rows.Clear();
            for (int i = 0; i < column.Length; i++)
            {
                data.Columns.Add(i.ToString(), column[i]);
            }

            for (int i = 0; i < varArr.GetLength(0); i++)
            {
                data.Rows.Add();
                for (int j = 0; j < varArr.GetLength(1); j++)
                {
                    data[j, i].Value = varArr[i, j];
                }
            }

            for (int i = 0; i < varArr.GetLength(0); i++)
            {
                if (varArr[i, varArr.GetLength(1) - 1] != 1)
                {
                    label12.Text = " не Correct!";
                }
            }

            label12.Text = "Correct!";
            
            
            //MessageBox.Show($"Аксиома {l.Text} выполняется");

        }

        public Form1()
        {
            InitializeComponent();
            label12.Text = "Выберете аксиому";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Axiom1 s = new Axiom1();
            Parser.Start(ref s.values, s.ColumnLinks, s.varCount);

            FillDataGrid(dataGridView1, s.values, s.Column, label1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Axiom2 s = new Axiom2();
            Parser.Start(ref s.values, s.ColumnLinks, s.varCount);

            FillDataGrid(dataGridView1, s.values, s.Column, label2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Axiom3 s = new Axiom3();
            Parser.Start(ref s.values, s.ColumnLinks, s.varCount);

            FillDataGrid(dataGridView1, s.values, s.Column, label3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Axiom4 s = new Axiom4();
            Parser.Start(ref s.values, s.ColumnLinks, s.varCount);

            FillDataGrid(dataGridView1, s.values, s.Column, label4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Axiom5 s = new Axiom5();
            Parser.Start(ref s.values, s.ColumnLinks, s.varCount);

            FillDataGrid(dataGridView1, s.values, s.Column, label5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Axiom6 s = new Axiom6();
            Parser.Start(ref s.values, s.ColumnLinks, s.varCount);

            FillDataGrid(dataGridView1, s.values, s.Column, label6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Axiom7 s = new Axiom7();
            Parser.Start(ref s.values, s.ColumnLinks, s.varCount);

            FillDataGrid(dataGridView1, s.values, s.Column, label7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Axiom8 s = new Axiom8();
            Parser.Start(ref s.values, s.ColumnLinks, s.varCount);

            FillDataGrid(dataGridView1, s.values, s.Column, label8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Axiom9 s = new Axiom9();
            Parser.Start(ref s.values, s.ColumnLinks, s.varCount);

            FillDataGrid(dataGridView1, s.values, s.Column, label9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Axiom10 s = new Axiom10();
            Parser.Start(ref s.values, s.ColumnLinks, s.varCount);

            FillDataGrid(dataGridView1, s.values, s.Column, label10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Axiom11 s = new Axiom11();
            Parser.Start(ref s.values, s.ColumnLinks, s.varCount);

            FillDataGrid(dataGridView1, s.values, s.Column, label11);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
