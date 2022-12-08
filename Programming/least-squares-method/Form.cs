using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sedelnikov_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TableAddRow(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void TableAddPoint(object sender, DataGridViewCellEventArgs e)
        {
            List<List<double>> Points = GetAllPoints();
            DrawPoints(Points);
        }

        void DrawPoints(List<List<double>> Points)
        {
            chart1.Series[0].Points.Clear();

            foreach (List<double> Point in Points)
            {
                if (Point[0] > 99999999 || Point[0] < -99999999 || Point[1] > 99999999 || Point[1] < -99999999 || Point[1] is double.NaN)
                {
                    continue;
                }
                else
                {
                    chart1.Series[0].Points.AddXY(Point[0], Point[1]);
                }
            }

            chart1.Series[0].Points.ResumeUpdates();
        }

        List<List<double>> GetAllPoints()
        {
            List<List<double>> Points = new List<List<double>>();

            for (int RowCount = 0; RowCount < Table.RowCount; RowCount++)
            {
                try
                {
                    List<double> Point = new List<double>();
            
                    for (int ColumnCount = 0; ColumnCount < 2; ColumnCount++)
                    {
                        var Row = Table.Rows[RowCount];
                        var CellValue = Row.Cells[ColumnCount].EditedFormattedValue;
                        string CellValueLine = CellValue.ToString();
                        double Number = Double.Parse(CellValueLine);
                        Point.Add(Number);
                    }
            
                    Points.Add(Point);
                } catch
                {
                    continue;
                }
            }

            return Points;
        }

        List<double> GetCoefficients(List<List<double>> Points)
        {
            List<double> Coefficients = new List<double>();

            double SXiYi = 0;
            double SX = 0;
            double SY = 0;
            double SX2 = 0;
            int AmountPoints = Points.Count();

            foreach (var Point in Points)
            {
                SXiYi += Point[0] * Point[1];
                SX += Point[0];
                SY += Point[1];
                SX2 += Point[0] * Point[0];
            }

            double A = Math.Round((AmountPoints * SXiYi - (SX * SY)) / (AmountPoints * SX2 - SX * SX), 2);
            double B = Math.Round((SY - A * SX) / AmountPoints, 2);

            Coefficients.Add(A);
            Coefficients.Add(B);
            return Coefficients;
        }

        List<double> GetQuadraticCoefficients(List<List<double>> Points)
        {
            List<double> Coefficients = new List<double>();

            double SXiYi = 0;
            double SX = 0;
            double SY = 0;
            double SX2 = 0;
            double SX3 = 0;
            double SX4 = 0;
            double SXi2Yi = 0;
            int AmountPoints = Points.Count();

            foreach (var Point in Points)
            {
                SXiYi += Point[0] * Point[1];
                SXi2Yi += Math.Pow(Point[0], 2) * Point[1];
                SX += Point[0];
                SY += Point[1];
                SX2 += Math.Pow(Point[0], 2);
                SX3 += Math.Pow(Point[0], 3);
                SX4 += Math.Pow(Point[0], 4);
            }

            List<List<List<double>>> Matriсes = GetMatriсes(SXiYi, SX, SY, SX2, SX3, SX4, SXi2Yi, AmountPoints);
            List<List<double>> Matrix = Matriсes[0];
            List<List<double>> Matrix1 = Matriсes[1];
            List<List<double>> Matrix2 = Matriсes[2];
            List<List<double>> Matrix3 = Matriсes[3];

            double Delta = GetDelta(Matrix);
            double Delta1 = GetDelta(Matrix1);
            double Delta2 = GetDelta(Matrix2);
            double Delta3 = GetDelta(Matrix3);

            double A = Math.Round(Delta1 / Delta, 2);
            double B = Math.Round(Delta2 / Delta, 2);
            double C = Math.Round(Delta3 / Delta, 2);

            Coefficients.Add(A);
            Coefficients.Add(B);
            Coefficients.Add(C);
            return Coefficients;
        }

        double GetDelta(List<List<double>> Matrix)
        {
            double Delta = (Matrix[0][0] * Matrix[1][1] * Matrix[2][2]);
            Delta += (Matrix[0][1] * Matrix[1][2] * Matrix[2][3]);
            Delta += (Matrix[0][2] * Matrix[1][3] * Matrix[2][4]);
            Delta -= (Matrix[0][4] * Matrix[1][3] * Matrix[2][2]);
            Delta -= (Matrix[0][3] * Matrix[1][2] * Matrix[2][1]);
            Delta -= (Matrix[0][2] * Matrix[1][1] * Matrix[2][0]);
            return Delta;
        }

        List<List<List<double>>> GetMatriсes(double SXiYi, double SX, double SY, double SX2, double SX3, double SX4, double SXi2Yi, int AmountPoints)
        {
            List<List<List<double>>> Matriсes = new List<List<List<double>>>();
            List<double> Line = new List<double>();

            List<List<double>> MatrixA = new List<List<double>>();

            Line = new List<double>();
            Line.Add(SX4);
            Line.Add(SX3);
            Line.Add(SX2);
            MatrixA.Add(Line);

            Line = new List<double>();
            Line.Add(SX3);
            Line.Add(SX2);
            Line.Add(SX);
            MatrixA.Add(Line);

            Line = new List<double>();
            Line.Add(SX2);
            Line.Add(SX);
            Line.Add(AmountPoints);
            MatrixA.Add(Line);

            List<List<double>> MatrixB = new List<List<double>>();

            Line = new List<double>();
            Line.Add(SXi2Yi);
            MatrixB.Add(Line);

            Line = new List<double>();
            Line.Add(SXiYi);
            MatrixB.Add(Line);

            Line = new List<double>();
            Line.Add(SY);
            MatrixB.Add(Line);

            List<List<double>> Matrix = new List<List<double>>();

            Line = new List<double>();
            Line.Add(MatrixA[0][0]);
            Line.Add(MatrixA[0][1]);
            Line.Add(MatrixA[0][2]);
            Line.Add(MatrixA[0][0]);
            Line.Add(MatrixA[0][1]);
            Matrix.Add(Line);

            Line = new List<double>();
            Line.Add(MatrixA[1][0]);
            Line.Add(MatrixA[1][1]);
            Line.Add(MatrixA[1][2]);
            Line.Add(MatrixA[1][0]);
            Line.Add(MatrixA[1][1]);
            Matrix.Add(Line);

            Line = new List<double>();
            Line.Add(MatrixA[2][0]);
            Line.Add(MatrixA[2][1]);
            Line.Add(MatrixA[2][2]);
            Line.Add(MatrixA[2][0]);
            Line.Add(MatrixA[2][1]);
            Matrix.Add(Line);

            List<List<double>> Matrix1 = new List<List<double>>();

            Line = new List<double>();
            Line.Add(MatrixB[0][0]);
            Line.Add(MatrixA[0][1]);
            Line.Add(MatrixA[0][2]);
            Line.Add(MatrixB[0][0]);
            Line.Add(MatrixA[0][1]);
            Matrix1.Add(Line);

            Line = new List<double>();
            Line.Add(MatrixB[1][0]);
            Line.Add(MatrixA[1][1]);
            Line.Add(MatrixA[1][2]);
            Line.Add(MatrixB[1][0]);
            Line.Add(MatrixA[1][1]);
            Matrix1.Add(Line);

            Line = new List<double>();
            Line.Add(MatrixB[2][0]);
            Line.Add(MatrixA[2][1]);
            Line.Add(MatrixA[2][2]);
            Line.Add(MatrixB[2][0]);
            Line.Add(MatrixA[2][1]);
            Matrix1.Add(Line);

            List<List<double>> Matrix2 = new List<List<double>>();

            Line = new List<double>();
            Line.Add(MatrixA[0][0]);
            Line.Add(MatrixB[0][0]);
            Line.Add(MatrixA[0][2]);
            Line.Add(MatrixA[0][0]);
            Line.Add(MatrixB[0][0]);
            Matrix2.Add(Line);

            Line = new List<double>();
            Line.Add(MatrixA[1][0]);
            Line.Add(MatrixB[1][0]);
            Line.Add(MatrixA[1][2]);
            Line.Add(MatrixA[1][0]);
            Line.Add(MatrixB[1][0]);
            Matrix2.Add(Line);

            Line = new List<double>();
            Line.Add(MatrixA[2][0]);
            Line.Add(MatrixB[2][0]);
            Line.Add(MatrixA[2][2]);
            Line.Add(MatrixA[2][0]);
            Line.Add(MatrixB[2][0]);
            Matrix2.Add(Line);

            List<List<double>> Matrix3 = new List<List<double>>();

            Line = new List<double>();
            Line.Add(MatrixA[0][0]);
            Line.Add(MatrixA[0][1]);
            Line.Add(MatrixB[0][0]);
            Line.Add(MatrixA[0][0]);
            Line.Add(MatrixA[0][1]);
            Matrix3.Add(Line);

            Line = new List<double>();
            Line.Add(MatrixA[1][0]);
            Line.Add(MatrixA[1][1]);
            Line.Add(MatrixB[1][0]);
            Line.Add(MatrixA[1][0]);
            Line.Add(MatrixA[1][1]);
            Matrix3.Add(Line);

            Line = new List<double>();
            Line.Add(MatrixA[2][0]);
            Line.Add(MatrixA[2][1]);
            Line.Add(MatrixB[2][0]);
            Line.Add(MatrixA[2][0]);
            Line.Add(MatrixA[2][1]);
            Matrix3.Add(Line);

            Matriсes.Add(Matrix);
            Matriсes.Add(Matrix1);
            Matriсes.Add(Matrix2);
            Matriсes.Add(Matrix3);
            return Matriсes;
        }

        private void CalculateButton(object sender, EventArgs e)
        {
            try
            {
                List<List<double>> Points = GetAllPoints();
                DrawPoints(Points);
                List<double> Coefficients = GetCoefficients(Points);

                if (!Double.IsNaN(Coefficients[0]) && !Double.IsNaN(Coefficients[1]))
                {
                    string Formula = $"({Coefficients[0]} * x) + ({Coefficients[1]})";
                    List<List<double>> ApproximatedPoints = GetApproximatedPoints(Points, Formula);
                    DrawGraphic(ApproximatedPoints);
                    DrawPoints(Points);
                    Answer.Text = $"Уравнение: {Coefficients[0]}x + {Coefficients[1]}";
                }
                else
                {
                    Answer.Text = $"Аппроксимировать невозможно!";
                }
            } catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void TableMouseLeave(object sender, EventArgs e)
        {
            List<List<double>> Points = GetAllPoints();
            DrawPoints(Points);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void DrawGraphic(List<List<double>> Points)
        {
            chart1.Series[1].Points.Clear();

            foreach (List<double> Point in Points)
            {
                if (Point[0] > 99999999 || Point[0] < -99999999 || Point[1] > 99999999 || Point[1] < -99999999 || Point[1] is double.NaN)
                {
                    continue;
                }
                else
                {
                    chart1.Series[1].Points.AddXY(Point[0], Point[1]);
                }
            }
            chart1.Series[1].Points.ResumeUpdates();
        }

        private void QuadraticCalculate(object sender, EventArgs e)
        {
            try
            {
                List<List<double>> Points = GetAllPoints();
                List<double> Coefficients = GetQuadraticCoefficients(Points);
                if (!Double.IsNaN(Coefficients[0]) && !Double.IsNaN(Coefficients[1]) && !Double.IsNaN(Coefficients[2]))
                {
                    string Formula = $"({Coefficients[0]} * x * x) + ({Coefficients[1]} * x) + {Coefficients[2]}";
                    List<List<double>> ApproximatedPoints = GetApproximatedPoints(Points, Formula);
                    DrawGraphic(ApproximatedPoints);
                    DrawPoints(Points);
                    Answer.Text = $"Уравнение: {Coefficients[0]}x² + {Coefficients[1]}x + {Coefficients[2]}";
                }
                else
                {
                    Answer.Text = $"Аппроксимировать невозможно!";
                }
            } catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        List<double> GetPoint(MathParser Parser, string Function, double X)
        {
            List<double> Point = new List<double>();
            string NowFunction = String.Copy(Function).ToLower();
            NowFunction = NowFunction.Replace("x", X.ToString());

            double Y = Parser.Parse(NowFunction, true);

            Point.Add(X);
            Point.Add(Math.Round(Y, 8));

            return Point;
        }

        List<List<double>> GetApproximatedPoints(List<List<double>> Points, string Formula) { 
            MathParser Parser = new MathParser();
            List<List<double>> ApproximatedPoints = new List<List<double>>();
            Formula = Formula.Replace("x", "(x)");

            double MinX = Double.MaxValue;
            double MaxX = Double.MinValue;

            foreach (var Point in Points) { 
                if (Point[0] > MaxX)
                {
                    MaxX = Point[0];
                }
                if (Point[0] < MinX)
                {
                    MinX = Point[0];
                }
            }

            double NowX = MinX;
            while (NowX < MaxX) {
                List<double> Point = GetPoint(Parser, Formula, NowX);
                ApproximatedPoints.Add(Point);
                NowX += 1;
            }

            if (ApproximatedPoints[ApproximatedPoints.Count - 1][0] != MaxX)
            {
                List<double> Point = GetPoint(Parser, Formula, MaxX);
                ApproximatedPoints.Add(Point);
            }

            return ApproximatedPoints;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Table.Rows.Clear();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            Answer.Text = "";
        }
    }
}
