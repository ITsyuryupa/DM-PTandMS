using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    
    public partial class Form1 : Form
    {
        Graphics g;
        List<Vertex> vertex;
        List<Edge> edge;
        int[,] matrixTruthG


        int vertexIndexBeginEdge = -1;
        int vertexIndexEndEdge = -1;
        Vertex start;
        Vertex end;
        public static int indexVertex = 0;
        public static int radius = 30;
        //public static int countDeleteVertex = 0;
        public Form1()
        {
            InitializeComponent();
            vertex = new List<Vertex>();
            edge = new List<Edge>();
            
            buttonVertex.Enabled = false;
            buttonEdge.Enabled = true;
            button4.Enabled = true;

        }
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            g = pictureBox1.CreateGraphics();

            Vertex v = new Vertex();
            v.x = e.X;
            v.y = e.Y;
            v.index = vertex.Count;

            if (!button4.Enabled && Edge.ChoiseVertexDelete(ref vertexIndexBeginEdge, ref vertexIndexEndEdge, ref vertex, e, 
                ref start, ref end, ref g, radius))
            {
                //countDeleteVertex++;
                Vertex.DeletVertex(ref vertex, ref edge, ref vertexIndexBeginEdge);
                for (int i = 0; i < vertex.Count; i++)
                {
                    vertex[i].index = i;
                }
                //for (int i = 0; i < edge.Count; i++)
                //{
                //    edge[i].v1.index -= i;
                //    edge[i].v2.index -= i;
                //}
                vertexIndexBeginEdge = -1;
                indexVertex--;
                try
                {
                    g.Clear(Color.White);
                }
                catch
                {

                }
                for (int i = 0; i < vertex.Count; i++)
                {
                    Draw.DrawVertexArray(g, vertex[i].x, vertex[i].y, vertex[i].index);
                }

                for (int i = 0; i < edge.Count; i++)
                {
                    Draw.DrawEdge(g, e, ref edge[i].v1.index, ref edge[i].v2.index, ref vertex, ref edge[i].v1, ref edge[i].v2);
                }
            }
            else if ( !buttonVertex.Enabled && Vertex.CollissionChek(ref vertex, v, radius) )
            {
                Draw.DrawVertex(g, e, ref indexVertex);
                vertex.Add(v);
                
            }
            else if (!buttonEdge.Enabled)
            {
                
                if ( Edge.ChoiseVertex(ref vertexIndexBeginEdge, ref vertexIndexEndEdge, ref vertex, e, ref start,
                    ref end,ref g, radius) )
                {
                    Draw.DrawEdge(g, e, ref vertexIndexBeginEdge, ref vertexIndexEndEdge, ref vertex, ref start, ref end);

                    Edge ee = new Edge();
                    //ee.v1 = start;
                    //ee.v2 = end;

                    ee.v1 =  vertex[vertexIndexBeginEdge];
                    ee.v2 = vertex[vertexIndexEndEdge];

                    edge.Add(ee);

                    vertexIndexBeginEdge = -1;
                    vertexIndexEndEdge = -1;
                }

            }
            else if (!buttonFindPath.Enabled && Edge.ChoiseVertex(ref vertexIndexBeginEdge, ref vertexIndexEndEdge, ref vertex, e, ref start, ref end, ref g, radius))
            {
                try
                {
                    string path = Edge.Path(ref vertexIndexBeginEdge, ref vertexIndexEndEdge, matrixTruth);
                    
                    richTextBox1.Text += "\n";
                    if (path.Length == 0)
                    {
                        richTextBox1.Text += "Пути нет ";
                    }
                    richTextBox1.Text += path;
                }
                catch
                {
                    richTextBox1.Text += "Пути нет ";

                }

                for (int i = 0; i < vertex.Count; i++)
                {
                    Draw.DrawVertexArray(g, vertex[i].x, vertex[i].y, vertex[i].index);
                }


                vertexIndexBeginEdge = -1;
                vertexIndexEndEdge = -1;
            }

           

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonVertex_Click(object sender, EventArgs e)
        {
            buttonVertex.Enabled = false;
            buttonEdge.Enabled = true;
            button4.Enabled = true;
            buttonFindPath.Enabled = true;
        }

        private void buttonEdge_Click(object sender, EventArgs e)
        {
            buttonVertex.Enabled = true;
            buttonEdge.Enabled = false;
            button4.Enabled = true;
            buttonFindPath.Enabled = true;
        }

        private void buttonMatrixTrueth_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            //matrixTruth = new int[vertex.Count + countDeleteVertex, vertex.Count + countDeleteVertex];
            matrixTruth = new int[vertex.Count, vertex.Count];
            Graph.MakeMatrixTruth(ref edge, ref vertex, ref matrixTruth);
            Draw.matrixTrueth(matrixTruth, richTextBox1);
        }

        private void buttonVertixDeggree_Click(object sender, EventArgs e)
        {
            buttonMatrixTrueth_Click(sender, e);
            

            richTextBox1.Clear();
            richTextBox1.Text = Graph.VertixDegree(ref matrixTruth);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonMatrixTrueth_Click(sender, e);
            richTextBox1.Clear();

            
            List<string> l = Graph.VertixSubGraphs(ref matrixTruth);
            for (int i = 0; i < l.Count; i++)
            {
                richTextBox1.Text += l[i] + "\n";

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonVertex.Enabled = false;
            buttonEdge.Enabled = true;
            button4.Enabled = true;
            //countDeleteVertex = 0;
            matrixTruth = new int[0, 0];
            vertex.Clear();
            edge.Clear();
            try
            {
                g.Clear(Color.White);
            }
            catch
            {

            }      
            indexVertex = 0;
        }

        private void button3_Click(object sender, EventArgs e)//циклы
        {
            button1_Click(sender, e);
            richTextBox1.Clear();
            List<string> l = Graph.VertixSubGraphs(ref matrixTruth);

            List<string>  answer = Graph.Cycles(l, ref matrixTruth);

            if (answer.Count == 0)
            {
                richTextBox1.Text += "Циклов нет ";
            }
            for (int i = 0; i < answer.Count; i++)
            {
                richTextBox1.Text += answer[i] + "\n";

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            buttonFindPath.Enabled = true;
            buttonVertex.Enabled = true;
            buttonEdge.Enabled = true;
            
        }

        private void buttonFindPath_Click(object sender, EventArgs e)
        {
            buttonMatrixTrueth_Click(sender, e);
            buttonFindPath.Enabled = false;
            buttonVertex.Enabled = true;
            buttonEdge.Enabled = true;
            button4.Enabled = true;
            
        }

        private void buttonRTextBoxClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }

    public class Vertex
    {
        public int x;
        public int y;
        public int index;

        public static void DeletVertex(ref List<Vertex> vertex, ref List<Edge> edge, ref int index1)
        {
            List<Edge> Edelete = new List<Edge>();

            for (int i = 0; i < edge.Count; i++)
            {
                if (edge[i].v1.index == index1 || edge[i].v2.index == index1)
                {
                    Edelete.Add(edge[i]);
                }
            }

            for (int i = 0; i < Edelete.Count; i++)
            {
                edge.Remove(Edelete[i]);
            }

            Vertex delete = vertex[index1];
            vertex.Remove(delete);
            
        }
        public static bool CollissionChek(ref List<Vertex> vertex, Vertex vNew , int radius)
        {
            Vertex center = new Vertex();
            foreach (Vertex item in vertex)
            {
                center.x = item.x - 6;
                center.y = item.y - 10;

                if ( ((vNew.x - center.x) * (vNew.x - center.x)) + 
                    ((vNew.y - center.y) * (vNew.y - center.y)) <= (radius + 30) * (radius + 30))
                {
                    return false;
                }

            }

            return true;
        }
    }

    public class Edge
    {
        public Vertex v1;
        public Vertex v2;

        public static string Path(ref int index1, ref int index2, int[,] matrixTrueth)
        {

            //List<string> paths = new List<string>();
            //List<int> pastVertex = new List<int>();
            string path = "";
            for (int j = 0; j < matrixTrueth.GetLength(0); j++)
            {
                if (matrixTrueth[index1, j] == 1)
                {
                    path = "";
                    //pastVertex.Clear();

                    matrixTrueth[index1, j] = 0;
                    
                    path += index1;
                    path += "-" + j;

                    matrixTrueth[index1, j] = 0;
                    matrixTrueth[j, index1] = 0;

                    PathNext(ref index1, ref index2, ref matrixTrueth, j, ref path);


                    
                    char[] c = path.ToCharArray();
                    int start = int.Parse((c[0]).ToString());
                    int end = int.Parse((c[c.Length - 1]).ToString());
                    if ( start == index1 &&  end == index2)
                    {
                        return path;
                    }
                }
            }
            return path;

        }

        public static void PathNext(ref int index1, ref int index2, ref int[,] matrixTrueth, int i , ref string path)
        {
            
            for (int j = 0; j < matrixTrueth.GetLength(0); j++)
            {
                

                if (matrixTrueth[i, index2] == 1)
                {
                    path += "-" + index2;
                   
                    break;
                }
                else if (matrixTrueth[i, j] == 1)
                {
                    matrixTrueth[i, j] = 0;
                    matrixTrueth[j, i] = 0;
                    path += "-" + j;
                    PathNext(ref index1, ref index2, ref matrixTrueth, j, ref path);
                }
            }




        }

        public static bool ChoiseVertex(ref int index1, ref int index2, ref List<Vertex> vertex, MouseEventArgs e, ref Vertex start, ref Vertex end, ref Graphics gg, int radius)
        {
            
            Pen pin = new Pen(Color.Red);
            Vertex center = new Vertex();
            Point click = e.Location;
            //сохранение в индекс?
            int i = 0;
            foreach (Vertex item in vertex)
            {
                center.x = item.x - 6;
                center.y = item.y - 10;
                center.index = item.index;
                if (((click.X - center.x) * (click.X - center.x)) +
                    ((click.Y - center.y) * (click.Y - center.y)) <= radius * radius)
                {
                    if (index1 == -1)
                    {
                        index1 = i;
                        start = center;
                        gg.FillEllipse(Brushes.Red, center.x, center.y, radius, radius);
                        return false;
                    }
                    else if (index2 == -1 && i != index1)
                    {
                        index2 = i;
                        end = center;
                        return true;
                    }
                }
                i++;
            }

            return false;
        }

        public static bool ChoiseVertexDelete(ref int index1, ref int index2, ref List<Vertex> vertex, MouseEventArgs e, ref Vertex start, ref Vertex end, ref Graphics gg, int radius)
        {

            Pen pin = new Pen(Color.Red);
            Vertex center = new Vertex();
            Point click = e.Location;
            //сохранение в индекс?
            int i = 0;
            foreach (Vertex item in vertex)
            {
                center.x = item.x - 6;
                center.y = item.y - 10;
                center.index = item.index;
                if (((click.X - center.x) * (click.X - center.x)) +
                    ((click.Y - center.y) * (click.Y - center.y)) <= radius * radius)
                {
                    if (index1 == -1)
                    {
                        index1 = i;
                        start = center;
                        gg.FillEllipse(Brushes.Red, center.x, center.y, radius, radius);
                        return true;
                    }
                    
                }
                i++;
            }

            return false;
        }
    }

    public class Draw : Form1
    {
        public static void DrawVertex(Graphics g, MouseEventArgs e, ref int indexVertex)
        {
            Pen pen = new Pen(Color.Black);
            Point click = e.Location;
            Font font = new Font("Arial", 6);

            g.FillEllipse(Brushes.White, (click.X - 6), (click.Y - 10), radius, radius);
            g.DrawEllipse(pen, click.X - 6, click.Y - 10, radius, radius);
            //g.DrawEllipse(pen, click.X, click.Y, 50, 20);
           
            g.DrawString(indexVertex.ToString(), font, Brushes.Green, click.X + 6, click.Y );
            indexVertex++;
        }
        public static void DrawVertexArray(Graphics g, int x, int y, int indexVertex)
        {
            Pen pen = new Pen(Color.Black);
            
            Font font = new Font("Arial", 6);

            g.FillEllipse(Brushes.White, (x - 6), (y - 10), radius, radius);
            g.DrawEllipse(pen, x - 6, y - 10, radius, radius);
            //g.DrawEllipse(pen, click.X, click.Y, 50, 20);

            g.DrawString(indexVertex.ToString(), font, Brushes.Green, x + 6, y);
            indexVertex++;
        }
        public static void DrawEdge(Graphics g, MouseEventArgs e, ref int indexVertexBegin,
            ref int indexVertexEnd, ref List<Vertex> vertex, ref Vertex start, ref Vertex end)
        {
            Pen pen = new Pen(Color.Black);
            Font font = new Font("Arial", 6);



            g.DrawLine(pen, start.x + 6, start.y + 10, end.x + 6, end.y + 10);
            

            int i = 0;
            foreach (Vertex v in vertex)
            {
                
                
                

                g.FillEllipse(Brushes.White, (v.x - 6), (v.y - 10), radius, radius);
                g.DrawEllipse(pen, v.x - 6, v.y - 10, radius, radius);
                g.DrawString(i.ToString(), font, Brushes.Green, v.x + 6, v.y);
                i++;
            }
            
            
        }

        

        public static void matrixTrueth(int[,] matrixTrueth, RichTextBox richTextBox1)
        {
            
            string line = "   ";
            for (int i = 0; i < matrixTrueth.GetLength(0); i++)
            {
                line += $"{i} ";
            }
            
            richTextBox1.Text += line + "\n";
            

            for (int i = 0; i < matrixTrueth.GetLength(0); i++)
            {
                line = $"{i} ";
                for (int j = 0; j < matrixTrueth.GetLength(1); j++)
                {
                    line += matrixTrueth[i, j] + " ";
                }
                richTextBox1.Text += line + "\n";
            }
            
        }

    }

    public class Graph
    {
        public static void MakeMatrixTruth(ref List<Edge> edges, ref List<Vertex> vertex, ref int[,] matrixTruth)
        {
            foreach (Edge edge in edges)
            {
                matrixTruth[edge.v1.index, edge.v2.index] = 1;
                matrixTruth[edge.v2.index, edge.v1.index] = 1;

            }
        }

        public static string VertixDegree(ref int[,] matrixTrueth)
        {
            string answer = "";
            int count = 0;
            int countEven = 0;
            int countOdd = 0;
            int sum = 0;
            for (int i = 0; i < matrixTrueth.GetLength(0); i++)
            {
                count = 0;
                for (int j = 0; j < matrixTrueth.GetLength(1); j++)
                {
                    if (matrixTrueth[i,j] == 1)
                    {
                        count++;
                    }
                }
                sum += count;
                answer += $"Степень вершины {i} = {count}\n";
                if (count%2 == 0)
                {
                    countEven++;
                }
                else
                {
                    countOdd++;
                }
            }
            answer += $"Сумма степеней вершин = {sum}\n";
            answer += $"Кол-во чётных степеней вершин = {countEven}\n";
            answer += $"Кол-во нечётных степеней вершин = {countOdd}\n";
            return answer;
        }

        public static List<string> Cycles(List<string> SubGraphs, ref int[,] matrixTruth)
        {
            List<string> cycles = new List<string>();

            for (int i = 0; i < SubGraphs.Count; i++)
            {
                string s = SubGraphs[i];
                char[] c = SubGraphs[i].ToCharArray();
                if (c.Length < 5)
                {
                    continue;
                }
                int ii = int.Parse(c[0].ToString());
                int j = int.Parse(c[c.Length - 1].ToString());
                if (matrixTruth[ii, j] == 1)
                {
                    s += "-" + c[0];
                    cycles.Add(s);
                }
                
            }

            return cycles;
        }
        public static List<string> VertixSubGraphs(ref int[,] matrixTrueth)
        {


            //string[] SubGraphs = new string[(int)Math.Pow(matrixTrueth.GetLength(0), matrixTrueth.GetLength(0))];
            List<string> SubGraphs = new List<string>();

            string path = "";
            List<int> pastVertex = new List<int>();
            for (int i = 0; i < matrixTrueth.GetLength(0); i++)
            {
                pastVertex.Clear();

                PathMax(ref matrixTrueth, ref path, ref pastVertex, i);
                if (path.Length > 1)
                {
                    SubGraphs.Add(path);
                }
                
                path = "";
            }

            int Count = SubGraphs.Count;

            //получаем перевернутые максимальные пути
            for (int i = 0; i < Count; i++)
            {
                char[] c = SubGraphs[i].ToCharArray();
                Array.Reverse(c);
                string s = new String(c);
                if (s.Length > 1)
                {
                    SubGraphs.Add(s);
                }
                
            }

            //получем сокращенные пути с начала 1-2-3 => 1-2
            Count = SubGraphs.Count;
            for (int i = 0; i < Count; i++)
            {
                char[] c = SubGraphs[i].ToCharArray();
                string s = "";
                for (int j = 0; j < c.GetLength(0); j++)
                {
                    s += c[j];
                    if (s.Length > 1 && s.Length < c.Length)
                    {
                        SubGraphs.Add(s);
                    }
                }
                
                
            }
            //получем сокращенные пути с конца 1-2-3 => 3-2
            Count = SubGraphs.Count;
            for (int i = 0; i < Count; i++)
            {
                char[] c = SubGraphs[i].ToCharArray();
                string s = "";
                for (int j = 0; j > 0; j--)
                {
                    s += c[j];
                    if (s.Length > 1 && s.Length < c.Length)
                    {
                        SubGraphs.Add(s);
                    }
                }


            }

            Count = SubGraphs.Count;
            for (int i = 0; i < Count; i++)
            {
                char[] c = SubGraphs[i].ToCharArray();
                Array.Reverse(c);
                string s = new String(c);
                SubGraphs.Add(s);
            }

            List<string> SubGraphsVBeautiful = new List<string>();
            for (int i = 0; i < SubGraphs.Count; i++)
            {
                char[] c = SubGraphs[i].ToCharArray();
                string s = "";
                for (int j = 0; j < c.GetLength(0); j++)
                {
                    s += c[j];
                    if (j < c.GetLength(0) - 1)
                    {
                        s += "-";
                    }
                }
                SubGraphsVBeautiful.Add(s);
            }

            SubGraphsVBeautiful = SubGraphsVBeautiful.Distinct().ToList();
            return SubGraphsVBeautiful;
        }
        public static void PathMax(ref int[,] matrixTrueth, ref string path, ref List<int> pastVertex, int i)
        {

            for (int j = 0; j < matrixTrueth.GetLength(1); j++)
            {
                if (matrixTrueth[i, j] == 1 && !pastVertex.Contains(j))
                {
                    if (path.Length == 0)
                    {
                        path += (i);
                    }
                    
                    path += (j);
                    pastVertex.Add(i);
                    PathMax(ref matrixTrueth, ref path, ref pastVertex, j);
                    break;
                }
            }


        }
    }

}
