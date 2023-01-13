using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Sedelnikov_6
{
    public partial class Form1 : Form
    {
        int Dimension = 3;
        List<List<int>> MatrixA;
        List<List<int>> MatrixB;
        List<List<int>> MatrixX;
        public Logic LogicObj;

        public Form1()
        {
            LogicObj = new Logic();
            MatrixA = LogicObj.GetZeroMatrix(Dimension);
            MatrixB = LogicObj.GetZeroVector(Dimension);
            MatrixX = LogicObj.GetZeroVector(Dimension);

            LogicObj.SetDimension(Dimension);
            LogicObj.SetMatrixA(MatrixA);
            LogicObj.SetMatrixB(MatrixB);
            LogicObj.SetMatrixX(MatrixX);

            InitializeComponent();
            DimensionBox.Text = Dimension.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AMatrixButton_Click(object sender, EventArgs e)
        {
            var MatrixAForm = new Form2(LogicObj);
            MatrixAForm.Show();
        }

        private void BMatrixButton_Click(object sender, EventArgs e)
        {
            var MatrixBForm = new Form3(LogicObj);
            MatrixBForm.Show();
        }


        List<List<int>> ConvertMatrix(List<List<int>> OldMatrix, int Dimension)
        {
            List<List<int>> NewMatrix = new List<List<int>>();
            int Value;

            for (int RowIndex = 0; RowIndex < Dimension; RowIndex++)
            {
                List<int> Row = new List<int>();

                for (int ColumnIndex = 0; ColumnIndex < Dimension; ColumnIndex++)
                {
                    try
                    {
                        Value = OldMatrix[RowIndex][ColumnIndex];   
                    } catch
                    {
                        Value = 0;
                    }

                    Row.Add(Value);
                }

                NewMatrix.Add(Row);
            }

            return NewMatrix;
        }

        List<List<int>> ConvertVector(List<List<int>> OldMatrix, int Dimension)
        {
            List<List<int>> NewMatrix = new List<List<int>>();
            int Value;

            for (int RowIndex = 0; RowIndex < Dimension; RowIndex++)
            {
                List<int> Row = new List<int>();

                for (int ColumnIndex = 0; ColumnIndex < 1; ColumnIndex++)
                {
                    try
                    {
                        Value = OldMatrix[RowIndex][ColumnIndex];
                    }
                    catch
                    {
                        Value = 0;
                    }

                    Row.Add(Value);
                }

                NewMatrix.Add(Row);
            }

            return NewMatrix;
        }

        private void DimensionTextChanged(object sender, EventArgs e)
        {
            int NewDimension = Convert.ToInt32(DimensionBox.Text);

            if (NewDimension > 10)
            {
                DimensionBox.Text = "3";
                MessageBox.Show("Максимальная размерность матрицы - 10!");
            }

            LogicObj.SetDimension(NewDimension);
            Dimension = NewDimension;
            MatrixA = LogicObj.GetMatrixA();
            MatrixB = LogicObj.GetMatrixB();
            MatrixX = LogicObj.GetMatrixX();

            MatrixA = ConvertMatrix(MatrixA, Dimension);
            LogicObj.SetMatrixA(MatrixA);

            MatrixB = ConvertVector(MatrixB, Dimension);
            LogicObj.SetMatrixB(MatrixB);

            MatrixX = ConvertVector(MatrixX, Dimension);
            LogicObj.SetMatrixX(MatrixX);
        }

        private void DimensionKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        void ClearData()
        {
            Dimension = 3;
            MatrixA = LogicObj.GetZeroMatrix(Dimension);
            MatrixB = LogicObj.GetZeroVector(Dimension);
            MatrixX = LogicObj.GetZeroVector(Dimension);

            LogicObj.SetDimension(Dimension);
            LogicObj.SetMatrixA(MatrixA);
            LogicObj.SetMatrixB(MatrixB);
            LogicObj.SetMatrixX(MatrixX);

            DimensionBox.Text = Dimension.ToString();
        }

        private void ClearButton(object sender, EventArgs e)
        {
            ClearData();
        }

        private void GenerateData(object sender, EventArgs e)
        {
            MatrixA = LogicObj.GetRandomMatrix(Dimension);
            MatrixB = LogicObj.GetRandomVector(Dimension);
            MatrixX = LogicObj.GetZeroVector(Dimension);

            LogicObj.SetMatrixA(MatrixA);
            LogicObj.SetMatrixB(MatrixB);
            LogicObj.SetMatrixX(MatrixX);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch Timer = new Stopwatch();

            Timer.Start();
            List<List<double>> GaussMatrix = LogicObj.GaussMethod();
            var GaussForm = new Form4(LogicObj, GaussMatrix, "Метод Гаусса");
            GaussForm.Show();
            Timer.Stop();
            int TimerMilliSeconds = Convert.ToInt32(Timer.ElapsedMilliseconds);
            GaussAnswer.Text = $"{TimerMilliSeconds} мс.";



            //List<List<double>> RunThroughMatrix = LogicObj.RunThroughMethod();
            //var RunThroughForm = new Form4(LogicObj, RunThroughMatrix, "Метод прогонки");
            //RunThroughForm.Show();
        }

        private void ExactLine_Click(object sender, EventArgs e)
        {

        }
    }
}
