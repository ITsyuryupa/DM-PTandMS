using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryRelationship
{


    public partial class Form1 : Form
    {
        

        List<int> Nat;
        List<int> Int;
        List<double> Rac;
        List<double> Irac;
        List<string> Complex;
        List<string> Object;
        List<string> RandomSet;
        List<Relations> relations;
        List<Relations> Additionalrelations;
        Graphics g;

        int[,] data;

        int[,] additionalData;

        int[,] composition;

        public Form1()
        {
            InitializeComponent();
            buttonFillDataAdditional.Enabled = false;
            //textBoxEnterSet.Enabled = false;

            g = pictureBox1.CreateGraphics();

            checkedListBoxSetProp.Items.Add("Рефлективность");
            checkedListBoxSetProp.Items.Add("Симметричность");
            checkedListBoxSetProp.Items.Add("Кососимметричность");
            checkedListBoxSetProp.Items.Add("Транзитивность");
            checkedListBoxSetProp.Items.Add("Отношение частичного порядка");
            checkedListBoxSetProp.Items.Add("Отношение линейного порядка");
            checkedListBoxSetProp.Items.Add("Отношение эквивалентности");

            Nat = new List<int> { 1, 2, 3, 4 };
            Int = new List<int> { -1, 0, 1, 2 };
            Rac = new List<double> { (-1.0 / 2.0), 0, (1.0 / 3.0), (2.0 / 4.0) };
            Irac = new List<double> { Math.PI, Math.Sqrt(2), Math.Sqrt(3), Math.Sqrt(5) };
            Complex = new List<string> { "1+3i", "-0,5+6i", "7-i", "5+5i" };
            Object = new List<string> { "a", "b", "c", "d" };
            RandomSet = new List<string>();

            relations = new List<Relations>();
            Additionalrelations = new List<Relations>();

            data = new int[4,4];
            additionalData = new int[4, 4];
            composition = new int[4, 4]; ;

            comboBox1Set.Items.Add("Nat");

            comboBox1Set.Items.Add("Int");

            comboBox1Set.Items.Add("Rac");

            comboBox1Set.Items.Add("Irac");

            comboBox1Set.Items.Add("Complex");

            comboBox1Set.Items.Add("Object");

            //comboBox1Set.Items.Add("");




        }

        public static void DrawGraph<T>(Graphics g, int[,] data, List<T> set) where T : IComparable
        {
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black);
            int step = 40;
            int r = 30;
            Font font = new Font("Comic Sans", 10);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    
                    if (data[i, j] != 0)
                    {
                        g.DrawLine(pen, 10 + 10, (10 + i * step) + 10, 100 + 10, (10 + j * step) + 10);
                    }
                    g.FillEllipse(Brushes.White, (10), (10 + i * step), r, r);
                    g.DrawEllipse(pen, 10, 10 + i * step, r, r);


                    g.DrawString(set[i].ToString(), font, Brushes.Green, 10 + 3, 10 + 10 + i * step);

                    g.FillEllipse(Brushes.White, (100), (10 + i * step), r, r);
                    g.DrawEllipse(pen, 100, 10 + i * step, r, r);


                    g.DrawString(set[i].ToString(), font, Brushes.Green, 100 + 3, 10 + 10 + i * step);
                }
            }

        }

        private void buttonChoseSet_Click(object sender, EventArgs e)
        {
            
            if (textBoxEnterSet.Text != "")
            {
                Grid.FillGridRandomSet(ref dataGridViewRelationship, textBoxEnterSet.Text, ref RandomSet);
                textBoxEnterSet.Clear();
                //textBoxEnterSet.Enabled = false;
                data = new int[4, 4];
                additionalData = new int[4, 4];
                composition = new int[4, 4];
                buttonFillDataAdditional.Enabled = false;
                richTextBoxEClass.Clear();
                richTextBox1.Clear();
                relations.Clear();
                for (int i = 0; i < checkedListBoxSetProp.Items.Count; i++)
                {
                    checkedListBoxSetProp.SetItemChecked(i, false);
                }
                return;
            }
            else if (comboBox1Set.Text == "")
            {
                MessageBox.Show("Выберете множество");
                return;
            }
            
            Grid.FillGrid(ref dataGridViewRelationship, comboBox1Set.Text);
            buttonFillDataAdditional.Enabled = false;
            richTextBoxEClass.Clear();
            richTextBox1.Clear();
            for (int i = 0; i < checkedListBoxSetProp.Items.Count; i++)
            {
                checkedListBoxSetProp.SetItemChecked(i, false);
            }
            //textBoxEnterSet.Enabled = false;

            data = new int[4, 4];
            additionalData = new int[4, 4];
            composition = new int[4, 4];
            

        }

        private void buttonFillData_Click(object sender, EventArgs e)
        {
            try
            {
                Grid.FilGridData(ref dataGridViewRelationship, ref data);
            }
            catch
            {
                MessageBox.Show("Таблица пуста");
                return;
            }

            buttonFillDataAdditional.Enabled = true;
            richTextBoxEClass.Clear();
            richTextBox1.Clear();

            for (int i = 0; i < checkedListBoxSetProp.Items.Count; i++)
            {
                checkedListBoxSetProp.SetItemChecked(i, false);
            }
            

            if (Relations.CheckReflexivity(data))
            {
                checkedListBoxSetProp.SetItemChecked(0, true);
            }
            if (Relations.CheckSymmetry(data))
            {
                checkedListBoxSetProp.SetItemChecked(1, true);
            }

            switch (comboBox1Set.Text)
            {
                case "Nat":
                    if(Relations.CheckSkewSymmetry(data, Nat)) checkedListBoxSetProp.SetItemChecked(2, true);
                    richTextBox1.Text += "Бинарные отношения:\n";
                    richTextBox1.Text += Relations.MakeRelations(data, relations, Nat);
                    richTextBox1.Text += Relations.MakeInverseRelations(relations);
                    break;
                case "Int":
                    if (Relations.CheckSkewSymmetry(data, Int)) checkedListBoxSetProp.SetItemChecked(2, true);
                    richTextBox1.Text += "Бинарные отношения:\n";
                    richTextBox1.Text += Relations.MakeRelations(data, relations, Int);
                    richTextBox1.Text += Relations.MakeInverseRelations(relations);
                    break;
                case "Rac":
                    if (Relations.CheckSkewSymmetry(data, Rac)) checkedListBoxSetProp.SetItemChecked(2, true);
                    richTextBox1.Text += "Бинарные отношения:\n";
                    richTextBox1.Text += Relations.MakeRelations(data, relations, Rac);
                    richTextBox1.Text += Relations.MakeInverseRelations(relations);
                    break;
                case "Irac":
                    if (Relations.CheckSkewSymmetry(data, Irac)) checkedListBoxSetProp.SetItemChecked(2, true);
                    richTextBox1.Text += "Бинарные отношения:\n";
                    richTextBox1.Text += Relations.MakeRelations(data, relations, Irac);
                    richTextBox1.Text += Relations.MakeInverseRelations(relations);
                    break;
                case "Complex":
                    if (Relations.CheckSkewSymmetry(data, Complex)) checkedListBoxSetProp.SetItemChecked(2, true);
                    richTextBox1.Text += "Бинарные отношения:\n";
                    richTextBox1.Text += Relations.MakeRelations(data, relations, Complex);
                    richTextBox1.Text += Relations.MakeInverseRelations(relations);
                    break;
                case "Object":
                    if (Relations.CheckSkewSymmetry(data, Object)) checkedListBoxSetProp.SetItemChecked(2, true);
                    richTextBox1.Text += "Бинарные отношения:\n";
                    richTextBox1.Text += Relations.MakeRelations(data, relations, Object);
                    richTextBox1.Text += Relations.MakeInverseRelations(relations);
                    break;
                default:
                    if (Relations.CheckSkewSymmetry(data, RandomSet)) checkedListBoxSetProp.SetItemChecked(2, true);
                    richTextBox1.Text += "Бинарные отношения:\n";
                    richTextBox1.Text += Relations.MakeRelations(data, relations, RandomSet);
                    richTextBox1.Text += Relations.MakeInverseRelations(relations);
                    break;
            }

            if (Relations.CheckTransitivity(data))
            {
                checkedListBoxSetProp.SetItemChecked(3, true);
            }

            if (checkedListBoxSetProp.GetItemChecked(0) && checkedListBoxSetProp.GetItemChecked(2) 
                && checkedListBoxSetProp.GetItemChecked(3))
            {
                checkedListBoxSetProp.SetItemChecked(4, true);
                if (Relations.CheckLinearOrder(data))
                {
                    checkedListBoxSetProp.SetItemChecked(5, true);
                }
            }

            if (checkedListBoxSetProp.GetItemChecked(0) && checkedListBoxSetProp.GetItemChecked(1)
                && checkedListBoxSetProp.GetItemChecked(3))
            {
                checkedListBoxSetProp.SetItemChecked(6, true);
                //Relations.SplitEClass(data, );
                switch (comboBox1Set.Text)
                {
                    case "Nat":
                        richTextBoxEClass.Text = Relations.SplitEClass(data, Nat);
                        
                        break;
                    case "Int":
                        richTextBoxEClass.Text = Relations.SplitEClass(data, Int);
                        break;
                    case "Rac":
                        richTextBoxEClass.Text = Relations.SplitEClass(data, Rac);
                        break;
                    case "Irac":
                        richTextBoxEClass.Text = Relations.SplitEClass(data, Irac);
                        break;
                    case "Complex":
                        richTextBoxEClass.Text = Relations.SplitEClass(data, Complex);
                        break;
                    case "Object":
                        richTextBoxEClass.Text = Relations.SplitEClass(data, Object);
                        break;
                    default:
                        richTextBoxEClass.Text = Relations.SplitEClass(data, RandomSet);
                        break;
                }
            }

            switch (comboBox1Set.Text)
            {
                case "Nat":
                    
                    DrawGraph(g, data, Nat);
                    break;
                case "Int":
                   
                    DrawGraph(g, data, Int);
                    break;
                case "Rac":
                    
                    DrawGraph(g, data, Rac);
                    break;
                case "Irac":
                   
                    DrawGraph(g, data, Irac);
                    break;
                case "Complex":
                    
                    DrawGraph(g, data, Complex);
                    break;
                case "Object":
                    
                    DrawGraph(g, data, Object);
                    break;
                default:
                    
                    DrawGraph(g, data, RandomSet);
                    break;
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewRelationship_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewRelationship[e.ColumnIndex, e.RowIndex].Value.ToString() == "0")
            {
                dataGridViewRelationship[e.ColumnIndex, e.RowIndex].Style.BackColor = ControlPaint.Light(Color.White);
            }
            else if (dataGridViewRelationship[e.ColumnIndex, e.RowIndex].Value.ToString() == "1")
               dataGridViewRelationship[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGreen;
            else
            {
                dataGridViewRelationship[e.ColumnIndex, e.RowIndex].Value = 0;
                MessageBox.Show("Неподходящее значение");
            }
        }

        private void buttonFillDataAdditional_Click(object sender, EventArgs e)
        {
            try
            {
                Grid.FilGridData(ref dataGridViewRelationship, ref additionalData);
            }
            catch
            {
                MessageBox.Show("Таблица пуста");
                return;
            }
            textBoxEnterSet.Enabled = true;
            switch (comboBox1Set.Text)
            {
                case "Nat":
                   
                    richTextBox1.Text += "\nДополнительное бинарные отношения:\n";
                    richTextBox1.Text += Relations.MakeRelations(additionalData, Additionalrelations, Nat);
                    
                    break;
                case "Int":
                    
                    richTextBox1.Text += "\nДополнительное бинарные отношения:\n";
                    richTextBox1.Text += Relations.MakeRelations(additionalData, Additionalrelations, Int);
                    
                    break;
                case "Rac":
                    
                    richTextBox1.Text += "\nДополнительное бинарные отношения:\n";
                    richTextBox1.Text += Relations.MakeRelations(additionalData, Additionalrelations, Rac);
                    
                    break;
                case "Irac":
                    
                    richTextBox1.Text += "\nДополнительное бинарные отношения:\n";
                    richTextBox1.Text += Relations.MakeRelations(additionalData, Additionalrelations, Irac);
                    
                    break;
                case "Complex":
                    
                    richTextBox1.Text += "\nДополнительное бинарные отношения:\n";
                    richTextBox1.Text += Relations.MakeRelations(additionalData, Additionalrelations, Complex);
                    
                    break;
                case "Object":
                    
                    richTextBox1.Text += "\nДополнительное бинарные отношения:\n";
                    richTextBox1.Text += Relations.MakeRelations(additionalData, Additionalrelations, Object);
                    
                    break;
                default:
                    
                    richTextBox1.Text += "\nДополнительное бинарные отношения:\n";
                    richTextBox1.Text += Relations.MakeRelations(additionalData, Additionalrelations, RandomSet);
                    
                    break;
            }
            richTextBoxEClass.Text += "\nКомпозиция бинарных отношений:\n";
            richTextBoxEClass.Text += Relations.Composition(data, additionalData, composition);
        }

        private void comboBox1Set_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonFillDataAdditional.Enabled = false;
        }

        private void textBoxEnterSet_TextChanged(object sender, EventArgs e)
        {
            comboBox1Set.Text = "";
        }
    }


    class Grid
    {
        public static void FillGrid(ref DataGridView grid, string setName1)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();
            grid.Columns.Add("", "");

            List<int> Nat = new List<int> { 1, 2, 3, 4 };
            List<int> Int = new List<int> { -1, 0, 1, 2 };
            List<double> Rac = new List<double> { (-1.0 / 2.0), 0, (1.0 / 3.0), (2.0 / 4.0) };
            List<double> Irac = new List<double> {Math.PI, Math.Sqrt(2), Math.Sqrt(3), Math.Sqrt(5)};
            List<string> Complex = new List<string> { "1+3i", "-0,5+6i", "7-i", "5+5i" };
            List<string> Object = new List<string> { "a", "b", "c", "d" };

            switch (setName1)
            {
                case"Nat":
                    foreach (var item in Nat)
                    {
                        grid.Columns.Add(item.ToString(), item.ToString());
                        grid.Rows.Add(item.ToString());
                    }
                    break;
                case "Int":
                    foreach (var item in Int)
                    {
                        grid.Columns.Add(item.ToString(), item.ToString());
                        grid.Rows.Add(item.ToString());
                    }
                    break;
                case "Rac":
                    foreach (var item in Rac)
                    {
                        grid.Columns.Add(item.ToString(), item.ToString());
                        grid.Rows.Add(item.ToString());
                    }
                    break;
                case "Irac":
                    foreach (var item in Irac)
                    {
                        grid.Columns.Add(item.ToString(), item.ToString());
                        grid.Rows.Add(item.ToString());
                    }
                    break;
                case "Complex":
                    foreach (var item in Complex)
                    {
                        grid.Columns.Add(item.ToString(), item.ToString());
                        grid.Rows.Add(item.ToString());
                    }
                    break;
                case "Object":
                    foreach (var item in Object)
                    {
                        grid.Columns.Add(item.ToString(), item.ToString());
                        grid.Rows.Add(item.ToString());
                    }
                    break;
                default:
                    break;
            }

            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    grid[i, j].Value = 0;
                }
            }

            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.Width = 64;
            }
        }

        public static void FillGridRandomSet(ref DataGridView grid, string setString, ref List<string> RandomSet)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();
            grid.Columns.Add("", "");

            List<string> set = setString.Split().ToList<string>();
            set.RemoveAll(item => item == "");

            
            RandomSet = set.Distinct().ToList<string>();

            while (RandomSet.Count > 4)
            {
                RandomSet.RemoveAt(4);
            }

            if (RandomSet.Count < 4)
            {
                MessageBox.Show("Недостаточно элементов");
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                grid.Columns.Add(RandomSet[i].ToString(), RandomSet[i].ToString());
                grid.Rows.Add(RandomSet[i]);
            }

            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    grid[i, j].Value = 0;
                }
            }

            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.Width = 64;
            }
        }

        public static void FilGridData(ref DataGridView grid, ref int[,] data)
        {
           
            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    data[j, i - 1] =  int.Parse(grid[i, j].Value.ToString());
                }
            }
        }
        
    }

    class Relations
    {
        object x;
        object y;

        

        public static string Composition(int[,] data, int[,] adData, int[,] composition)
        {
            string answer = "";

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j] != 0 && adData[i, j] != 0)
                    {
                        composition[i, j] = 1;
                    }
                }
            }

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    answer += $"{composition[i, j], 5}";
                }

                answer += $"\n";
            }

            return answer;
        }

        public static string MakeRelations<T>(int[,] data, List<Relations> relations, List<T> set) where T : IComparable
        {
            string answer = "";

            relations.Clear();

            int[,] localdata = new int[data.GetLength(0), data.GetLength(1)];

            Array.Copy(data, localdata, data.Length);

            //List<Relations> relations = new List<Relations>();

            for (int i = 0; i < localdata.GetLength(0); i++)
            {
                for (int j = 0; j < localdata.GetLength(1); j++)
                {
                    if (localdata[i, j] != 0)
                    {
                        Relations r = new Relations();
                        r.x = set[i];
                        r.y = set[j];
                        relations.Add(r);

                        if(i == j) localdata[j, i] = 0;
                    }
                }
            }
            
            foreach (var r in relations)
            {
                answer += $"({r.x, 5},{r.y, 5})  ";
                
            }

            return answer;
        }

        public static string MakeInverseRelations(List<Relations> relations)
        {
            string answer = "\nОбраиное отношение:\n";


            foreach (var r in relations)
            {
                answer += $"({r.y,5},{r.x,5})  ";
            }

            return answer;
        }

        public static bool CheckReflexivity(int[,] data)
        {
            bool answer = true;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i,i] == 0)
                {
                    answer = false;
                    return answer;
                }
            }
            return answer;
        }

        public static bool CheckSymmetry(int[,] data)
        {
            bool answer = true;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j] != data[j, i])
                    {
                        answer = false;
                        return answer;
                    }
                }
            }
            return answer;
        }

        #region ChekSkewSymmetry

        public static bool CheckSkewSymmetry<T>(int[,] data, List<T> set) where T : IComparable
        {
            bool answer = true;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j] != 0 && data[j, i] != 0 && !Equals(set[i],set[j]))
                    {
                        answer = false;
                        return answer;
                    }
                }
            }
            return answer;
        }
        public static bool CheckSkewSymmetry(int[,] data, List<object> set)
        {
            bool answer = true;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j] != 0 && data[j, i] != 0 && set[i] != set[j])
                    {
                        answer = false;
                        return answer;
                    }
                }
            }
            return answer;
        }
        #endregion 

        public static bool CheckTransitivity(int[,] data)
        {
            bool answer = true;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (i == j) continue;

                    if (data[i, j] != 0)
                    {
                        for (int k = 0; k < data.GetLength(1); k++)
                        {
                            if (data[j, k] != 0 && data[i, k] == 0 )
                            {
                                answer = false;
                                return answer;
                            }
                        }
                    }
                }
            }
            return answer;
        } 

        public static bool CheckLinearOrder(int[,] data)
        {
            bool answer = true;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {                    

                    if (data[i, j] == 0 && data[j, i] == 0)
                    {
                        answer = false;
                        return answer;
                    }
                }
            }
            return answer;
        } 

        public static string SplitEClass<T>(int[,] data, List<T> set) where T : IComparable
        {
            List<List<object>> Eclasses = new List<List<object>>();
            string answer = "";
            int i = 0;

            int[,] localdata = new int[data.GetLength(0), data.GetLength(1)];

            Array.Copy(data, localdata, data.Length);
            //foreach (var item in set)
            //{
            //    answer += $"Class({item})\n";

            //    for (int j = 0; j < data.GetLength(1); j++)
            //    {
            //        if (data[i,j] != 0)
            //        {
            //            answer += item + " ";
            //        }
            //        answer += "\n";
            //    }
            //    i++;
            //}

            List<object> classE = new List<object>();
            foreach (var item in set)
            {
                

                for (int j = 0; j < localdata.GetLength(1); j++)
                {
                    if (localdata[i, j] != 0)
                    {
                        classE.Add(set[j]);

                        for (int k = 0; k < localdata.GetLength(0); k++)
                        {
                            localdata[k, j] = 0;
                        }
                        
                    }
                    
                }
                if (classE.Count > 0)
                {
                    Eclasses.Add(classE);
                }
                
                classE = new List<object>();
                i++;
            }

            foreach (List<object> classe in Eclasses)
            {
                if (classe.Count == 0) continue;
                answer += $"Класс Эквивалентности по {classe[0]}\n";
                foreach (var item in classe)
                {
                    answer += item + "  ";
                }
                answer += "\n";
            }

            return answer;
        } 

        
    }
}
