using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.WindowsForms;
using OxyPlot.Series;

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
            List<List<double>> ApproximatedPoints = new List<List<double>>();
            DrawGraphic(Points, ApproximatedPoints, false);
        }


        List<List<double>> GetAllPoints()
        {
            List<List<double>> Points = new List<List<double>>();
            List<double> Point = new List<double>();

            for (int RowCount = 0; RowCount < Table.RowCount; RowCount++)
            {
                try
                {
                    Point = new List<double>();
            
                    for (int ColumnCount = 0; ColumnCount < 2; ColumnCount++)
                    {
                        var Row = Table.Rows[RowCount];
                        var CellValue = Row.Cells[ColumnCount].EditedFormattedValue;
                        string CellValueLine = CellValue.ToString();

                        if (CellValueLine == "")
                        {
                            break;
                        }

                        try
                        {
                            double Number = Double.Parse(CellValueLine);

                            if (Number <= 100000000 && Number >= -100000000)
                            {
                                Point.Add(Number);
                            }
                            else
                            {
                                MessageBox.Show("Точка должна быть в диапазоне [-100.000.000;100.000.000]");
                                break;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Это не число!");
                            break;
                        }
                    }

                    if (Point.Count == 2) { Points.Add(Point); }
                } catch
                {
                    continue;
                }
            }
            //List<List<double>> NeedPoints = new List<List<double>>();
            //Point = new List<double>();
            //Point.Add(0);
            //Point.Add(0);
            //NeedPoints.Add(Point);
            //Point = new List<double>();
            //Point.Add(0);
            //Point.Add(0);
            //NeedPoints.Add(Point);
            //Point = new List<double>();
            //Point.Add(0);
            //Point.Add(0);
            //NeedPoints.Add(Point);
            //Point = new List<double>();
            //Point.Add(0);
            //Point.Add(0);
            //NeedPoints.Add(Point);
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

            if (A is double.NaN) {
                A = 0.0;
            }

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
            List<List<double>> Points = GetAllPoints();
            List<List<double>> ApproximatedPoints = new List<List<double>>();
            DrawGraphic(Points, ApproximatedPoints, false);

            try
            {
                List<double> Coefficients = GetCoefficients(Points);

                if (!Double.IsNaN(Coefficients[0]) && !Double.IsNaN(Coefficients[1]))
                {
                    string Formula = $"({Coefficients[0]} * x) + ({Coefficients[1]})";
                    ApproximatedPoints = GetApproximatedPoints(Points, Formula, Coefficients);
                    DrawGraphic(Points, ApproximatedPoints, false);

                    if (Coefficients[0] == 0)
                    {
                        Answer.Text = $"Уравнение: {Points[0][0]}";
                    } else
                    {
                        Answer.Text = $"Уравнение: {Coefficients[0]}x + {Coefficients[1]}";
                    }
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
            List<List<double>> ApproximatedPoints = GetAllPoints();
            DrawGraphic(Points, ApproximatedPoints, false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void DrawPoints(List<List<double>> Points)
        {
            PlotModel Model = new PlotModel();
            ScatterSeries Series = new ScatterSeries();

            foreach (List<double> Point in Points)
            {
                if (Point[0] > 99999999 || Point[0] < -99999999 || Point[1] > 99999999 || Point[1] < -99999999 || Point[1] is double.NaN)
                {
                    continue;
                }
                else
                {
                    Series.Points.Add(new ScatterPoint(Point[0], Point[1]));
                }
            }

            Model.Series.Add(Series);
            Graphic.Model = Model;
        }

        void DrawGraphic(List<List<double>> Points, List<List<double>> ApproximatedPoints, bool isQuadratic)
        {
            PlotModel Model = new PlotModel();
            FunctionSeries FunctionLine = new FunctionSeries { Color = OxyColors.Red };
            ScatterSeries ScatterLine = new ScatterSeries();


            foreach (List<double> Point in ApproximatedPoints)
            {
                if (Point[0] > 99999999 || Point[0] < -99999999 || Point[1] > 99999999 || Point[1] < -99999999 || Point[1] is double.NaN)
                {
                    continue;
                }
                else
                {
                    FunctionLine.Points.Add(new DataPoint(Point[0], Point[1]));
                }
            }

            foreach (List<double> Point in Points)
            {
                if (Point[0] > 100000000 || Point[0] < -100000000 || Point[1] > 100000000 || Point[1] < -100000000 || Point[1] is double.NaN)
                {
                    continue;
                }
                else
                {
                    ScatterLine.Points.Add(new ScatterPoint(Point[0], Point[1], 5));
                }
            }

            Model.Series.Add(ScatterLine);
            Model.Series.Add(FunctionLine);
            Graphic.Model = Model;
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
                    List<List<double>> ApproximatedPoints = GetApproximatedPoints(Points, Formula, Coefficients);
                    DrawGraphic(Points, ApproximatedPoints, true);
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

        List<List<double>> GetApproximatedPoints(List<List<double>> Points, string Formula, List<double> Coefficients) { 
            MathParser Parser = new MathParser();
            List<List<double>> ApproximatedPoints = new List<List<double>>();
            Formula = Formula.Replace("0 * x", "0");
            Formula = Formula.Replace("x", "(x)");
            Formula = Formula.Replace("+ -", "-");

            double MinX = Double.MaxValue;
            double MaxX = Double.MinValue;
            double MinY = Double.MaxValue;
            double MaxY = Double.MinValue;

            foreach (var Point in Points) { 
                if (Point[0] > MaxX)
                {
                    MaxX = Point[0];
                }
                if (Point[0] < MinX)
                {
                    MinX = Point[0];
                }
                if (Point[1] > MaxY)
                {
                    MaxY = Point[1];
                }
                if (Point[1] < MinY)
                {
                    MinY = Point[1];
                }
            }

            double NowX = MinX;
            while (NowX <= MaxX) {
                List<double> Point = GetPoint(Parser, Formula, NowX);
                ApproximatedPoints.Add(Point);
                NowX += 1;
            }

            if (ApproximatedPoints[ApproximatedPoints.Count - 1][0] != MaxX)
            {
                List<double> Point = GetPoint(Parser, Formula, MaxX);
                ApproximatedPoints.Add(Point);
            }

            if (ApproximatedPoints.Count == 1)
            {
                double NowY = MinY;
                while (NowY <= MaxY)
                {
                    List<double> Point = GetPoint(Parser, Formula, NowY);
                    ApproximatedPoints.Add(Point);
                    NowY += 1;
                }
            }

            if (Coefficients[0] == 0)
            {
                ApproximatedPoints = Points;
            }

            return ApproximatedPoints;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Table.Rows.Clear();
            PlotModel Model = new PlotModel();
            FunctionSeries Series = new FunctionSeries();
            Model.Series.Add(Series);
            Graphic.Model = Model;
            Answer.Text = "";
        }
    }
}
