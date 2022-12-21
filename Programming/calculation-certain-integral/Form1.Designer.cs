namespace Sedelnikov_5
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
            this.Graphic = new OxyPlot.WindowsForms.PlotView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FunctionBox = new System.Windows.Forms.TextBox();
            this.StartBox = new System.Windows.Forms.TextBox();
            this.EndBox = new System.Windows.Forms.TextBox();
            this.AmountStepsBox = new System.Windows.Forms.TextBox();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ValuesLine = new System.Windows.Forms.Label();
            this.ExactLine = new System.Windows.Forms.Label();
            this.ExactAnswer = new System.Windows.Forms.Label();
            this.RectanglesAnswer = new System.Windows.Forms.Label();
            this.RectanglesLine = new System.Windows.Forms.Label();
            this.TrapezoidsAnswer = new System.Windows.Forms.Label();
            this.TrapezoidsLine = new System.Windows.Forms.Label();
            this.ParabolasAnswer = new System.Windows.Forms.Label();
            this.ParabolasLine = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Graphic
            // 
            this.Graphic.Location = new System.Drawing.Point(12, 12);
            this.Graphic.Name = "Graphic";
            this.Graphic.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.Graphic.Size = new System.Drawing.Size(474, 443);
            this.Graphic.TabIndex = 0;
            this.Graphic.Text = "plotView1";
            this.Graphic.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.Graphic.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.Graphic.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(514, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Лабораторная работа №5 // Седельников Петр ПИ-211(2)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(514, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(415, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Вычислить точное значение интеграла и сравнить значение, \r\nполученные численными " +
    "методами.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(514, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "f(x):";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(513, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "a:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(514, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "b:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(514, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "N:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // FunctionBox
            // 
            this.FunctionBox.Location = new System.Drawing.Point(556, 124);
            this.FunctionBox.Name = "FunctionBox";
            this.FunctionBox.Size = new System.Drawing.Size(183, 20);
            this.FunctionBox.TabIndex = 10;
            // 
            // StartBox
            // 
            this.StartBox.Location = new System.Drawing.Point(556, 158);
            this.StartBox.Name = "StartBox";
            this.StartBox.Size = new System.Drawing.Size(183, 20);
            this.StartBox.TabIndex = 11;
            // 
            // EndBox
            // 
            this.EndBox.Location = new System.Drawing.Point(556, 191);
            this.EndBox.Name = "EndBox";
            this.EndBox.Size = new System.Drawing.Size(183, 20);
            this.EndBox.TabIndex = 12;
            // 
            // AmountStepsBox
            // 
            this.AmountStepsBox.Location = new System.Drawing.Point(556, 226);
            this.AmountStepsBox.Name = "AmountStepsBox";
            this.AmountStepsBox.Size = new System.Drawing.Size(183, 20);
            this.AmountStepsBox.TabIndex = 13;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(755, 132);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(174, 44);
            this.CalculateButton.TabIndex = 19;
            this.CalculateButton.Text = "Начать";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(755, 191);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(174, 44);
            this.ClearButton.TabIndex = 20;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ValuesLine
            // 
            this.ValuesLine.AutoSize = true;
            this.ValuesLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ValuesLine.Location = new System.Drawing.Point(514, 279);
            this.ValuesLine.Name = "ValuesLine";
            this.ValuesLine.Size = new System.Drawing.Size(190, 20);
            this.ValuesLine.TabIndex = 21;
            this.ValuesLine.Text = "Значения интеграла:";
            // 
            // ExactLine
            // 
            this.ExactLine.AutoSize = true;
            this.ExactLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExactLine.Location = new System.Drawing.Point(515, 312);
            this.ExactLine.Name = "ExactLine";
            this.ExactLine.Size = new System.Drawing.Size(66, 16);
            this.ExactLine.TabIndex = 22;
            this.ExactLine.Text = "Точное:";
            this.ExactLine.UseMnemonic = false;
            // 
            // ExactAnswer
            // 
            this.ExactAnswer.AutoSize = true;
            this.ExactAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExactAnswer.Location = new System.Drawing.Point(587, 312);
            this.ExactAnswer.Name = "ExactAnswer";
            this.ExactAnswer.Size = new System.Drawing.Size(0, 16);
            this.ExactAnswer.TabIndex = 23;
            this.ExactAnswer.UseMnemonic = false;
            // 
            // RectanglesAnswer
            // 
            this.RectanglesAnswer.AutoSize = true;
            this.RectanglesAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RectanglesAnswer.Location = new System.Drawing.Point(711, 338);
            this.RectanglesAnswer.Name = "RectanglesAnswer";
            this.RectanglesAnswer.Size = new System.Drawing.Size(0, 16);
            this.RectanglesAnswer.TabIndex = 25;
            this.RectanglesAnswer.UseMnemonic = false;
            // 
            // RectanglesLine
            // 
            this.RectanglesLine.AutoSize = true;
            this.RectanglesLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RectanglesLine.Location = new System.Drawing.Point(516, 338);
            this.RectanglesLine.Name = "RectanglesLine";
            this.RectanglesLine.Size = new System.Drawing.Size(193, 16);
            this.RectanglesLine.TabIndex = 24;
            this.RectanglesLine.Text = "Метод прямоугольников:";
            this.RectanglesLine.UseMnemonic = false;
            // 
            // TrapezoidsAnswer
            // 
            this.TrapezoidsAnswer.AutoSize = true;
            this.TrapezoidsAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TrapezoidsAnswer.Location = new System.Drawing.Point(655, 366);
            this.TrapezoidsAnswer.Name = "TrapezoidsAnswer";
            this.TrapezoidsAnswer.Size = new System.Drawing.Size(0, 16);
            this.TrapezoidsAnswer.TabIndex = 27;
            this.TrapezoidsAnswer.UseMnemonic = false;
            // 
            // TrapezoidsLine
            // 
            this.TrapezoidsLine.AutoSize = true;
            this.TrapezoidsLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TrapezoidsLine.Location = new System.Drawing.Point(516, 366);
            this.TrapezoidsLine.Name = "TrapezoidsLine";
            this.TrapezoidsLine.Size = new System.Drawing.Size(133, 16);
            this.TrapezoidsLine.TabIndex = 26;
            this.TrapezoidsLine.Text = "Метод трапеций:";
            this.TrapezoidsLine.UseMnemonic = false;
            // 
            // ParabolasAnswer
            // 
            this.ParabolasAnswer.AutoSize = true;
            this.ParabolasAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParabolasAnswer.Location = new System.Drawing.Point(646, 394);
            this.ParabolasAnswer.Name = "ParabolasAnswer";
            this.ParabolasAnswer.Size = new System.Drawing.Size(0, 16);
            this.ParabolasAnswer.TabIndex = 29;
            this.ParabolasAnswer.UseMnemonic = false;
            // 
            // ParabolasLine
            // 
            this.ParabolasLine.AutoSize = true;
            this.ParabolasLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParabolasLine.Location = new System.Drawing.Point(516, 394);
            this.ParabolasLine.Name = "ParabolasLine";
            this.ParabolasLine.Size = new System.Drawing.Size(125, 16);
            this.ParabolasLine.TabIndex = 28;
            this.ParabolasLine.Text = "Метод парабол:";
            this.ParabolasLine.UseMnemonic = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 467);
            this.Controls.Add(this.ParabolasAnswer);
            this.Controls.Add(this.ParabolasLine);
            this.Controls.Add(this.TrapezoidsAnswer);
            this.Controls.Add(this.TrapezoidsLine);
            this.Controls.Add(this.RectanglesAnswer);
            this.Controls.Add(this.RectanglesLine);
            this.Controls.Add(this.ExactAnswer);
            this.Controls.Add(this.ExactLine);
            this.Controls.Add(this.ValuesLine);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.AmountStepsBox);
            this.Controls.Add(this.EndBox);
            this.Controls.Add(this.StartBox);
            this.Controls.Add(this.FunctionBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Graphic);
            this.Name = "Form1";
            this.Text = "Лабораторная работа №5 // Седельников Петр ПИ-211(2)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView Graphic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FunctionBox;
        private System.Windows.Forms.TextBox StartBox;
        private System.Windows.Forms.TextBox EndBox;
        private System.Windows.Forms.TextBox AmountStepsBox;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label ValuesLine;
        private System.Windows.Forms.Label ExactLine;
        private System.Windows.Forms.Label ExactAnswer;
        private System.Windows.Forms.Label RectanglesAnswer;
        private System.Windows.Forms.Label RectanglesLine;
        private System.Windows.Forms.Label TrapezoidsAnswer;
        private System.Windows.Forms.Label TrapezoidsLine;
        private System.Windows.Forms.Label ParabolasAnswer;
        private System.Windows.Forms.Label ParabolasLine;
    }
}

