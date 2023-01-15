namespace Sedelnikov_6
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AMatrixButton = new System.Windows.Forms.Button();
            this.BMatrixButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DimensionBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.ExactLine = new System.Windows.Forms.Label();
            this.ValuesLine = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.GaussAnswer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(431, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "Для некоторой СЛАУ вида A∙X + B = 0, реализовать методы\r\nчисленного нахождения ве" +
    "ктора Х, где размер A – nxn элементов";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Лабораторная работа №6 // Седельников Петр ПИ-211(2)";
            // 
            // AMatrixButton
            // 
            this.AMatrixButton.Location = new System.Drawing.Point(15, 101);
            this.AMatrixButton.Name = "AMatrixButton";
            this.AMatrixButton.Size = new System.Drawing.Size(46, 44);
            this.AMatrixButton.TabIndex = 20;
            this.AMatrixButton.Text = "A";
            this.AMatrixButton.UseVisualStyleBackColor = true;
            this.AMatrixButton.Click += new System.EventHandler(this.AMatrixButton_Click);
            // 
            // BMatrixButton
            // 
            this.BMatrixButton.Location = new System.Drawing.Point(125, 101);
            this.BMatrixButton.Name = "BMatrixButton";
            this.BMatrixButton.Size = new System.Drawing.Size(46, 44);
            this.BMatrixButton.TabIndex = 21;
            this.BMatrixButton.Text = "B";
            this.BMatrixButton.UseVisualStyleBackColor = true;
            this.BMatrixButton.Click += new System.EventHandler(this.BMatrixButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(67, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "* X +";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(177, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 24);
            this.label4.TabIndex = 23;
            this.label4.Text = "= 0";
            // 
            // DimensionBox
            // 
            this.DimensionBox.Location = new System.Drawing.Point(60, 160);
            this.DimensionBox.Name = "DimensionBox";
            this.DimensionBox.Size = new System.Drawing.Size(183, 20);
            this.DimensionBox.TabIndex = 25;
            this.DimensionBox.TextChanged += new System.EventHandler(this.DimensionTextChanged);
            this.DimensionBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DimensionKeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(18, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "n:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 31);
            this.button2.TabIndex = 26;
            this.button2.Text = "Начать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(139, 197);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 31);
            this.button3.TabIndex = 27;
            this.button3.Text = "Очистить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ClearButton);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(263, 197);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 31);
            this.button4.TabIndex = 28;
            this.button4.Text = "Сгенерировать данные";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.GenerateData);
            // 
            // ExactLine
            // 
            this.ExactLine.AutoSize = true;
            this.ExactLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExactLine.Location = new System.Drawing.Point(478, 53);
            this.ExactLine.Name = "ExactLine";
            this.ExactLine.Size = new System.Drawing.Size(113, 16);
            this.ExactLine.TabIndex = 31;
            this.ExactLine.Text = "Метод Гаусса:";
            this.ExactLine.UseMnemonic = false;
            this.ExactLine.Click += new System.EventHandler(this.ExactLine_Click);
            // 
            // ValuesLine
            // 
            this.ValuesLine.AutoSize = true;
            this.ValuesLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ValuesLine.Location = new System.Drawing.Point(477, 20);
            this.ValuesLine.Name = "ValuesLine";
            this.ValuesLine.Size = new System.Drawing.Size(222, 20);
            this.ValuesLine.TabIndex = 30;
            this.ValuesLine.Text = "Результаты вычислений:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(478, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Метод квадратного корня:";
            this.label5.UseMnemonic = false;
            this.label5.Visible = false;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(478, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 16);
            this.label7.TabIndex = 33;
            this.label7.Text = "Метод прогонки:";
            this.label7.UseMnemonic = false;
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(478, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(198, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "Метод простой итерации:";
            this.label8.UseMnemonic = false;
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(478, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(231, 16);
            this.label9.TabIndex = 35;
            this.label9.Text = "Метод наискорейшего спуска:";
            this.label9.UseMnemonic = false;
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(478, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(250, 16);
            this.label10.TabIndex = 36;
            this.label10.Text = "Метод споряженных градиентов:";
            this.label10.UseMnemonic = false;
            this.label10.Visible = false;
            // 
            // GaussAnswer
            // 
            this.GaussAnswer.AutoSize = true;
            this.GaussAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GaussAnswer.Location = new System.Drawing.Point(586, 53);
            this.GaussAnswer.Name = "GaussAnswer";
            this.GaussAnswer.Size = new System.Drawing.Size(0, 16);
            this.GaussAnswer.TabIndex = 37;
            this.GaussAnswer.UseMnemonic = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(414, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 31);
            this.button1.TabIndex = 38;
            this.button1.Text = "Импорт данных с G.Sheets";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(575, 197);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(155, 31);
            this.button5.TabIndex = 39;
            this.button5.Text = "Экспорт данных в G.Sheets";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 240);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GaussAnswer);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ExactLine);
            this.Controls.Add(this.ValuesLine);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DimensionBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BMatrixButton);
            this.Controls.Add(this.AMatrixButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Лабораторная работа №6 // Седельников Петр ПИ-211(2)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AMatrixButton;
        private System.Windows.Forms.Button BMatrixButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DimensionBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label ExactLine;
        private System.Windows.Forms.Label ValuesLine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label GaussAnswer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
    }
}

