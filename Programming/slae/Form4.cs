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
    public partial class Form4 : Form
    {

        Logic LogicObj;
        List<List<double>> Matrix;
        int Dimension;
        int TableX = 0;
        int TableY = 0;
        public Form4(Logic LogicObjNew, List<List<double>> MatrixObj, string MatrixName)
        {
            InitializeComponent();
            LogicObj = LogicObjNew;

            Matrix = MatrixObj;
            Dimension = LogicObj.GetDimension();
            this.Text = MatrixName;
            DrawTable(Matrix);
            UpdateTableSize();
            UpdateWindowSize();
        }

        private void Table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void DrawTable(List<List<double>> Matrix)
        {
            string Value;
            Table.ColumnCount = 1;

            for (int RowIndex = 0; RowIndex < Dimension; RowIndex++)
            {
                Table.Rows.Add();

                for (int ColumnIndex = 0; ColumnIndex < 1; ColumnIndex++)
                {
                    try
                    {
                        Value = Matrix[RowIndex][ColumnIndex].ToString();
                    }
                    catch
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

        double GetMatrixMaxNumber()
        {
            double MaxNumber = Int32.MinValue;

            for (int RowIndex = 0; RowIndex < Dimension; RowIndex++)
            {
                for (int ColumnIndex = 0; ColumnIndex < 1; ColumnIndex++)
                {
                    double Value = Matrix[RowIndex][ColumnIndex];

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
            double MaxNumber = GetMatrixMaxNumber();
            return MaxNumber.ToString().Length;
        }

        void UpdateTableSize()
        {
            int MaxLength = GetMatrixMaxNumberLength();
            int WidthCoef;

            if (MaxLength == 1)
            {
                WidthCoef = 21;
            }
            else if (MaxLength == 2)
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
            }
            else
            {
                WidthCoef = 50;
            }

            int NewWidth = WidthCoef;
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

            WindowX = 400;
            WindowY = 60;

            this.Width = TableX + WindowX;
            this.Height = TableY + WindowY;
        }

    }
}
