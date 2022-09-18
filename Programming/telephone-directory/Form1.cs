using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sedelnikov_0._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DrawTable(GetData());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TaskLabel_Click(object sender, EventArgs e)
        {

        }

        List<List<String>> GetData()
        {
            var Data = new List<List<String>>();

            using (TextFieldParser parser = new TextFieldParser("data.csv", Encoding.UTF8))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    var Row = new List<String>();  

                    foreach (string field in fields)
                    {
                        Row.Add(field);
                    }

                    Data.Add(Row);
                }
            }

            return Data;
        }

        void DrawTable(List<List<String>> Data)
        {
            DeleteTable();
            if (Data.Count > 0)
            {
                DataTable.ColumnCount = Data[0].Count;
            }

            for (int RowIndex = 0; RowIndex < Data.Count; RowIndex++)
            {
                DataTable.Rows.Add();


                for (int ColumnIndex = 0; ColumnIndex < Data[RowIndex].Count; ColumnIndex++)
                {
                    DataTable.Rows[RowIndex].Cells[ColumnIndex].Value = Data[RowIndex][ColumnIndex];
                }
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void NameLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void YearBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void YearLabel_Click(object sender, EventArgs e)
        {

        }

        private void AddNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void StopSpaces(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }

        void DeleteTable()
        {
            DataTable.Rows.Clear();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string Name = CheckNameFormat(AddNameBox.Text);
            string Phone = CheckPhoneFormat(AddPhoneBox.Text);
            string Year = CheckYearFormat(AddYearBox.Text);

            if (CheckPhonePresence(Phone))
            {
                MessageBox.Show($"Номер телефона уже есть в базе!");
            }
            else if (Name != "" && Phone != "" && Year != "")
            {
                List<List<String>> Data = new List<List<String>>();
                List<String> DataLine = new List<String>();
                DataLine.Add(Name);
                DataLine.Add(Phone);
                DataLine.Add(Year);

                Data.Add(DataLine);
                WriteData(Data, true);
                DrawTable(GetData());

                MessageBox.Show("Номер телефона добавлен!");
            }
        }

        string CheckNameFormat(string Name)
        {
            if (Name == "")
            {
                MessageBox.Show($"Фамилия не может быть пустой!");
                return "";
            } else
            {
                return Name;
            }
        }

        string CheckPhoneFormat(string PhoneText)
        {
            if (Int32.TryParse(PhoneText, out int Phone))
            {
                if (Phone <= 999 || Phone > 9999)
                {
                    MessageBox.Show($"Неправильный формат номера телефона!");
                    return "";
                } else
                {
                    return PhoneText;
                }
            } else
            {
                MessageBox.Show($"Неправильный формат номера телефона!");
                return "";
            }
        }

        string CheckYearFormat(string YearText)
        {
            if (Int32.TryParse(YearText, out int Year))
            {
                if (Year <= 1970 || Year > 2022)
                {
                    MessageBox.Show($"Год должен быть в промежутке 1970-2022!");
                    return "";
                }
                else
                {
                    return YearText;
                }
            }
            else
            {
                MessageBox.Show($"Неправильный формат года!");
                return "";
            }
        }

        void WriteData(List<List<String>> Data, bool SaveOld)
        {
            using (var w = new StreamWriter("data.csv", SaveOld))
            {
                for (int RowIndex = 0; RowIndex < Data.Count; RowIndex++)
                {
                    string line = string.Format("{0};{1};{2}", Data[RowIndex][0], Data[RowIndex][1], Data[RowIndex][02]);
                    w.WriteLine(line);
                }
            }
        }

        private void DelPhoneButton_Click(object sender, EventArgs e)
        {
            string Phone = CheckPhoneFormat(DelPhoneBox.Text);

            if (Phone != "")
            {
                bool PresenceStatus = CheckPhonePresence(Phone);
                if (PresenceStatus) {
                    bool DeleteStatus = DeletePhone(Phone);
                    DrawTable(GetData());

                    MessageBox.Show("Номер телефона удалён!");
                } else
                {
                    MessageBox.Show("Номер телефона не найден!");
                }
            }
        }

        bool CheckPhonePresence(string Phone)
        {
            bool PresenceStatus = false;
            var Data = GetData();

            for (int RowIndex = 0; RowIndex < Data.Count; RowIndex++)
            {
                if (Data[RowIndex][1] == Phone)
                {
                    PresenceStatus = true;
                }
            }

            return PresenceStatus;
        }

        bool DeletePhone(string Phone)
        {
            bool DeleteStatus = false;
            var Data = GetData();
            List<List<String>> NewData = new List<List<String>>();

            for (int RowIndex = 0; RowIndex < Data.Count; RowIndex++)
            {
                if (Data[RowIndex][1] == Phone)
                {
                    DeleteStatus = true;
                }
                else
                {
                    NewData.Add(Data[RowIndex]);
                }
            }

            WriteData(NewData, false);
            return DeleteStatus;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddFilterButton_Click(object sender, EventArgs e)
        {
            var Data = GetData();
            List<List<String>> NewData = new List<List<String>>();

            for (int RowIndex = 0; RowIndex < Data.Count; RowIndex++)
            {
                try
                {
                    String Phone = Data[RowIndex][1];
                    String Year = Data[RowIndex][2];

                    String PhoneSymbols = Phone.Substring(Phone.Length - 2);
                    String YearSymbols = Year.Substring(Year.Length - 2);

                    if (PhoneSymbols == YearSymbols)
                    {
                        NewData.Add(Data[RowIndex]);
                    }
                } catch
                {

                }
            }

            DrawTable(NewData);
        }

        private void DelFilterButton_Click(object sender, EventArgs e)
        {
            DrawTable(GetData());
        }
    }
}
