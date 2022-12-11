using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sedelnikov_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            Chart.Series[0].Points.Clear();
            Chart.Series[1].Points.Clear();

            string Function = FunctionTextBox.Text.Replace("x", "(x)");
            bool StartStatus = CheckDouble(StartTextBox.Text, "a");
            bool EndStatus = CheckDouble(EndTextBox.Text, "b");
            bool AccuracyStatus = CheckInt(AccuracyTextBox.Text, "e");
            bool FormulaStatus = true;
            //string Function = "cos(x)".Replace("x", "(x)");
            //bool StartStatus = true;
            //bool EndStatus = true;
            //bool AccuracyStatus = true;

            MathParser Parser = new MathParser();
            try
            {
                List<double> TestPoint = GetPoint(Parser, Function, 1);
            }
            catch
            {
                MessageBox.Show($"Ошибка в формуле!");
                FormulaStatus = false;
            }


            if (StartStatus && EndStatus && AccuracyStatus && FormulaStatus)
            {
                double Start = Double.Parse(StartTextBox.Text);
                double End = Double.Parse(EndTextBox.Text);
                int Accuracy = Int32.Parse(AccuracyTextBox.Text);
                //double Start = 0;
                //double End = 1;
                //int Accuracy = 5;
                double AmountPoints = 1000;

                if (End > Start)
                {
                    try
                    {
                        List<List<double>> Points = GetPoints(Parser, Function, Start, End, AmountPoints);

                        List<double> MinumumPoint = GetMinimumPoint(Parser, Function, Start, End, Accuracy);
                        double Step = (End - Start) / AmountPoints;
                        List<List<double>> AllMinimumPoints = GetMinimumPoints(Points, MinumumPoint, Step);

                        DrawChart(Points, AllMinimumPoints);

                        if (MinumumPoint[1] is double.NaN)
                        {
                            AnswerLabel.Text = $"Локальный минимум: отсутствует";
                        }
                        else
                        {
                            AnswerLabel.Text = $"Локальный минимум: ({MinumumPoint[0]}, {TruncateDecimal(MinumumPoint[1], Accuracy)})";
                        }
                    }
                    catch
                    {
                        MessageBox.Show($"Слишком сложная формула!");
                    }
                }
                else
                {
                    MessageBox.Show($"Точка конца не может быть левее точки старта!");
                }
            }
        }

        static double TruncateDecimal(double value, int precision)
        {
            double step = (double)Math.Pow(10, precision);
            double tmp = Math.Truncate(step * value);
            return tmp / step;
        }

        void DrawChart(List<List<double>> Points, List<List<double>> MinimumPoints)
        {
            foreach (List<double> Point in Points)
            {
                if (Point[0] > 99999999 || Point[0] < -99999999 || Point[1] > 99999999 || Point[1] < -99999999 || Point[1] is double.NaN)
                {
                    continue;
                }
                else
                {
                    Chart.Series[0].Points.AddXY(Point[0], Point[1]);
                }
            }
            foreach (List<double> MinimumPoint in MinimumPoints)
            {
                Chart.Series[1].Points.AddXY(MinimumPoint[0] + 0.001, MinimumPoint[1]);
            }

            Chart.Series[0].Points.ResumeUpdates();
            Chart.Series[1].Points.ResumeUpdates();
        }

        void Chart_Click()
        {

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

        List<List<double>> GetMinimumPoints(List<List<double>> Points, List<double> MinimumPoint, double Step)
        {
            List<List<double>> MinimumPoints = new List<List<double>>();

            double LastMinimumPointX = -999999;
            foreach (List<double> Point in Points)
            {
                double DiffX = Math.Abs(Point[0] - LastMinimumPointX);
                double DiffY = Math.Abs(Point[1] - MinimumPoint[1]);
                if (DiffY < 0.001)
                {
                    LastMinimumPointX = Point[0];
                    MinimumPoints.Add(Point);
                }
            }

            MinimumPoints.Add(MinimumPoint);    
            return MinimumPoints;
        }

        List<double> GetMinimumPoint(MathParser Parser, string Function, double Start, double End, int Accuracy)
        {
            double Precision = 1 / Math.Pow(10, Accuracy);
            //Precision = 0.001;
            double X1 = (3 - Math.Sqrt(5)) / 2 * (End - Start) + Start;
            double X2 = (Math.Sqrt(5) - 1) / 2 * (End - Start) + Start;
            int count = 0;

            while ((End - Start) / 2 > Precision)
            {
                count++;
                double Y1 = GetPoint(Parser, Function, X1)[1];
                double Y2 = GetPoint(Parser, Function, X2)[1];

                if (Y1 <= Y2)
                {
                    End = X2;
                    X2 = X1;
                    X1 = (3 - Math.Sqrt(5)) / 2 * (End - Start) + Start;
                }
                else
                {
                    Start = X1;
                    X1 = X2;
                    X2 = (Math.Sqrt(5) - 1) / 2 * (End - Start) + Start;
                }
            }

            Console.WriteLine(count);
            double X = (Start + End) / 2;
            double Y = GetPoint(Parser, Function, X)[1];
        
            List<double> MinimumPoint = new List<double>();
            MinimumPoint.Add(TruncateDecimal(X, Accuracy));
            MinimumPoint.Add(TruncateDecimal(Y, Accuracy));

            return MinimumPoint;
        }

        List<List<double>> GetPoints(MathParser Parser, string Function, double Start, double End, double AmountPoints)
        {
            List<List<double>> Points = new List<List<double>>();
            List<double> XPoints = new List<double>();
            double X = Start;
            double Step = (End - Start) / AmountPoints;

            while (X <= End)
            {
                List<double> Point = GetPoint(Parser, Function, X);
                X = Math.Round(X + Step, 4);
                if (Point[1] is double.NaN)
                {
                    continue;
                }
                Points.Add(Point);
                XPoints.Add(X);
            }

            if (!XPoints.Contains(End))
            {
                List<double> Point = GetPoint(Parser, Function, End);
                Points.Add(Point);
                XPoints.Add(End);
            }

            return Points;
        }

        bool CheckDouble(string DoubleLine, string DoubleName)
        {
            if (Double.TryParse(DoubleLine, out double DoubleNumber))
            {
                return true;
            }
            else
            {
                MessageBox.Show($"Неправильный формат числа: {DoubleName}!");
                return false;
            }
        }


        bool CheckInt(string IntLine, string IntName)
        {
            if (Int32.TryParse(IntLine, out int IntNumber))
            {
                if (IntNumber >= 1 && IntNumber <= 7)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Точность должна быть от 1 до 7 знаков после запятой.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show($"Неправильный формат числа: {IntName}!");
                return false;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Chart_Click(object sender, EventArgs e)
        {

        }
    }
}
