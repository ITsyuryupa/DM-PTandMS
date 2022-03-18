using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DM_Laba3_СКНФ_СДНФ_
{
    public partial class Form1 : Form
    {
        int[,] DATA;
        int CountVar = 0;
        bool AllGood = true;
        public Form1()
        {
            
            InitializeComponent();
            label1.Text = "Введите кол-во переменных";
            data.Enabled = false;
        }
        
       
        
        private void gridClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            data.Enabled = false;
            DATA = new int[0,0];
            data.Rows.Clear();
            data.Columns.Clear();


            data.Columns.Add("FValue", "Function Value");
            maskedTextBox1.Text = String.Empty;

        }
        private void buttonСountVar_Click(object sender, EventArgs e)
        {
            //gridClear_Click(sender, e);
            listBox1.Items.Clear();

            //data.Enabled = false;
            DATA = new int[0, 0];
            data.Rows.Clear();
            data.Columns.Clear();


            data.Columns.Add("FValue", "Function Value");
            //maskedTextBox1.Text = String.Empty;
            data.Enabled = true;

            try
            {
                CountVar = int.Parse(maskedTextBox1.Text);
            }
            catch
            {
                MessageBox.Show("Введите кол-во переменных");
                return;
            }

            AddRowsColumnsGrid(CountVar);
            BinaryCombinationFillGrid();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            
            DATA = new int[data.RowCount - 1, data.ColumnCount];
            FillDATA(ref DATA);
            SKNF();
            PDNF();
        }

        //---------------------------------------------------------------------------------------------------------

        public void AddRowsColumnsGrid(int countVar)
        {
            
            for (int i = 0; i < countVar; i++)
            {
                data.Columns.Add(  ( (char)('a' + i) ).ToString(), ( (char)('a' + i) ).ToString() );
            }

            for (int i = 0; i < Math.Pow(2, (double)countVar); i++)
            {
                data.Rows.Add();
            }

        }
        public void BinaryCombinationFillGrid()//fill grid 0 1 10 11 100...
        {
            for (int i = 0; i < data.ColumnCount; i++)
            {
                
                for (int j = 0; j < data.RowCount - 1; j++)
                {

                    data[i, j].Value = 0;
                    
                }
            }
            double n = double.Parse(maskedTextBox1.Text);
            for (int i = 0; i < Math.Pow(2, n); i++)
            {
                char[] c = Convert.ToString(i, 2).ToCharArray();
                int counter = data.ColumnCount - 1;
                for (int j = c.Length - 1; j >= 0; j--)
                {

                    data[counter, i].Value = int.Parse(c[j].ToString());
                    counter--;
                }
            }
            
        }
        
        public void FillDATA(ref int[,] Data)//fill DATA from grid
        {

            
            for (int i = 0; i < data.ColumnCount; i++)
            {
                for (int j = 0; j < data.RowCount - 1; j++)
                {
                    try
                    {
                        DATA[j, i] = int.Parse(data[i, j].Value.ToString());
                    }
                    catch (Exception)
                    {
                        Data[j, i] = 0;
                        data[i, j].Value = 0;
                        AllGood = false;
                        MessageBox.Show("Вы ввели что-то не то");
                        return;
                    }
                    if (int.Parse(data[i, j].Value.ToString()) != 0 && int.Parse(data[i, j].Value.ToString()) != 1)
                    {
                        Data[j, i] = 0;
                        data[i, j].Value = 0;
                        AllGood = false;
                        MessageBox.Show("Вы ввели что-то не то");
                        return;
                    }
                }
            }
            
        }
        public void SKNF()
        {
            if (!AllGood)
            {
                
                return;
            }
            listBox1.Items.Add("СКНФ");
            string s = "";
            char k = '\u2227';//коньюнкция(умножение)^
            char v = '\u2228';//дизъюнкция(сложение)
            char neg = '\u2310';
            char var = 'a';
            for (int i = 0; i < DATA.GetLength(0); i++)
            {
                if (DATA[i, 0] == 0)
                {
                    if(s.Length > 0) s += k;
                    s += "(";

                    for (int j = 1; j < DATA.GetLength(1); j++)
                    {
                        if (DATA[i, j] == 1)
                        {
                            s += neg + ((char)(var + j - 1)).ToString();
                        }
                        else
                        {
                            s += ((char)(var + j - 1)).ToString();
                        }

                        if (j < DATA.GetLength(1) - 1) s += v;

                    }
                    s += ")";
                    
                }
            }

            listBox1.Items.Add(s);
            listBox1.Items.Add("");
        }
        private void PDNF()//СДНФ
        {
            if (!AllGood)
            {
                AllGood = true;
                return;
                
            }
            listBox1.Items.Add("CДНФ");
            string s = "";
            char k = '\u2227';//коньюнкция(умножение)
            char v = '\u2228';//дизъюнкция(сложение)
            char neg = '\u2310';
            char var = 'a';
            for (int i = 0; i < DATA.GetLength(0); i++)
            {
                if (DATA[i,0] == 1)
                {
                    if (s.Length > 0) s += v;
                    s += "(";

                    for (int j = 1; j < DATA.GetLength(1); j++)
                    {
                        if (DATA[i,j] == 0)
                        {
                            s += neg + ( (char)(var + j - 1) ).ToString();
                        }
                        else
                        {
                            s += ((char)(var + j - 1)).ToString();
                        }

                        if(j < DATA.GetLength(1) - 1) s += k;

                    }
                    s += ")";
                    
                }
            }

            listBox1.Items.Add(s);
            listBox1.Items.Add("");

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }
    }
}
