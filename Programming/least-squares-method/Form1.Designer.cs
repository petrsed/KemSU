namespace Sedelnikov_3
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
            this.Table = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Рассчитать = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Answer = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Graphic = new OxyPlot.WindowsForms.PlotView();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // Table
            // 
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this.Table.Location = new System.Drawing.Point(588, 12);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(312, 426);
            this.Table.TabIndex = 1;
            this.Table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.Table.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.Table.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableAddPoint);
            this.Table.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.TableAddRow);
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.Width = 135;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.Width = 134;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(19, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(573, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Лабораторная работа №3 // Седельников Петр ПИ-211(2)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(19, 494);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(864, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Используя метод наименьших квадратов на множестве точек, найти коэффициенты функц" +
    "ии ";
            // 
            // Рассчитать
            // 
            this.Рассчитать.Location = new System.Drawing.Point(23, 531);
            this.Рассчитать.Name = "Рассчитать";
            this.Рассчитать.Size = new System.Drawing.Size(132, 42);
            this.Рассчитать.TabIndex = 4;
            this.Рассчитать.Text = "Линейная";
            this.Рассчитать.UseVisualStyleBackColor = true;
            this.Рассчитать.Click += new System.EventHandler(this.CalculateButton);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(299, 531);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Answer
            // 
            this.Answer.AutoSize = true;
            this.Answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Answer.Location = new System.Drawing.Point(453, 538);
            this.Answer.Name = "Answer";
            this.Answer.Size = new System.Drawing.Size(0, 24);
            this.Answer.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(161, 531);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 42);
            this.button2.TabIndex = 7;
            this.button2.Text = "Квадратичная";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.QuadraticCalculate);
            // 
            // Graphic
            // 
            this.Graphic.Location = new System.Drawing.Point(12, 12);
            this.Graphic.Name = "Graphic";
            this.Graphic.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.Graphic.Size = new System.Drawing.Size(557, 426);
            this.Graphic.TabIndex = 8;
            this.Graphic.Text = "plotView1";
            this.Graphic.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.Graphic.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.Graphic.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 594);
            this.Controls.Add(this.Graphic);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Answer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Рассчитать);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Table);
            this.Name = "Form1";
            this.Text = "Лабораторная работа №3 // Седельников Петр";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.Button Рассчитать;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Answer;
        private System.Windows.Forms.Button button2;
        private OxyPlot.WindowsForms.PlotView Graphic;
    }
}

