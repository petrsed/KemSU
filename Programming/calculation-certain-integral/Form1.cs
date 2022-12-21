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
using OxyPlot.Annotations;

namespace Sedelnikov_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClearData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        
        void ClearData()
        {
            PlotModel Model = new PlotModel();
            FunctionSeries Series = new FunctionSeries();
            Model.Series.Add(Series);
            Graphic.Model = Model;

            FunctionBox.Text = "";
            StartBox.Text = "";
            EndBox.Text = "";
            FunctionBox.Text = "";

            ExactAnswer.Text = "";
            RectanglesAnswer.Text = "";
            TrapezoidsAnswer.Text = "";
            ParabolasAnswer.Text = "";
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            string Function;
            double Start = 0;
            double End = 0;
            int StepsQuantity = 0;
            bool Debug = false;

            if (!Debug)
            {
                try
                {
                    Start = Convert.ToDouble(StartBox.Text.Replace('.', ','));
                }
                catch
                {
                    MessageBox.Show("Ошибка формата числа a!");
                    return;
                }

                try
                {
                    End = Convert.ToDouble(EndBox.Text.Replace('.', ','));
                }
                catch
                {
                    MessageBox.Show("Ошибка формата числа b!");
                    return;
                }

                try
                {
                    StepsQuantity = Convert.ToInt32(AmountStepsBox.Text.Replace('.', ','));
                }
                catch
                {
                    MessageBox.Show("Ошибка формата числа N!".Replace('.', ','));
                    return;
                }
            }

            Function = FunctionBox.Text.Replace("x", "(x)");

            if (Debug)
            {
                Function = "(e)log(x)*sin(x)";
                Start = 0;
                End = 3.1415;
                StepsQuantity = 10;
            }

            Calculate(Function, Start, End, StepsQuantity);
        }

        void Calculate(string Function, double Start, double End, int StepsQuantity)
        {
            MathParser Parser = new MathParser();

            try
            {
                List<double> TestPoint = GetPoint(Parser, Function, 1);
            }
            catch
            {
                MessageBox.Show("Ошибка в формуле!");
                return;
            }

            if (Start >= End)
            {
                MessageBox.Show("Точка начала не может быть левее точки конца!");
                return;
            }

            double PointsQuantity = 1000;

            double RectanglesValue = GetRectanglesMethodValue(Parser, Function, Start, End, StepsQuantity);
            double TrapezoidsValue = GetTrapezoidsMethodValue(Parser, Function, Start, End, StepsQuantity);
            double ParabolasValue = GetParabolasMethodValue(Parser, Function, Start, End, StepsQuantity);
            double ExactValue = GetExactMethodValue(Parser, Function, Start, End, StepsQuantity);

            RectanglesAnswer.Text = RectanglesValue.ToString();
            TrapezoidsAnswer.Text = TrapezoidsValue.ToString();
            ParabolasAnswer.Text = ParabolasValue.ToString();
            ExactAnswer.Text = ExactValue.ToString();

            List<List<double>> Points = GetPoints(Parser, Function, Start, End, PointsQuantity);
            DrawGraphic(Points, Start, End);
        }

        double GetRectanglesMethodValue(MathParser Parser, string Function, double Start, double End, int StepsQuantity)
        {
            double Step = (End - Start) / (StepsQuantity - 1);
            double Square = 0;
            double X0 = Start;
            double X1, Y1, StepSquare;

            for (int StepIndex = 0; StepIndex < StepsQuantity; StepIndex++)
            {
                X1 = X0 + Step;
                Y1 = GetPoint(Parser, Function, X1)[1];

                if (Y1 < 0 || Y1 is Double.NaN)
                {
                    Y1 = 0;
                }

                StepSquare = Y1 * Step;
                Square += StepSquare;
                X0 += Step;
            }

            return Square;
        }

        double GetParabolasMethodValue(MathParser Parser, string Function, double Start, double End, int StepsQuantity)
        {
            if (StepsQuantity % 2 == 1)
            {
                StepsQuantity++;
            }

            double Step = (End - Start) / (StepsQuantity - 1);
            double Square = 0;
            double X0 = Start;
            double X1, X2, Y0, Y1, Y2, StepSquare;
            int Ratio;


            for (int StepIndex = 0; StepIndex < StepsQuantity; StepIndex++)
            {
                X0 += Step;
                Y0 = GetPoint(Parser, Function, X0)[1];

                if (Y0 < 0 || Y0 is Double.NaN)
                {
                    Y0 = 0;
                }

                if (StepIndex % 2 == 0)
                {
                    Ratio = 4;
                } else
                {
                    Ratio = 2;
                }

                StepSquare = Ratio * Y0;
                Square += StepSquare;
            }

            double StartY = GetPoint(Parser, Function, Start)[1];

            if (StartY < 0 || StartY is Double.NaN)
            {
                StartY = 0;
            }

            double EndY = GetPoint(Parser, Function, End - Step)[1];

            if (EndY < 0 || EndY is Double.NaN)
            {
                EndY = 0;
            }

            Square += StartY;
            Square += EndY;
            Square *= Step / 3;

            return Square;
        }

        double GetTrapezoidsMethodValue(MathParser Parser, string Function, double Start, double End, int StepsQuantity)
        {
            double Step = (End - Start) / (StepsQuantity - 1);
            double Square = 0;
            double X0 = Start;
            double X1, Y0, Y1, StepSquare;

            for (int StepIndex = 0; StepIndex < StepsQuantity; StepIndex++)
            {
                X1 = X0 + Step;
                Y0 = GetPoint(Parser, Function, X0)[1];

                if (Y0 < 0 || Y0 is Double.NaN)
                {
                    Y0 = 0;
                }

                Y1 = GetPoint(Parser, Function, X1)[1];

                if (Y1 < 0 || Y1 is Double.NaN)
                {
                    Y1 = 0;
                }

                StepSquare = 0.5 * (Y0 + Y1) * Step;
                Square += StepSquare;
                X0 += Step;
            }

            return Square;
        }

        double GetExactMethodValue(MathParser Parser, string Function, double Start, double End, int StepsQuantity)
        {
            StepsQuantity *= 100;

            double Step = (End - Start) / (StepsQuantity - 1);
            double Square = 0;
            double X0 = Start;
            double X1, Y0, Y1, StepSquare;

            for (int StepIndex = 0; StepIndex < StepsQuantity; StepIndex++)
            {
                X1 = X0 + Step;
                Y0 = GetPoint(Parser, Function, X0)[1];

                if (Y0 < 0 || Y0 is Double.NaN)
                {
                    Y0 = 0;
                }

                Y1 = GetPoint(Parser, Function, X1)[1];

                if (Y1 < 0 || Y1 is Double.NaN)
                {
                    Y1 = 0;
                }

                StepSquare = 0.5 * (Y0 + Y1) * Step;
                Square += StepSquare;
                X0 += Step;
            }

            return Square;
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

        List<List<double>> GetPoints(MathParser Parser, string Function, double Start, double End, double AmountPoints)
        {
            double Length = End - Start;
            double Margin = Length / 10;

            Start -= Margin;
            End += Margin;

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

        void DrawGraphic(List<List<double>> Points, double Start, double End)
        {
            PlotModel Model = new PlotModel();
            FunctionSeries FunctionLine = new FunctionSeries { Color = OxyColors.Red };
            LineAnnotation BottomBorderLine = new LineAnnotation() { Y = 0, Color = OxyColors.Blue };
            LineAnnotation LeftBorderLine = new LineAnnotation() { X = Start, Color = OxyColors.Blue, Type = LineAnnotationType.Vertical };
            LineAnnotation RightBorderLine = new LineAnnotation() { X = End, Color = OxyColors.Blue, Type = LineAnnotationType.Vertical };

            foreach (List<double> Point in Points)
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

            Model.Series.Add(FunctionLine);
            Model.Annotations.Add(BottomBorderLine);
            Model.Annotations.Add(LeftBorderLine);
            Model.Annotations.Add(RightBorderLine);
            Graphic.Model = Model;
        }
    }
}
