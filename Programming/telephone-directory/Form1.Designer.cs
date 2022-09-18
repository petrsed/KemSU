namespace Sedelnikov_0._2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameLabel = new System.Windows.Forms.Label();
            this.WorkNumberLabel = new System.Windows.Forms.Label();
            this.VariantLabel = new System.Windows.Forms.Label();
            this.TaskLabel = new System.Windows.Forms.Label();
            this.DataTable = new System.Windows.Forms.DataGridView();
            this.AddLabel = new System.Windows.Forms.Label();
            this.AddNameBox = new System.Windows.Forms.TextBox();
            this.AddNameLabel = new System.Windows.Forms.Label();
            this.AddPhoneLabel = new System.Windows.Forms.Label();
            this.AddPhoneBox = new System.Windows.Forms.TextBox();
            this.AddYearLabel = new System.Windows.Forms.Label();
            this.AddYearBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DelPhoneLabel = new System.Windows.Forms.Label();
            this.DelPhoneBox = new System.Windows.Forms.TextBox();
            this.DelPhoneButton = new System.Windows.Forms.Button();
            this.AddFilterButton = new System.Windows.Forms.Button();
            this.DelFilterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.NameLabel.Location = new System.Drawing.Point(48, 37);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(297, 30);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "//Седельников П.В ПИ-211(2)";
            this.NameLabel.Click += new System.EventHandler(this.NameLabel_Click);
            // 
            // WorkNumberLabel
            // 
            this.WorkNumberLabel.AutoSize = true;
            this.WorkNumberLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.WorkNumberLabel.Location = new System.Drawing.Point(48, 67);
            this.WorkNumberLabel.Name = "WorkNumberLabel";
            this.WorkNumberLabel.Size = new System.Drawing.Size(331, 30);
            this.WorkNumberLabel.TabIndex = 1;
            this.WorkNumberLabel.Text = "//Лабораторная работа №0-2";
            this.WorkNumberLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // VariantLabel
            // 
            this.VariantLabel.AutoSize = true;
            this.VariantLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.VariantLabel.Location = new System.Drawing.Point(48, 97);
            this.VariantLabel.Name = "VariantLabel";
            this.VariantLabel.Size = new System.Drawing.Size(141, 30);
            this.VariantLabel.TabIndex = 2;
            this.VariantLabel.Text = "//Вариант 8";
            // 
            // TaskLabel
            // 
            this.TaskLabel.AutoSize = true;
            this.TaskLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TaskLabel.Location = new System.Drawing.Point(48, 127);
            this.TaskLabel.Name = "TaskLabel";
            this.TaskLabel.Size = new System.Drawing.Size(665, 75);
            this.TaskLabel.TabIndex = 3;
            this.TaskLabel.Text = "Телефонный справочник содержит данные об абонентах: фамилия, номер\r\nтелефона (чис" +
    "ло формата xxyy), где установки телефона (формат аабб). \r\nВывести данные об абон" +
    "ентах, у которых уу=бб";
            this.TaskLabel.Click += new System.EventHandler(this.TaskLabel_Click);
            // 
            // DataTable
            // 
            this.DataTable.AllowUserToAddRows = false;
            this.DataTable.AllowUserToDeleteRows = false;
            this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTable.Location = new System.Drawing.Point(52, 214);
            this.DataTable.Name = "DataTable";
            this.DataTable.ReadOnly = true;
            this.DataTable.RowTemplate.Height = 25;
            this.DataTable.Size = new System.Drawing.Size(666, 214);
            this.DataTable.TabIndex = 4;
            // 
            // AddLabel
            // 
            this.AddLabel.AutoSize = true;
            this.AddLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AddLabel.Location = new System.Drawing.Point(48, 443);
            this.AddLabel.Name = "AddLabel";
            this.AddLabel.Size = new System.Drawing.Size(228, 30);
            this.AddLabel.TabIndex = 5;
            this.AddLabel.Text = "Добавление номера:";
            // 
            // AddNameBox
            // 
            this.AddNameBox.Location = new System.Drawing.Point(163, 488);
            this.AddNameBox.Name = "AddNameBox";
            this.AddNameBox.Size = new System.Drawing.Size(135, 23);
            this.AddNameBox.TabIndex = 6;
            this.AddNameBox.TextChanged += new System.EventHandler(this.AddNameBox_TextChanged);
            this.AddNameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StopSpaces);
            // 
            // AddNameLabel
            // 
            this.AddNameLabel.AutoSize = true;
            this.AddNameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AddNameLabel.Location = new System.Drawing.Point(48, 481);
            this.AddNameLabel.Name = "AddNameLabel";
            this.AddNameLabel.Size = new System.Drawing.Size(109, 30);
            this.AddNameLabel.TabIndex = 7;
            this.AddNameLabel.Text = "Фамилия:";
            this.AddNameLabel.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // AddPhoneLabel
            // 
            this.AddPhoneLabel.AutoSize = true;
            this.AddPhoneLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AddPhoneLabel.Location = new System.Drawing.Point(313, 481);
            this.AddPhoneLabel.Name = "AddPhoneLabel";
            this.AddPhoneLabel.Size = new System.Drawing.Size(102, 30);
            this.AddPhoneLabel.TabIndex = 9;
            this.AddPhoneLabel.Text = "Телефон:";
            this.AddPhoneLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // AddPhoneBox
            // 
            this.AddPhoneBox.Location = new System.Drawing.Point(412, 488);
            this.AddPhoneBox.Name = "AddPhoneBox";
            this.AddPhoneBox.Size = new System.Drawing.Size(71, 23);
            this.AddPhoneBox.TabIndex = 8;
            this.AddPhoneBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.AddPhoneBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StopSpaces);
            // 
            // AddYearLabel
            // 
            this.AddYearLabel.AutoSize = true;
            this.AddYearLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AddYearLabel.Location = new System.Drawing.Point(488, 483);
            this.AddYearLabel.Name = "AddYearLabel";
            this.AddYearLabel.Size = new System.Drawing.Size(51, 30);
            this.AddYearLabel.TabIndex = 11;
            this.AddYearLabel.Text = "Год:";
            this.AddYearLabel.Click += new System.EventHandler(this.YearLabel_Click);
            // 
            // AddYearBox
            // 
            this.AddYearBox.Location = new System.Drawing.Point(545, 490);
            this.AddYearBox.Name = "AddYearBox";
            this.AddYearBox.Size = new System.Drawing.Size(76, 23);
            this.AddYearBox.TabIndex = 10;
            this.AddYearBox.TextChanged += new System.EventHandler(this.YearBox_TextChanged);
            this.AddYearBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StopSpaces);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(638, 490);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 12;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(48, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 30);
            this.label1.TabIndex = 13;
            this.label1.Text = "Удаление номера:";
            // 
            // DelPhoneLabel
            // 
            this.DelPhoneLabel.AutoSize = true;
            this.DelPhoneLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DelPhoneLabel.Location = new System.Drawing.Point(48, 555);
            this.DelPhoneLabel.Name = "DelPhoneLabel";
            this.DelPhoneLabel.Size = new System.Drawing.Size(102, 30);
            this.DelPhoneLabel.TabIndex = 15;
            this.DelPhoneLabel.Text = "Телефон:";
            // 
            // DelPhoneBox
            // 
            this.DelPhoneBox.Location = new System.Drawing.Point(147, 562);
            this.DelPhoneBox.Name = "DelPhoneBox";
            this.DelPhoneBox.Size = new System.Drawing.Size(71, 23);
            this.DelPhoneBox.TabIndex = 14;
            // 
            // DelPhoneButton
            // 
            this.DelPhoneButton.Location = new System.Drawing.Point(235, 563);
            this.DelPhoneButton.Name = "DelPhoneButton";
            this.DelPhoneButton.Size = new System.Drawing.Size(75, 23);
            this.DelPhoneButton.TabIndex = 16;
            this.DelPhoneButton.Text = "Удалить";
            this.DelPhoneButton.UseVisualStyleBackColor = true;
            this.DelPhoneButton.Click += new System.EventHandler(this.DelPhoneButton_Click);
            // 
            // AddFilterButton
            // 
            this.AddFilterButton.Location = new System.Drawing.Point(436, 563);
            this.AddFilterButton.Name = "AddFilterButton";
            this.AddFilterButton.Size = new System.Drawing.Size(138, 23);
            this.AddFilterButton.TabIndex = 17;
            this.AddFilterButton.Text = "Применить фильтр";
            this.AddFilterButton.UseVisualStyleBackColor = true;
            this.AddFilterButton.Click += new System.EventHandler(this.AddFilterButton_Click);
            // 
            // DelFilterButton
            // 
            this.DelFilterButton.Location = new System.Drawing.Point(580, 563);
            this.DelFilterButton.Name = "DelFilterButton";
            this.DelFilterButton.Size = new System.Drawing.Size(138, 23);
            this.DelFilterButton.TabIndex = 18;
            this.DelFilterButton.Text = "Сбросить фильтр";
            this.DelFilterButton.UseVisualStyleBackColor = true;
            this.DelFilterButton.Click += new System.EventHandler(this.DelFilterButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 614);
            this.Controls.Add(this.DelFilterButton);
            this.Controls.Add(this.AddFilterButton);
            this.Controls.Add(this.DelPhoneButton);
            this.Controls.Add(this.DelPhoneLabel);
            this.Controls.Add(this.DelPhoneBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AddYearLabel);
            this.Controls.Add(this.AddYearBox);
            this.Controls.Add(this.AddPhoneLabel);
            this.Controls.Add(this.AddPhoneBox);
            this.Controls.Add(this.AddNameLabel);
            this.Controls.Add(this.AddNameBox);
            this.Controls.Add(this.AddLabel);
            this.Controls.Add(this.DataTable);
            this.Controls.Add(this.TaskLabel);
            this.Controls.Add(this.VariantLabel);
            this.Controls.Add(this.WorkNumberLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "Form1";
            this.Text = "Лабораторная работа №0-2";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label NameLabel;
        private Label WorkNumberLabel;
        private Label VariantLabel;
        private Label TaskLabel;
        private DataGridView DataTable;
        private Label AddLabel;
        private TextBox AddNameBox;
        private Label AddNameLabel;
        private Label AddPhoneLabel;
        private TextBox AddPhoneBox;
        private Label AddYearLabel;
        private TextBox AddYearBox;
        private Button AddButton;
        private Label label1;
        private Label DelPhoneLabel;
        private TextBox DelPhoneBox;
        private Button DelPhoneButton;
        private Button AddFilterButton;
        private Button DelFilterButton;
    }
}
