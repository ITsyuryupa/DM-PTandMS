using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicSquareWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Text = "введите N";
        }

        private void buttonMakeSquare_Click(object sender, EventArgs e)
        {
            int n;
            try
            {
                n = int.Parse(maskedTextBox1.Text);
            }
            catch 
            {

                MessageBox.Show("Вы забыли ввести n");
                return;
            }
            
            if (n < 3)
            {
                MessageBox.Show("n может быть только от 3");
                return;
            }
            if (n % 2 == 1)
            {
                MagicSquare.PrintMagicSquare(MagicSquare.Odd(n), dataGridView1, richTextBox1);
            }
            else if (n % 4 == 0)
            {
                MagicSquare.PrintMagicSquare(MagicSquare.DoublyEven(n), dataGridView1, richTextBox1);
            }
            else if (n % 2 == 0)
            {
                MagicSquare.PrintMagicSquare(MagicSquare.SinglyEven(n), dataGridView1, richTextBox1);
            }

            maskedTextBox1.Text = "";

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MagicSquare.ScanSquare(dataGridView1, richTextBox1);
        }
    }
}
