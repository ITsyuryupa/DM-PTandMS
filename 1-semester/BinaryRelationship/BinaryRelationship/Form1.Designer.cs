namespace BinaryRelationship
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
            this.dataGridViewRelationship = new System.Windows.Forms.DataGridView();
            this.buttonChoseSet = new System.Windows.Forms.Button();
            this.comboBox1Set = new System.Windows.Forms.ComboBox();
            this.buttonFillData = new System.Windows.Forms.Button();
            this.textBoxEnterSet = new System.Windows.Forms.TextBox();
            this.checkedListBoxSetProp = new System.Windows.Forms.CheckedListBox();
            this.richTextBoxEClass = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonFillDataAdditional = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelationship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRelationship
            // 
            this.dataGridViewRelationship.AllowUserToAddRows = false;
            this.dataGridViewRelationship.AllowUserToDeleteRows = false;
            this.dataGridViewRelationship.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRelationship.Location = new System.Drawing.Point(15, 11);
            this.dataGridViewRelationship.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewRelationship.Name = "dataGridViewRelationship";
            this.dataGridViewRelationship.RowTemplate.Height = 24;
            this.dataGridViewRelationship.Size = new System.Drawing.Size(484, 148);
            this.dataGridViewRelationship.TabIndex = 0;
            this.dataGridViewRelationship.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRelationship_CellContentClick);
            this.dataGridViewRelationship.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellValueChanged);
            // 
            // buttonChoseSet
            // 
            this.buttonChoseSet.Location = new System.Drawing.Point(504, 53);
            this.buttonChoseSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonChoseSet.Name = "buttonChoseSet";
            this.buttonChoseSet.Size = new System.Drawing.Size(155, 38);
            this.buttonChoseSet.TabIndex = 1;
            this.buttonChoseSet.Text = "Ввести множество";
            this.buttonChoseSet.UseVisualStyleBackColor = true;
            this.buttonChoseSet.Click += new System.EventHandler(this.buttonChoseSet_Click);
            // 
            // comboBox1Set
            // 
            this.comboBox1Set.FormattingEnabled = true;
            this.comboBox1Set.Location = new System.Drawing.Point(504, 11);
            this.comboBox1Set.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1Set.Name = "comboBox1Set";
            this.comboBox1Set.Size = new System.Drawing.Size(121, 24);
            this.comboBox1Set.TabIndex = 2;
            this.comboBox1Set.SelectedIndexChanged += new System.EventHandler(this.comboBox1Set_SelectedIndexChanged);
            // 
            // buttonFillData
            // 
            this.buttonFillData.Location = new System.Drawing.Point(505, 99);
            this.buttonFillData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFillData.Name = "buttonFillData";
            this.buttonFillData.Size = new System.Drawing.Size(154, 59);
            this.buttonFillData.TabIndex = 3;
            this.buttonFillData.Text = "Ввести отношение";
            this.buttonFillData.UseVisualStyleBackColor = true;
            this.buttonFillData.Click += new System.EventHandler(this.buttonFillData_Click);
            // 
            // textBoxEnterSet
            // 
            this.textBoxEnterSet.Location = new System.Drawing.Point(689, 14);
            this.textBoxEnterSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEnterSet.Name = "textBoxEnterSet";
            this.textBoxEnterSet.Size = new System.Drawing.Size(157, 22);
            this.textBoxEnterSet.TabIndex = 4;
            this.textBoxEnterSet.TextChanged += new System.EventHandler(this.textBoxEnterSet_TextChanged);
            // 
            // checkedListBoxSetProp
            // 
            this.checkedListBoxSetProp.Enabled = false;
            this.checkedListBoxSetProp.FormattingEnabled = true;
            this.checkedListBoxSetProp.Location = new System.Drawing.Point(504, 165);
            this.checkedListBoxSetProp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBoxSetProp.Name = "checkedListBoxSetProp";
            this.checkedListBoxSetProp.Size = new System.Drawing.Size(252, 259);
            this.checkedListBoxSetProp.TabIndex = 5;
            // 
            // richTextBoxEClass
            // 
            this.richTextBoxEClass.Location = new System.Drawing.Point(783, 165);
            this.richTextBoxEClass.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxEClass.Name = "richTextBoxEClass";
            this.richTextBoxEClass.Size = new System.Drawing.Size(435, 155);
            this.richTextBoxEClass.TabIndex = 6;
            this.richTextBoxEClass.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 165);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(484, 113);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // buttonFillDataAdditional
            // 
            this.buttonFillDataAdditional.Location = new System.Drawing.Point(689, 99);
            this.buttonFillDataAdditional.Name = "buttonFillDataAdditional";
            this.buttonFillDataAdditional.Size = new System.Drawing.Size(157, 59);
            this.buttonFillDataAdditional.TabIndex = 8;
            this.buttonFillDataAdditional.Text = "Ввести дополнительное отношение";
            this.buttonFillDataAdditional.UseVisualStyleBackColor = true;
            this.buttonFillDataAdditional.Click += new System.EventHandler(this.buttonFillDataAdditional_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(15, 284);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(483, 218);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 514);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonFillDataAdditional);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.richTextBoxEClass);
            this.Controls.Add(this.checkedListBoxSetProp);
            this.Controls.Add(this.textBoxEnterSet);
            this.Controls.Add(this.buttonFillData);
            this.Controls.Add(this.comboBox1Set);
            this.Controls.Add(this.buttonChoseSet);
            this.Controls.Add(this.dataGridViewRelationship);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelationship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRelationship;
        private System.Windows.Forms.Button buttonChoseSet;
        private System.Windows.Forms.ComboBox comboBox1Set;
        private System.Windows.Forms.Button buttonFillData;
        private System.Windows.Forms.TextBox textBoxEnterSet;
        private System.Windows.Forms.CheckedListBox checkedListBoxSetProp;
        private System.Windows.Forms.RichTextBox richTextBoxEClass;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonFillDataAdditional;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

