namespace Sedelnikov_4
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BubbleSortStatus = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label3 = new System.Windows.Forms.Label();
            this.InsertsSortStatus = new System.Windows.Forms.RadioButton();
            this.ShakerSortStatus = new System.Windows.Forms.RadioButton();
            this.FastSortStatus = new System.Windows.Forms.RadioButton();
            this.BogoSortStatus = new System.Windows.Forms.RadioButton();
            this.ReversStatus = new System.Windows.Forms.CheckBox();
            this.Table = new System.Windows.Forms.DataGridView();
            this.PauseBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.Point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Chart
            // 
            chartArea2.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea2);
            this.Chart.Location = new System.Drawing.Point(13, 13);
            this.Chart.Name = "Chart";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series2.Name = "Series1";
            series2.YValuesPerPoint = 4;
            this.Chart.Series.Add(series2);
            this.Chart.Size = new System.Drawing.Size(432, 425);
            this.Chart.TabIndex = 0;
            this.Chart.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(464, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Лабораторная работа №4 // Седельников Петр ПИ-211(2)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(464, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(401, 64);
            this.label2.TabIndex = 4;
            this.label2.Text = "Определить какой из методов сортировки данных является \r\nбыстрым. Предусмотреть с" +
    "ортировку по возрастанию и\r\nубыванию. Вывести время каждого выбранного алгоритма" +
    " \r\nсортировки на экран.";
            // 
            // BubbleSortStatus
            // 
            this.BubbleSortStatus.AutoSize = true;
            this.BubbleSortStatus.Checked = true;
            this.BubbleSortStatus.Location = new System.Drawing.Point(468, 153);
            this.BubbleSortStatus.Name = "BubbleSortStatus";
            this.BubbleSortStatus.Size = new System.Drawing.Size(156, 17);
            this.BubbleSortStatus.TabIndex = 5;
            this.BubbleSortStatus.TabStop = true;
            this.BubbleSortStatus.Text = "Пузырьковая сортировка";
            this.BubbleSortStatus.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(901, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(464, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Алгоритм сортировки:";
            // 
            // InsertsSortStatus
            // 
            this.InsertsSortStatus.AutoSize = true;
            this.InsertsSortStatus.Location = new System.Drawing.Point(468, 176);
            this.InsertsSortStatus.Name = "InsertsSortStatus";
            this.InsertsSortStatus.Size = new System.Drawing.Size(143, 17);
            this.InsertsSortStatus.TabIndex = 8;
            this.InsertsSortStatus.Text = "Сортировка вставками";
            this.InsertsSortStatus.UseVisualStyleBackColor = true;
            // 
            // ShakerSortStatus
            // 
            this.ShakerSortStatus.AutoSize = true;
            this.ShakerSortStatus.Location = new System.Drawing.Point(468, 199);
            this.ShakerSortStatus.Name = "ShakerSortStatus";
            this.ShakerSortStatus.Size = new System.Drawing.Size(144, 17);
            this.ShakerSortStatus.TabIndex = 9;
            this.ShakerSortStatus.Text = "Шейкерная сортировка";
            this.ShakerSortStatus.UseVisualStyleBackColor = true;
            // 
            // FastSortStatus
            // 
            this.FastSortStatus.AutoSize = true;
            this.FastSortStatus.Location = new System.Drawing.Point(468, 222);
            this.FastSortStatus.Name = "FastSortStatus";
            this.FastSortStatus.Size = new System.Drawing.Size(131, 17);
            this.FastSortStatus.TabIndex = 10;
            this.FastSortStatus.Text = "Быстрая сортировка";
            this.FastSortStatus.UseVisualStyleBackColor = true;
            // 
            // BogoSortStatus
            // 
            this.BogoSortStatus.AutoSize = true;
            this.BogoSortStatus.Location = new System.Drawing.Point(468, 245);
            this.BogoSortStatus.Name = "BogoSortStatus";
            this.BogoSortStatus.Size = new System.Drawing.Size(119, 17);
            this.BogoSortStatus.TabIndex = 11;
            this.BogoSortStatus.Text = "Сортировка BOGO";
            this.BogoSortStatus.UseVisualStyleBackColor = true;
            // 
            // ReversStatus
            // 
            this.ReversStatus.AutoSize = true;
            this.ReversStatus.Location = new System.Drawing.Point(467, 268);
            this.ReversStatus.Name = "ReversStatus";
            this.ReversStatus.Size = new System.Drawing.Size(63, 17);
            this.ReversStatus.TabIndex = 12;
            this.ReversStatus.Text = "Реверс";
            this.ReversStatus.UseVisualStyleBackColor = true;
            // 
            // Table
            // 
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Point});
            this.Table.Location = new System.Drawing.Point(702, 134);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(176, 291);
            this.Table.TabIndex = 13;
            this.Table.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableAddPoint);
            // 
            // PauseBar
            // 
            this.PauseBar.Location = new System.Drawing.Point(467, 330);
            this.PauseBar.Maximum = 1000;
            this.PauseBar.Name = "PauseBar";
            this.PauseBar.Size = new System.Drawing.Size(204, 45);
            this.PauseBar.TabIndex = 14;
            this.PauseBar.TickFrequency = 100;
            this.PauseBar.Value = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(464, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Задержка:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(474, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(657, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "1";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(467, 381);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 44);
            this.StartButton.TabIndex = 18;
            this.StartButton.Text = "Начать";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(573, 381);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(98, 44);
            this.ClearButton.TabIndex = 19;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Point
            // 
            this.Point.FillWeight = 133F;
            this.Point.HeaderText = "Точка";
            this.Point.Name = "Point";
            this.Point.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Point.Width = 133;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 450);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PauseBar);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.ReversStatus);
            this.Controls.Add(this.BogoSortStatus);
            this.Controls.Add(this.FastSortStatus);
            this.Controls.Add(this.ShakerSortStatus);
            this.Controls.Add(this.InsertsSortStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.BubbleSortStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Chart);
            this.Name = "Form1";
            this.Text = "Лабораторная работа №4 // Седельников Петр ПИ-211(2)";
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton BubbleSortStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton InsertsSortStatus;
        private System.Windows.Forms.RadioButton ShakerSortStatus;
        private System.Windows.Forms.RadioButton FastSortStatus;
        private System.Windows.Forms.RadioButton BogoSortStatus;
        private System.Windows.Forms.CheckBox ReversStatus;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.TrackBar PauseBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point;
    }
}

