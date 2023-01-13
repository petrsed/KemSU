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
    public class Logic
    {

        List<List<int>> MatrixA;
        List<List<int>> MatrixB;
        List<List<int>> MatrixX;
        int Dimension;

        int RamdomMinNumber = 100;
        int RamdomMaxNumber = 999;
        public Logic()
        {
        }

        public void SetMatrixA(List<List<int>> NewMatrixA)
        {
            MatrixA = NewMatrixA;
        }

        public void SetMatrixB(List<List<int>> NewMatrixB)
        {
            MatrixB = NewMatrixB;
        }

        public void SetMatrixX(List<List<int>> NewMatrixX)
        {
            MatrixX = NewMatrixX;
        }

        public List<List<int>> GetMatrixA()
        {
            return MatrixA;
        }

        public List<List<int>> GetMatrixB()
        {
            return MatrixB;
        }

        public List<List<int>> GetMatrixX()
        {
            return MatrixX;
        }
        public int GetDimension()
        {
            return Dimension;
        }

        public void SetDimension(int NewDimension)
        {
            Dimension = NewDimension;
        }

        public List<List<int>> GetZeroMatrix(int Dimension)
        {
            List<List<int>> Matrix = new List<List<int>>();

            for (int RowIndex = 0; RowIndex < Dimension; RowIndex++)
            {
                List<int> Row = new List<int>();

                for (int ColumnIndex = 0; ColumnIndex < Dimension; ColumnIndex++)
                {
                    Row.Add(0);
                }

                Matrix.Add(Row);
            }

            return Matrix;
        }

        public List<List<int>> GetRandomMatrix(int Dimension)
        {
            List<List<int>> Matrix = new List<List<int>>();
            int Value;
            Random rnd = new Random();

            for (int RowIndex = 0; RowIndex < Dimension; RowIndex++)
            {
                List<int> Row = new List<int>();

                for (int ColumnIndex = 0; ColumnIndex < Dimension; ColumnIndex++)
                {
                    Value = rnd.Next(RamdomMinNumber, RamdomMaxNumber + 1);
                    Row.Add(Value);
                }

                Matrix.Add(Row);
            }

            return Matrix;
        }

        public List<List<int>> GetRandomVector(int Dimension)
        {
            List<List<int>> Matrix = new List<List<int>>();
            int Value;
            Random rnd = new Random();

            for (int RowIndex = 0; RowIndex < Dimension; RowIndex++)
            {
                List<int> Row = new List<int>();

                for (int ColumnIndex = 0; ColumnIndex < 1; ColumnIndex++)
                {
                    Value = rnd.Next(RamdomMinNumber, RamdomMaxNumber + 1);
                    Row.Add(Value);
                }

                Matrix.Add(Row);
            }

            return Matrix;
        }

        public List<List<int>> GetZeroVector(int Dimension)
        {
            List<List<int>> Matrix = new List<List<int>>();

            for (int RowIndex = 0; RowIndex < Dimension; RowIndex++)
            {
                List<int> Row = new List<int>();

                for (int ColumnIndex = 0; ColumnIndex < 1; ColumnIndex++)
                {
                    Row.Add(0);
                }

                Matrix.Add(Row);
            }

            return Matrix;
        }
        public List<List<double>> GetZeroDoubleVector(int Dimension)
        {
            List<List<double>> Matrix = new List<List<double>>();

            for (int RowIndex = 0; RowIndex < Dimension; RowIndex++)
            {
                List<double> Row = new List<double>();

                for (int ColumnIndex = 0; ColumnIndex < 1; ColumnIndex++)
                {
                    Row.Add(0);
                }

                Matrix.Add(Row);
            }

            return Matrix;
        }

        public List<List<int>> RunThroughMethod()
        {
            List<List<int>> AnswerMatrix = GetZeroVector(Dimension);



            return AnswerMatrix;
        }

        public List<List<double>> GaussMethod()
        {
            List<List<int>> MatrixAObj = new List<List<int>>(MatrixA);
            List<List<int>> MatrixBObj = new List<List<int>>(MatrixB);
            List<List<double>> AnswerMatrix = GetZeroDoubleVector(Dimension);

            for (int FirstIndex = 0; FirstIndex < Dimension - 1; FirstIndex++)
            {
                for (int SecondIndex = FirstIndex + 1; SecondIndex < Dimension; SecondIndex++)
                {
                    for (int ThirdIndex = FirstIndex + 1; ThirdIndex < Dimension; ThirdIndex++)
                    {
                        MatrixAObj[SecondIndex][ThirdIndex] = MatrixAObj[SecondIndex][ThirdIndex] - MatrixAObj[FirstIndex][ThirdIndex] * (MatrixAObj[SecondIndex][FirstIndex] / MatrixAObj[FirstIndex][FirstIndex]);
                    }
                    MatrixBObj[SecondIndex][0] = MatrixBObj[SecondIndex][0] - MatrixBObj[FirstIndex][0] * MatrixAObj[SecondIndex][FirstIndex] / MatrixAObj[FirstIndex][FirstIndex];
                }
            }
            for (int FirstIndex = Dimension - 1; FirstIndex >= 0; FirstIndex--)
            {
                double Temp = 0;
                for (int SecondIndex = FirstIndex + 1; SecondIndex < Dimension; SecondIndex++)
                    Temp = Temp + MatrixAObj[FirstIndex][SecondIndex] * AnswerMatrix[SecondIndex][0];

                double Answer = (MatrixBObj[FirstIndex][0] - Temp) / MatrixAObj[FirstIndex][FirstIndex];
                AnswerMatrix[FirstIndex][0] = Math.Round(Answer, 2);
            }

            return AnswerMatrix;
        }
    }
}