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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BubbleChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label3 = new System.Windows.Forms.Label();
            this.ReversStatus = new System.Windows.Forms.CheckBox();
            this.Table = new System.Windows.Forms.DataGridView();
            this.Point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PauseBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.InsertsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.FastChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ShakerChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BogoChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BubbleStatus = new System.Windows.Forms.CheckBox();
            this.InsertsStatus = new System.Windows.Forms.CheckBox();
            this.ShakerStatus = new System.Windows.Forms.CheckBox();
            this.FastStatus = new System.Windows.Forms.CheckBox();
            this.BogoStatus = new System.Windows.Forms.CheckBox();
            this.BubbleResultLine = new System.Windows.Forms.Label();
            this.InsertsResultLine = new System.Windows.Forms.Label();
            this.GenerateDataButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ShakerResultLine = new System.Windows.Forms.Label();
            this.FastResultLine = new System.Windows.Forms.Label();
            this.BogoResultLine = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BubbleChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsertsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FastChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShakerChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BogoChart)).BeginInit();
            this.SuspendLayout();
            // 
            // BubbleChart
            // 
            chartArea1.Name = "ChartArea1";
            this.BubbleChart.ChartAreas.Add(chartArea1);
            this.BubbleChart.Location = new System.Drawing.Point(13, 13);
            this.BubbleChart.Name = "BubbleChart";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            this.BubbleChart.Series.Add(series1);
            this.BubbleChart.Size = new System.Drawing.Size(215, 157);
            this.BubbleChart.TabIndex = 0;
            this.BubbleChart.Text = "chart1";
            this.BubbleChart.Click += new System.EventHandler(this.Chart_Click);
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
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 489);
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
            // ReversStatus
            // 
            this.ReversStatus.AutoSize = true;
            this.ReversStatus.Location = new System.Drawing.Point(470, 287);
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
            this.Table.Size = new System.Drawing.Size(176, 292);
            this.Table.TabIndex = 13;
            this.Table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_CellContentClick);
            this.Table.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableAddPoint);
            // 
            // Point
            // 
            this.Point.FillWeight = 133F;
            this.Point.HeaderText = "Точка";
            this.Point.Name = "Point";
            this.Point.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Point.Width = 133;
            // 
            // PauseBar
            // 
            this.PauseBar.Location = new System.Drawing.Point(467, 357);
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
            this.label4.Location = new System.Drawing.Point(464, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Задержка:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(476, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(657, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "1";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(467, 451);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 44);
            this.StartButton.TabIndex = 18;
            this.StartButton.Text = "Начать";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Enabled = false;
            this.ClearButton.Location = new System.Drawing.Point(573, 451);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(98, 44);
            this.ClearButton.TabIndex = 19;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // InsertsChart
            // 
            chartArea2.Name = "ChartArea1";
            this.InsertsChart.ChartAreas.Add(chartArea2);
            this.InsertsChart.Location = new System.Drawing.Point(234, 13);
            this.InsertsChart.Name = "InsertsChart";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series2.Name = "Series1";
            series2.YValuesPerPoint = 4;
            this.InsertsChart.Series.Add(series2);
            this.InsertsChart.Size = new System.Drawing.Size(210, 157);
            this.InsertsChart.TabIndex = 20;
            this.InsertsChart.Text = "chart1";
            // 
            // FastChart
            // 
            chartArea3.Name = "ChartArea1";
            this.FastChart.ChartAreas.Add(chartArea3);
            this.FastChart.Location = new System.Drawing.Point(234, 176);
            this.FastChart.Name = "FastChart";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series3.Name = "Series1";
            series3.YValuesPerPoint = 4;
            this.FastChart.Series.Add(series3);
            this.FastChart.Size = new System.Drawing.Size(210, 157);
            this.FastChart.TabIndex = 22;
            this.FastChart.Text = "chart1";
            // 
            // ShakerChart
            // 
            chartArea4.Name = "ChartArea1";
            this.ShakerChart.ChartAreas.Add(chartArea4);
            this.ShakerChart.Location = new System.Drawing.Point(12, 176);
            this.ShakerChart.Name = "ShakerChart";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series4.Name = "Series1";
            series4.YValuesPerPoint = 4;
            this.ShakerChart.Series.Add(series4);
            this.ShakerChart.Size = new System.Drawing.Size(215, 157);
            this.ShakerChart.TabIndex = 21;
            this.ShakerChart.Text = "chart1";
            // 
            // BogoChart
            // 
            chartArea5.Name = "ChartArea1";
            this.BogoChart.ChartAreas.Add(chartArea5);
            this.BogoChart.Location = new System.Drawing.Point(13, 339);
            this.BogoChart.Name = "BogoChart";
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series5.Name = "Series1";
            series5.YValuesPerPoint = 4;
            this.BogoChart.Series.Add(series5);
            this.BogoChart.Size = new System.Drawing.Size(431, 157);
            this.BogoChart.TabIndex = 23;
            this.BogoChart.Text = "chart1";
            // 
            // BubbleStatus
            // 
            this.BubbleStatus.AutoSize = true;
            this.BubbleStatus.Location = new System.Drawing.Point(470, 157);
            this.BubbleStatus.Name = "BubbleStatus";
            this.BubbleStatus.Size = new System.Drawing.Size(157, 17);
            this.BubbleStatus.TabIndex = 24;
            this.BubbleStatus.Text = "Пузырьковая сортировка";
            this.BubbleStatus.UseVisualStyleBackColor = true;
            // 
            // InsertsStatus
            // 
            this.InsertsStatus.AutoSize = true;
            this.InsertsStatus.Location = new System.Drawing.Point(470, 180);
            this.InsertsStatus.Name = "InsertsStatus";
            this.InsertsStatus.Size = new System.Drawing.Size(144, 17);
            this.InsertsStatus.TabIndex = 25;
            this.InsertsStatus.Text = "Сортировка вставками";
            this.InsertsStatus.UseVisualStyleBackColor = true;
            // 
            // ShakerStatus
            // 
            this.ShakerStatus.AutoSize = true;
            this.ShakerStatus.Location = new System.Drawing.Point(470, 204);
            this.ShakerStatus.Name = "ShakerStatus";
            this.ShakerStatus.Size = new System.Drawing.Size(145, 17);
            this.ShakerStatus.TabIndex = 26;
            this.ShakerStatus.Text = "Шейкерная сортировка";
            this.ShakerStatus.UseVisualStyleBackColor = true;
            // 
            // FastStatus
            // 
            this.FastStatus.AutoSize = true;
            this.FastStatus.Location = new System.Drawing.Point(470, 226);
            this.FastStatus.Name = "FastStatus";
            this.FastStatus.Size = new System.Drawing.Size(132, 17);
            this.FastStatus.TabIndex = 27;
            this.FastStatus.Text = "Быстрая сортировка";
            this.FastStatus.UseVisualStyleBackColor = true;
            // 
            // BogoStatus
            // 
            this.BogoStatus.AutoSize = true;
            this.BogoStatus.Location = new System.Drawing.Point(470, 249);
            this.BogoStatus.Name = "BogoStatus";
            this.BogoStatus.Size = new System.Drawing.Size(120, 17);
            this.BogoStatus.TabIndex = 28;
            this.BogoStatus.Text = "Сортировка BOGO";
            this.BogoStatus.UseVisualStyleBackColor = true;
            // 
            // BubbleResultLine
            // 
            this.BubbleResultLine.AutoSize = true;
            this.BubbleResultLine.Location = new System.Drawing.Point(630, 160);
            this.BubbleResultLine.Name = "BubbleResultLine";
            this.BubbleResultLine.Size = new System.Drawing.Size(0, 13);
            this.BubbleResultLine.TabIndex = 29;
            // 
            // InsertsResultLine
            // 
            this.InsertsResultLine.AutoSize = true;
            this.InsertsResultLine.Location = new System.Drawing.Point(615, 180);
            this.InsertsResultLine.Name = "InsertsResultLine";
            this.InsertsResultLine.Size = new System.Drawing.Size(0, 13);
            this.InsertsResultLine.TabIndex = 30;
            // 
            // GenerateDataButton
            // 
            this.GenerateDataButton.Location = new System.Drawing.Point(702, 451);
            this.GenerateDataButton.Name = "GenerateDataButton";
            this.GenerateDataButton.Size = new System.Drawing.Size(176, 44);
            this.GenerateDataButton.TabIndex = 31;
            this.GenerateDataButton.Text = "Сгенерировать данные";
            this.GenerateDataButton.UseVisualStyleBackColor = true;
            this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
            // 
            // ShakerResultLine
            // 
            this.ShakerResultLine.AutoSize = true;
            this.ShakerResultLine.Location = new System.Drawing.Point(614, 204);
            this.ShakerResultLine.Name = "ShakerResultLine";
            this.ShakerResultLine.Size = new System.Drawing.Size(0, 13);
            this.ShakerResultLine.TabIndex = 32;
            // 
            // FastResultLine
            // 
            this.FastResultLine.AutoSize = true;
            this.FastResultLine.Location = new System.Drawing.Point(608, 230);
            this.FastResultLine.Name = "FastResultLine";
            this.FastResultLine.Size = new System.Drawing.Size(0, 13);
            this.FastResultLine.TabIndex = 33;
            // 
            // BogoResultLine
            // 
            this.BogoResultLine.AutoSize = true;
            this.BogoResultLine.Location = new System.Drawing.Point(596, 249);
            this.BogoResultLine.Name = "BogoResultLine";
            this.BogoResultLine.Size = new System.Drawing.Size(0, 13);
            this.BogoResultLine.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 511);
            this.Controls.Add(this.BogoResultLine);
            this.Controls.Add(this.FastResultLine);
            this.Controls.Add(this.ShakerResultLine);
            this.Controls.Add(this.GenerateDataButton);
            this.Controls.Add(this.InsertsResultLine);
            this.Controls.Add(this.BubbleResultLine);
            this.Controls.Add(this.BogoStatus);
            this.Controls.Add(this.FastStatus);
            this.Controls.Add(this.ShakerStatus);
            this.Controls.Add(this.InsertsStatus);
            this.Controls.Add(this.BubbleStatus);
            this.Controls.Add(this.BogoChart);
            this.Controls.Add(this.FastChart);
            this.Controls.Add(this.ShakerChart);
            this.Controls.Add(this.InsertsChart);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PauseBar);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.ReversStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BubbleChart);
            this.Name = "Form1";
            this.Text = "Лабораторная работа №4 // Седельников Петр ПИ-211(2)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BubbleChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsertsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FastChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShakerChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BogoChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart BubbleChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ReversStatus;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.TrackBar PauseBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point;
        private System.Windows.Forms.DataVisualization.Charting.Chart InsertsChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart FastChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ShakerChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart BogoChart;
        private System.Windows.Forms.CheckBox BubbleStatus;
        private System.Windows.Forms.CheckBox InsertsStatus;
        private System.Windows.Forms.CheckBox ShakerStatus;
        private System.Windows.Forms.CheckBox FastStatus;
        private System.Windows.Forms.CheckBox BogoStatus;
        private System.Windows.Forms.Label BubbleResultLine;
        private System.Windows.Forms.Label InsertsResultLine;
        private System.Windows.Forms.Button GenerateDataButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label ShakerResultLine;
        private System.Windows.Forms.Label FastResultLine;
        private System.Windows.Forms.Label BogoResultLine;
    }
}

