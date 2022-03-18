namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonVertex = new System.Windows.Forms.Button();
            this.buttonEdge = new System.Windows.Forms.Button();
            this.buttonMatrixTrueth = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonVertixDeggree = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonFindPath = new System.Windows.Forms.Button();
            this.buttonRTextBoxClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(94, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(476, 426);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // buttonVertex
            // 
            this.buttonVertex.Location = new System.Drawing.Point(4, 12);
            this.buttonVertex.Name = "buttonVertex";
            this.buttonVertex.Size = new System.Drawing.Size(78, 40);
            this.buttonVertex.TabIndex = 1;
            this.buttonVertex.Text = "Вершина";
            this.buttonVertex.UseVisualStyleBackColor = true;
            this.buttonVertex.Click += new System.EventHandler(this.buttonVertex_Click);
            // 
            // buttonEdge
            // 
            this.buttonEdge.Location = new System.Drawing.Point(4, 58);
            this.buttonEdge.Name = "buttonEdge";
            this.buttonEdge.Size = new System.Drawing.Size(78, 40);
            this.buttonEdge.TabIndex = 2;
            this.buttonEdge.Text = "Ребро";
            this.buttonEdge.UseVisualStyleBackColor = true;
            this.buttonEdge.Click += new System.EventHandler(this.buttonEdge_Click);
            // 
            // buttonMatrixTrueth
            // 
            this.buttonMatrixTrueth.Location = new System.Drawing.Point(576, 300);
            this.buttonMatrixTrueth.Name = "buttonMatrixTrueth";
            this.buttonMatrixTrueth.Size = new System.Drawing.Size(211, 44);
            this.buttonMatrixTrueth.TabIndex = 3;
            this.buttonMatrixTrueth.Text = "Сделать таблицу смежности";
            this.buttonMatrixTrueth.UseVisualStyleBackColor = true;
            this.buttonMatrixTrueth.Click += new System.EventHandler(this.buttonMatrixTrueth_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(576, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(212, 234);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // buttonVertixDeggree
            // 
            this.buttonVertixDeggree.Location = new System.Drawing.Point(576, 350);
            this.buttonVertixDeggree.Name = "buttonVertixDeggree";
            this.buttonVertixDeggree.Size = new System.Drawing.Size(87, 87);
            this.buttonVertixDeggree.TabIndex = 5;
            this.buttonVertixDeggree.Text = "Степени вершин";
            this.buttonVertixDeggree.UseVisualStyleBackColor = true;
            this.buttonVertixDeggree.Click += new System.EventHandler(this.buttonVertixDeggree_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(671, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Подграфы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 368);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 69);
            this.button2.TabIndex = 7;
            this.button2.Text = "Очистить граф";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(671, 397);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 40);
            this.button3.TabIndex = 8;
            this.button3.Text = "Циклы";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(4, 122);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 47);
            this.button4.TabIndex = 9;
            this.button4.Text = "Удалить вершину";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonFindPath
            // 
            this.buttonFindPath.Location = new System.Drawing.Point(4, 253);
            this.buttonFindPath.Name = "buttonFindPath";
            this.buttonFindPath.Size = new System.Drawing.Size(78, 58);
            this.buttonFindPath.TabIndex = 10;
            this.buttonFindPath.Text = "Найти путь";
            this.buttonFindPath.UseVisualStyleBackColor = true;
            this.buttonFindPath.Click += new System.EventHandler(this.buttonFindPath_Click);
            // 
            // buttonRTextBoxClear
            // 
            this.buttonRTextBoxClear.Location = new System.Drawing.Point(577, 253);
            this.buttonRTextBoxClear.Name = "buttonRTextBoxClear";
            this.buttonRTextBoxClear.Size = new System.Drawing.Size(211, 41);
            this.buttonRTextBoxClear.TabIndex = 11;
            this.buttonRTextBoxClear.Text = "Очистить поле";
            this.buttonRTextBoxClear.UseVisualStyleBackColor = true;
            this.buttonRTextBoxClear.Click += new System.EventHandler(this.buttonRTextBoxClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRTextBoxClear);
            this.Controls.Add(this.buttonFindPath);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonVertixDeggree);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonMatrixTrueth);
            this.Controls.Add(this.buttonEdge);
            this.Controls.Add(this.buttonVertex);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonVertex;
        private System.Windows.Forms.Button buttonEdge;
        private System.Windows.Forms.Button buttonMatrixTrueth;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonVertixDeggree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonFindPath;
        private System.Windows.Forms.Button buttonRTextBoxClear;
    }
}

