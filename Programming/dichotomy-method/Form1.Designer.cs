namespace Sedelnikov_1._1
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
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.FunctionTextBox = new System.Windows.Forms.TextBox();
            this.StartTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EndTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AccuracyTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AnswerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Chart
            // 
            chartArea2.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea2);
            this.Chart.Location = new System.Drawing.Point(31, 36);
            this.Chart.Name = "Chart";
            this.Chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Red;
            series3.Name = "Series1";
            series4.BorderWidth = 8;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series4.LabelBorderWidth = 3;
            series4.Name = "NeedPoint";
            series4.YValuesPerPoint = 2;
            this.Chart.Series.Add(series3);
            this.Chart.Series.Add(series4);
            this.Chart.Size = new System.Drawing.Size(715, 300);
            this.Chart.TabIndex = 0;
            this.Chart.Text = "Chart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(535, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Лабораторная работа №1 // Седельников Петр ПИ-211(2)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(27, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(690, 46);
            this.label2.TabIndex = 2;
            this.label2.Text = "Используя метод половинного деления (дихотомии) найти локальный минимум \r\nзаданно" +
    "й точности e функции f(x) на интервале [a, b].";
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(31, 493);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(112, 37);
            this.CalculateButton.TabIndex = 3;
            this.CalculateButton.Text = "Рассчитать";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(27, 443);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "f(x):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FunctionTextBox
            // 
            this.FunctionTextBox.Location = new System.Drawing.Point(88, 447);
            this.FunctionTextBox.Name = "FunctionTextBox";
            this.FunctionTextBox.Size = new System.Drawing.Size(218, 20);
            this.FunctionTextBox.TabIndex = 6;
            // 
            // StartTextBox
            // 
            this.StartTextBox.Location = new System.Drawing.Point(369, 447);
            this.StartTextBox.Name = "StartTextBox";
            this.StartTextBox.Size = new System.Drawing.Size(75, 20);
            this.StartTextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(331, 443);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "a:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EndTextBox
            // 
            this.EndTextBox.Location = new System.Drawing.Point(498, 447);
            this.EndTextBox.Name = "EndTextBox";
            this.EndTextBox.Size = new System.Drawing.Size(91, 20);
            this.EndTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(460, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "b:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AccuracyTextBox
            // 
            this.AccuracyTextBox.Location = new System.Drawing.Point(649, 447);
            this.AccuracyTextBox.Name = "AccuracyTextBox";
            this.AccuracyTextBox.Size = new System.Drawing.Size(97, 20);
            this.AccuracyTextBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(611, 442);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "e:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AnswerLabel
            // 
            this.AnswerLabel.AutoSize = true;
            this.AnswerLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnswerLabel.Location = new System.Drawing.Point(149, 496);
            this.AnswerLabel.Name = "AnswerLabel";
            this.AnswerLabel.Size = new System.Drawing.Size(0, 26);
            this.AnswerLabel.TabIndex = 13;
            this.AnswerLabel.Click += new System.EventHandler(this.label7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 553);
            this.Controls.Add(this.AnswerLabel);
            this.Controls.Add(this.AccuracyTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.EndTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StartTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FunctionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Chart);
            this.Name = "Form1";
            this.Text = "Лабораторная работа №1 // Седельников Петр";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FunctionTextBox;
        private System.Windows.Forms.TextBox StartTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EndTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AccuracyTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label AnswerLabel;
    }
}

