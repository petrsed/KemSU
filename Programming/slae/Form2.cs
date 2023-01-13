using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sedelnikov_6
{
    public partial class Form2 : Form
    {
        Logic LogicObj;
        List<List<int>> Matrix;
        int Dimension;
        int TableX = 0;
        int TableY = 0;

        public Form2(Logic LogicObjNew)
        {
            InitializeComponent();
            LogicObj = LogicObjNew;

            Dimension = LogicObj.GetDimension();
            Matrix = LogicObj.GetMatrixA();
            DrawTable(Matrix);
            UpdateTableSize();
            UpdateWindowSize();
        }

        private void Form2_Load(object sender, EventArgs e)
        {          
        }

        void DrawTable(List<List<int>> Matrix)
        {
            string Value;
            Table.ColumnCount = Dimension;

            for (int RowIndex = 0; RowIndex < Dimension; RowIndex++)
            {
                Table.Rows.Add();

                for (int ColumnIndex = 0; ColumnIndex < Dimension; ColumnIndex++)
                {
                    try
                    {
                        Value = Matrix[RowIndex][ColumnIndex].ToString();
                    } catch
                    {
                        Value = "";
                    }

                    Table.Rows[RowIndex].Cells[ColumnIndex].Value = Value;
                }
            }

            Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            Table.RowHeadersVisible = false;
            Table.ColumnHeadersVisible = false;
        }

        void UpdateTableSize()
        {
            int MaxLength = GetMatrixMaxNumberLength();
            int WidthCoef;

            if (MaxLength == 1)
            {
                WidthCoef = 21;
            } else if (MaxLength == 2)
            {
                WidthCoef = 22;
            }
            else if (MaxLength == 3)
            {
                WidthCoef = 26;
            }
            else if (MaxLength == 4)
            {
                WidthCoef = 32;
            }
            else if (MaxLength == 5)
            {
                WidthCoef = 38;
            } else
            {
                WidthCoef = 50;
            }

            int NewWidth = WidthCoef * Dimension;
            int NewHeight = 22 * Dimension;

            NewWidth += 2;
            NewHeight += 2;

            TableX = NewWidth;
            TableY = NewHeight;
            Table.ClientSize = new Size(NewWidth, NewHeight);
        }

        void UpdateWindowSize()
        {
            int WindowX, WindowY;

            WindowX = 40;
            WindowY = 60;
 
            this.Width = TableX + WindowX;
            this.Height = TableY + WindowY;
        }

        int GetMatrixMaxNumber()
        {
            int MaxNumber = Int32.MinValue;

            for (int RowIndex = 0; RowIndex < Dimension; RowIndex++)
            {
                for (int ColumnIndex = 0; ColumnIndex < Dimension; ColumnIndex++)
                {
                    int Value = Matrix[RowIndex][ColumnIndex];

                    if (Value > MaxNumber)
                    {
                        MaxNumber = Value;
                    }
                }
            }

            return MaxNumber;
        }

        int GetMatrixMaxNumberLength()
        {
            int MaxNumber = GetMatrixMaxNumber();
            return MaxNumber.ToString().Length; 
        }

        private void FormClose(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        List<List<int>> GetNewMatrix()
        {
            List<List<int>> NewMatrix = new List<List<int>>();
            int Value;

            for (int RowIndex = 0; RowIndex < Dimension; RowIndex++)
            {
                List<int> NewMatrixRow = new List<int>();
                var Row = Table.Rows[RowIndex];

                for (int ColumnIndex = 0; ColumnIndex < Dimension; ColumnIndex++)
                {
                    var CellValue = Row.Cells[ColumnIndex].EditedFormattedValue;
                    string CellValueLine = CellValue.ToString();

                    try
                    {
                        Value = Convert.ToInt32(CellValueLine);
                    }
                    catch
                    {
                        Value = 0;
                    }

                    NewMatrixRow.Add(Value);
                }

                NewMatrix.Add(NewMatrixRow);
            }

            return NewMatrix;
        }
        
        private void SaveData()
        {
            List<List<int>> NewMatrix = GetNewMatrix();
            LogicObj.SetMatrixA(NewMatrix);
        }

        private void TableKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == '-')))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }

            List<List<int>> NewMatrix = GetNewMatrix();
            Matrix = NewMatrix;
            LogicObj.SetMatrixA(NewMatrix);
            UpdateTableSize();
            UpdateWindowSize();
        }
        private void TableKeyControl(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(TableKeyPress);
            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress += new KeyPressEventHandler(TableKeyPress);
            }
        }

        private void TableCellLeave(object sender, DataGridViewCellEventArgs e)
        {
            List<List<int>> NewMatrix = GetNewMatrix();
            Matrix = NewMatrix;
            LogicObj.SetMatrixA(NewMatrix);
            UpdateTableSize();
            UpdateWindowSize();
        }
    }
}
