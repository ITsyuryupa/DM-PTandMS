using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpertSystem
{
    public partial class Form1 : Form
    {

        string[,] wife = new string[10, 2];
        
        string[,] parents = new string[14, 2];
        public static bool Wife(string[,] wife, string waifu, string haifu)
        {
            bool flag = false;
            for (int i = 0; i < wife.GetLength(0); i++)
            {
                if (wife[i,0] == waifu && wife[i, 1] == haifu)
                {
                    flag = true;
                    //MessageBox.Show(i.ToString());
                }
            }
            return flag;
        }
        public static bool WomenMan(string[,] wife, string women, int j)
        {
            bool flag = false;
            for (int i = 0; i < wife.GetLength(0); i++)
            {
                if (wife[i, j] == women)
                {
                    flag = true;
                    //MessageBox.Show(i.ToString());
                }
            }
            return flag;
        }
        

        public static bool ParentOf(string[,] parents, string parent, string child)
        {
            bool flag = false;
            for (int i = 0; i < parents.GetLength(0); i++)
            {
                if (parents[i, 0] == parent && parents[i, 1] == child)
                {
                    flag = true;
                    //MessageBox.Show(i.ToString());
                }
            }
            return flag;
        }

        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            groupBox1.Text = "";
            groupBox1.Visible = false;
            groupBox2.Text = "";
            groupBox2.Visible = false;
            label1.Text = "Выберите функцию";
            wife[0, 0] = "София"; wife[0, 1] = "Георг1";
            wife[1, 0] = "Вильгельмина"; wife[1, 1] = "Георг2";
            wife[2, 0] = "Шарлотта"; wife[2, 1] = "Георг3";
            wife[3, 0] = "Каролина"; wife[3, 1] = "Георг4";
            wife[4, 0] = "Аделаида"; wife[4, 1] = "Вильгельм4";
            wife[5, 0] = "Виктория"; wife[5, 1] = "Альберт";
            wife[6, 0] = "Александра"; wife[6, 1] = "Эдвард7";
            wife[7, 0] = "Виктория Мари"; wife[7, 1] = "Георг5";
            wife[8, 0] = "Елизавета"; wife[8, 1] = "Георг6";
            wife[9, 0] = "Елизавета2"; wife[9, 1] = "Филлипп";

            parents[0, 0] = "Георг1"; parents[0, 1] = "Георг2";
            parents[1, 0] = "Георг3"; parents[1, 1] = "Георг4";
            parents[2, 0] = "Георг3"; parents[2, 1] = "Вильгельм4";
            parents[3, 0] = "Георг3"; parents[3, 1] = "Эдвард";
            parents[4, 0] = "Эдвард"; parents[4, 1] = "Виктория";
            parents[5, 0] = "Виктория"; parents[5, 1] = "Эдвард7";
            parents[6, 0] = "Эдвард7"; parents[6, 1] = "Георг5";
            parents[7, 0] = "Георг5"; parents[7, 1] = "Эдвард8";
            parents[8, 0] = "Георг5"; parents[8, 1] = "Георг6";
            parents[9, 0] = "Георг6"; parents[9, 1] = "Елизавета2";
            parents[10, 0] = "Виктория"; parents[10, 1] = "Элис";
            parents[11, 0] = "Элис"; parents[11, 1] = "Виктория Альберта";
            parents[12, 0] = "Виктория Альберта"; parents[12, 1] = "Элис-Моунтбаттен";
            parents[13, 0] = "Элис-Моунтбаттен"; parents[13, 1] = "Филипп";

           


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            label1.Text = "";
            if (comboBox1.SelectedIndex < 6)
            {
                textBox1.Enabled = true;
                groupBox1.Visible = true;
                textBox2.Enabled = true;
                groupBox2.Visible = true;
            }
            else
            {
                textBox1.Enabled = true;
                groupBox1.Visible = true;
                textBox2.Enabled = false;
                groupBox2.Visible = false;
            }

            switch (comboBox1.SelectedItem.ToString().ToLower())
            {
                case "жена":
                    groupBox1.Text = "Жена";
                    groupBox2.Text = "Муж";
                    break;
                case "муж":
                    groupBox1.Text = "Муж";
                    groupBox2.Text = "Жена";
                    break;
                case "родитель":
                    groupBox1.Text = "Родитель";
                    groupBox2.Text = "Ребёнок";
                    break;
                case "ребенок":
                    groupBox2.Text = "Родитель";
                    groupBox1.Text = "Ребёнок";
                    break;
                case "сын":
                    groupBox1.Text = "Сын";
                    groupBox2.Text = "Родитель";
                    break;
                case "дочь":
                    groupBox1.Text = "Дочь";
                    groupBox2.Text = "Родитель";
                    break;
                case "женщина":
                    groupBox1.Text = "Женщина";
                    break;
                case "мужчина":
                    groupBox1.Text = "Мужчина";
                    break;
            }
        }
        public void v()
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            


            string funcArg1 = textBox1.Text;
            string funcArg2 = textBox2.Text;
            if (comboBox1.SelectedIndex != -1 && textBox1.Text != "" && textBox2.Text != "")
            {
                switch (comboBox1.SelectedItem.ToString().ToLower())
                {
                    case "жена":
                        if (Wife(wife, funcArg1, funcArg2))
                        {
                            label1.Text = "Да";
                        }
                        else label1.Text = "Нет";
                        break;
                    case "муж":
                        if (Wife(wife, funcArg2, funcArg1))
                        {
                            label1.Text = "Да";
                        }
                        else label1.Text = "Нет";
                        break;
                    case "родитель":
                        if (ParentOf(parents, funcArg1, funcArg2))
                        {
                            label1.Text = "Да";
                        }
                        else label1.Text = "Нет";
                        break;
                    case "ребенок":
                        if (ParentOf(parents, funcArg2, funcArg1))
                        {
                            label1.Text = "Да";
                        }
                        else label1.Text = "Нет";
                        break;
                    case "сын":
                        if (WomenMan(wife, funcArg1, 1) && ParentOf(parents, funcArg2, funcArg1))
                        {
                            label1.Text = "Да";
                        } else label1.Text = "Нет";
                        break;
                    case "дочь":
                        if (WomenMan(wife, funcArg1, 0) && ParentOf(parents, funcArg2, funcArg1))
                        {
                            label1.Text = "Да";
                        } else label1.Text = "Нет";
                        break;

                }
            }
            else if (comboBox1.SelectedIndex != -1 && textBox1.Text != "")
            {
                if (comboBox1.SelectedIndex < 6)
                {
                    label1.Text = "Заполните аргументы";
                }

                switch (comboBox1.SelectedItem.ToString().ToLower())
                {
                    case "женщина":
                        if (WomenMan(wife, funcArg1, 0))
                        {
                            label1.Text = "Да";
                        }
                        else label1.Text = "Нет";
                        break;
                    case "мужчина":
                        if (WomenMan(wife, funcArg1, 1))
                        {
                            label1.Text = "Да";
                        }
                        else label1.Text = "Нет";
                        break;
                }
            }
            else
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    label1.Text = "Выберите функцию";
                }
                else
                {
                    label1.Text = "Заполните аргументы";
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
