using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sedelnikov_2
{
    public partial class Form1 : Form
    {
        private int Step = 0;
        private List<List<double>> Points = new List<List<double>>();
        private List<List<List<double>>> Steps = new List<List<List<double>>>();

        public Form1()
        {
            InitializeComponent();
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            string FunctionLine = FunctionTextBox.Text;
            string StartLine = StartTextBox.Text;
            string EndLine = EndTextBox.Text;
            string AccuracyLine = AccuracyTextBox.Text;
            //string FunctionLine = "(e)log(x)";
            //string StartLine = "0";
            //string EndLine = "4";
            //string AccuracyLine = "2";

            Step = 0;
            StepBack.Enabled = false;
            StepNext.Enabled = true;

            GetMinimumPointTask(FunctionLine, StartLine, EndLine, AccuracyLine);
        }

        void ChartRefresh()
        {
            Chart.Series[0].Points.Clear();
            Chart.Series[1].Points.Clear();
            Chart.Series[2].Points.Clear();
        }

        void GetMinimumPointTask(string FunctionLine, string StartLine, string EndLine, string AccuracyLine)
        {
            string Function = FunctionLine.Replace("x", "(x)");
            bool StartStatus = CheckDouble(StartLine, "a");
            bool EndStatus = CheckDouble(EndLine, "b");
            bool AccuracyStatus = CheckInt(AccuracyLine, "e");
            bool FormulaStatus = true;

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
                double Start = Double.Parse(StartLine);
                double End = Double.Parse(EndLine);
                int Accuracy = Int32.Parse(AccuracyLine);
                double AmountPoints = 1000;

                if (End > Start)
                {
                    try
                    {
                        Points = GetPoints(Parser, Function, Start, End, AmountPoints);
                        List<double> MinumumPoint = GetMinimumPoint(Points, Parser, Function, Start, End, Accuracy);
                        Steps = GetSteps(Points, Parser, Function, Start, End, Accuracy);

                        List<List<double>> BorderPoints = new List<List<double>>();
                        List<double> Point = GetPoint(Parser, Function, Start);
                        BorderPoints.Add(Point);
                        Point = GetPoint(Parser, Function, End);
                        BorderPoints.Add(Point);
                        DrawChart(Points, BorderPoints);

                        if (MinumumPoint[0] is double.NaN && MinumumPoint[1] is double.NaN) {
                                ChartRefresh();
                        }
                        else if (MinumumPoint[1] is double.NaN)
                        {
                            AnswerLabel.Text = $"Минимум: отсутствует";
                        }
                        else
                        {
                                AnswerLabel.Text = $"Минимум: ({MinumumPoint[0]}, {TruncateDecimal(MinumumPoint[1], Accuracy)})";
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

        void DrawChart(List<List<double>> Points, List<List<double>> BorderPoints)
        {
            ChartRefresh();

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

            foreach (List<double> BorderPoint in BorderPoints)
            {
                if (BorderPoint[0] > 99999999 || BorderPoint[0] < -99999999 || BorderPoint[1] > 99999999 || BorderPoint[1] < -99999999 || BorderPoint[1] is double.NaN)
                {
                    continue;
                }
                else
                {
                    Chart.Series[2].Points.AddXY(BorderPoint[0], BorderPoint[1]);
                }
            }

            Chart.Series[0].Points.ResumeUpdates();
            Chart.Series[2].Points.ResumeUpdates();
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

        List<List<List<double>>> GetSteps(List<List<double>> Points, MathParser Parser, string Function, double Start, double End, int Accuracy)
        {
            List<List<List<double>>> Steps = new List<List<List<double>>>();
            List<List<double>> BorderPoints = new List<List<double>>();
            List<List<double>> AllMinimumPoints = new List<List<double>>();
            double Precision = 1 / Math.Pow(10, Accuracy);
            double Delta = (3 - Math.Sqrt(5)) / 2;
            double X1 = Start + Delta * (End - Start), X2 = End - Delta * (End - Start);

            for (int i = 0; End - Start > Precision; i++)
            {
                List<double> FirstPoint = GetPoint(Parser, Function, X1);
                double Y1 = FirstPoint[1];

                List<double> SecondPoint = GetPoint(Parser, Function, X2);
                double Y2 = SecondPoint[1];

                if (Y1 <= Y2)
                {
                    End = X2;
                    X2 = X1;
                    X1 = Start + End - X2;
                }
                else
                {
                    Start = X1;
                    X1 = X2;
                    X2 = Start + End - X1;
                }

                BorderPoints = new List<List<double>>();
                BorderPoints.Add(FirstPoint);
                BorderPoints.Add(SecondPoint);
                Steps.Add(BorderPoints); 
            }

            return Steps;
        }

        List<double> GetMinimumPoint(List<List<double>> Points, MathParser Parser, string Function, double Start, double End, int Accuracy)
        {
            List<List<double>> BorderPoints = new List<List<double>>();
            List<List<double>> AllMinimumPoints = new List<List<double>>();
            double Precision = 1 / Math.Pow(10, Accuracy);
            double Delta = (3 - Math.Sqrt(5)) / 2;
            double X1 = Start + Delta * (End - Start), X2 = End - Delta * (End - Start);

            for (int i = 0; End - Start > Precision; i++)
            {
                List<double> FirstPoint = GetPoint(Parser, Function, X1);
                double Y1 = FirstPoint[1];

                List<double> SecondPoint = GetPoint(Parser, Function, X2);
                double Y2 = SecondPoint[1];

                if (Y1 <= Y2)
                {
                    End = X2;
                    X2 = X1;
                    X1 = Start + End - X2;
                }
                else
                {
                    Start = X1;
                    X1 = X2;
                    X2 = Start + End - X1;
                }

                BorderPoints = new List<List<double>>();
                BorderPoints.Add(FirstPoint);
                BorderPoints.Add(SecondPoint);
            }
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Step = 0;
            ChartRefresh();
            AnswerLabel.Text = "";
            FunctionTextBox.Text = "";
            StartTextBox.Text = "";
            EndTextBox.Text = "";
            AccuracyTextBox.Text = "";
            StepBack.Enabled = false;
            StepNext.Enabled = false;
        }

        private void StepNext_Click(object sender, EventArgs e)
        {
            List<List<double>> BorderPoints = Steps[Step];
            Invoke(new Action(() => DrawChart(Points, BorderPoints)));

            if (Steps.Count > Step + 1)
            {
                Step += 1;
                StepNext.Enabled = true;
            } else
            {
                StepNext.Enabled = false;
            }

            if (Step != 0)
            {
                StepBack.Enabled = true;
            }
        }

        private void StepBack_Click(object sender, EventArgs e)
        {
            List<List<double>> BorderPoints = Steps[Step];
            Invoke(new Action(() => DrawChart(Points, BorderPoints)));

            if (Step != 0)
            {
                Step -= 1;
                StepBack.Enabled = true;
            }
            else
            {
                StepNext.Enabled = true;
            }
        }
    }
}
