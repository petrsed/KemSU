namespace Sedelnikov_2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.AnswerLabel = new System.Windows.Forms.Label();
            this.AccuracyTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.EndTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.StartTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FunctionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ClearButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.StepNext = new System.Windows.Forms.Button();
            this.StepBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // AnswerLabel
            // 
            this.AnswerLabel.AutoSize = true;
            this.AnswerLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnswerLabel.Location = new System.Drawing.Point(239, 486);
            this.AnswerLabel.Name = "AnswerLabel";
            this.AnswerLabel.Size = new System.Drawing.Size(0, 19);
            this.AnswerLabel.TabIndex = 26;
            // 
            // AccuracyTextBox
            // 
            this.AccuracyTextBox.Location = new System.Drawing.Point(646, 432);
            this.AccuracyTextBox.Name = "AccuracyTextBox";
            this.AccuracyTextBox.Size = new System.Drawing.Size(97, 20);
            this.AccuracyTextBox.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(608, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 25);
            this.label6.TabIndex = 24;
            this.label6.Text = "e:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EndTextBox
            // 
            this.EndTextBox.Location = new System.Drawing.Point(495, 432);
            this.EndTextBox.Name = "EndTextBox";
            this.EndTextBox.Size = new System.Drawing.Size(91, 20);
            this.EndTextBox.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(457, 428);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 25);
            this.label5.TabIndex = 22;
            this.label5.Text = "b:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StartTextBox
            // 
            this.StartTextBox.Location = new System.Drawing.Point(366, 432);
            this.StartTextBox.Name = "StartTextBox";
            this.StartTextBox.Size = new System.Drawing.Size(75, 20);
            this.StartTextBox.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(328, 428);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "a:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FunctionTextBox
            // 
            this.FunctionTextBox.Location = new System.Drawing.Point(85, 432);
            this.FunctionTextBox.Name = "FunctionTextBox";
            this.FunctionTextBox.Size = new System.Drawing.Size(218, 20);
            this.FunctionTextBox.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(24, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "f(x):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(24, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(722, 46);
            this.label2.TabIndex = 16;
            this.label2.Text = "Используя метод золотого сечения найти локальный минимум заданной точности \r\ne фу" +
    "нкции f(x) на интервале [a, b].";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(24, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(535, 26);
            this.label1.TabIndex = 15;
            this.label1.Text = "Лабораторная работа №2 // Седельников Петр ПИ-211(2)";
            // 
            // Chart
            // 
            chartArea3.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea3);
            this.Chart.Location = new System.Drawing.Point(28, 21);
            this.Chart.Name = "Chart";
            this.Chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series7.BorderWidth = 3;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Color = System.Drawing.Color.Red;
            series7.Name = "Series1";
            series8.BorderWidth = 8;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series8.LabelBorderWidth = 3;
            series8.Name = "NeedPoint";
            series8.YValuesPerPoint = 2;
            series9.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series9.BorderWidth = 10;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series9.Color = System.Drawing.Color.Green;
            series9.MarkerBorderWidth = 10;
            series9.MarkerSize = 10;
            series9.Name = "Series3";
            series9.YValuesPerPoint = 6;
            this.Chart.Series.Add(series7);
            this.Chart.Series.Add(series8);
            this.Chart.Series.Add(series9);
            this.Chart.Size = new System.Drawing.Size(715, 300);
            this.Chart.TabIndex = 14;
            this.Chart.Text = "Chart";
            this.Chart.Click += new System.EventHandler(this.Chart_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(135, 474);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(98, 44);
            this.ClearButton.TabIndex = 32;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(29, 474);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 44);
            this.StartButton.TabIndex = 31;
            this.StartButton.Text = "Начать";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StepNext
            // 
            this.StepNext.Enabled = false;
            this.StepNext.Location = new System.Drawing.Point(700, 474);
            this.StepNext.Name = "StepNext";
            this.StepNext.Size = new System.Drawing.Size(43, 44);
            this.StepNext.TabIndex = 33;
            this.StepNext.Text = "➡️";
            this.StepNext.UseVisualStyleBackColor = true;
            this.StepNext.Click += new System.EventHandler(this.StepNext_Click);
            // 
            // StepBack
            // 
            this.StepBack.Enabled = false;
            this.StepBack.Location = new System.Drawing.Point(646, 474);
            this.StepBack.Name = "StepBack";
            this.StepBack.Size = new System.Drawing.Size(43, 44);
            this.StepBack.TabIndex = 34;
            this.StepBack.Text = "⬅️";
            this.StepBack.UseVisualStyleBackColor = true;
            this.StepBack.Click += new System.EventHandler(this.StepBack_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 535);
            this.Controls.Add(this.StepBack);
            this.Controls.Add(this.StepNext);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.AnswerLabel);
            this.Controls.Add(this.AccuracyTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.EndTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StartTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FunctionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Chart);
            this.Name = "Form1";
            this.Text = "Лабораторная работа №2 // Седельников Петр ПИ-211(2)";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AnswerLabel;
        private System.Windows.Forms.TextBox AccuracyTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox EndTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox StartTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FunctionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StepNext;
        private System.Windows.Forms.Button StepBack;
    }
}

