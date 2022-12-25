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
using MathNet.Numerics.Integration;

namespace Sedelnikov_5
{
    public partial class Form1 : Form
    {

        string FunctionLine;
        MathParser Parser = new MathParser();
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

            FunctionLine = "";
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
                    MessageBox.Show("Ошибка формата числа N!");
                    return;
                }

                if (StepsQuantity < 1 || StepsQuantity > 100000)
                {
                    MessageBox.Show("Ошибка формата числа N! Число должно быть в отрезке [1:100000]");
                    return;
                }

                if (Start < -1000000 || Start > 1000000)
                {
                    MessageBox.Show("Ошибка формата числа a! Число должно быть в отрезке [-1000000:1000000]");
                    return;
                }

                if (End < -1000000 || End > 1000000)
                {
                    MessageBox.Show("Ошибка формата числа b! Число должно быть в отрезке [-1000000:1000000]");
                    return;
                }
            }

            Function = FunctionBox.Text.Replace("x", "(x)");
            FunctionLine = Function;

            if (Debug)
            {
                Function = "sin(x)";
                Start = 0;
                End = 5;
                StepsQuantity = 10;
            }

            Calculate(Function, Start, End, StepsQuantity);
        }

        void Calculate(string Function, double Start, double End, int StepsQuantity)
        {
            FunctionLine = Function;
            try
            {
                List<double> TestPoint = GetPoint(1);
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
            List<List<List<double>>> RectanglesFigures = GetRectanglesMethodFigures(Parser, Function, Start, End, StepsQuantity);

            double TrapezoidsValue = GetTrapezoidsMethodValue(Parser, Function, Start, End, StepsQuantity);
            List<List<List<double>>> TrapezoidsFigures = GetTrapezoidsMethodFigures(Parser, Function, Start, End, StepsQuantity);

            double ParabolasValue = GetParabolasMethodValue(Parser, Function, Start, End, StepsQuantity);
            double ExactValue = GetExactMethodValue(Parser, Function, Start, End);

            RectanglesAnswer.Text = RectanglesValue.ToString();
            TrapezoidsAnswer.Text = TrapezoidsValue.ToString();
            ParabolasAnswer.Text = ParabolasValue.ToString();
            ExactAnswer.Text = ExactValue.ToString();

            List<List<double>> Points = GetPoints(Start, End, PointsQuantity);
            DrawGraphic(Points, Start, End, RectanglesFigures, TrapezoidsFigures);
        }

        List<List<List<double>>> GetRectanglesMethodFigures(MathParser Parser, string Function, double Start, double End, int StepsQuantity)
        {
            List<List<List<double>>> Figures = new List<List<List<double>>>();
            double Step = (End - Start) / (StepsQuantity - 1);
            double X0 = Start;
            double X1, Y1, StepSquare;

            for (int StepIndex = 0; StepIndex < StepsQuantity - 1; StepIndex++)
            {
                List<List<double>> Figure = new List<List<double>>();

                X1 = X0 + Step;
                Y1 = GetPoint(X1)[1];

                List<double> PointLeftBottom = new List<double>();
                PointLeftBottom.Add(X0);
                PointLeftBottom.Add(0);

                List<double> PointRightBottom = new List<double>();
                PointRightBottom.Add(X1);
                PointRightBottom.Add(0);

                List<double> PointLeftTop = new List<double>();
                PointLeftTop.Add(X0);
                PointLeftTop.Add(Y1);

                List<double> PointRightTop = new List<double>();
                PointRightTop.Add(X1);
                PointRightTop.Add(Y1);

                Figure.Add(PointLeftTop);
                Figure.Add(PointRightTop);
                Figure.Add(PointLeftBottom);
                Figure.Add(PointRightBottom);

                Figures.Add(Figure);

                X0 += Step;
            }

            return Figures;
        }

        List<List<List<double>>> GetTrapezoidsMethodFigures(MathParser Parser, string Function, double Start, double End, int StepsQuantity)
        {
            List<List<List<double>>> Figures = new List<List<List<double>>>();

            double Step = (End - Start) / (StepsQuantity - 1);
            double Square = 0;
            double X0 = Start;
            double X1, Y0, Y1, StepSquare;

            for (int StepIndex = 0; StepIndex < StepsQuantity - 1; StepIndex++)
            {
                List<List<double>> Figure = new List<List<double>>();

                X1 = X0 + Step;
                Y0 = GetPoint(X0)[1];
                Y1 = GetPoint(X1)[1];

                List<double> PointLeftBottom = new List<double>();
                PointLeftBottom.Add(X0);
                PointLeftBottom.Add(0);

                List<double> PointRightBottom = new List<double>();
                PointRightBottom.Add(X1);
                PointRightBottom.Add(0);

                List<double> PointLeftTop = new List<double>();
                PointLeftTop.Add(X0);
                PointLeftTop.Add(Y0);

                List<double> PointRightTop = new List<double>();
                PointRightTop.Add(X1);
                PointRightTop.Add(Y1);

                Figure.Add(PointLeftTop);
                Figure.Add(PointRightTop);
                Figure.Add(PointLeftBottom);
                Figure.Add(PointRightBottom);

                Figures.Add(Figure);

                X0 += Step;
            }

            return Figures;
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
                Y1 = Math.Abs(GetPoint(X1)[1]);

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
                Y0 = Math.Abs(GetPoint(X0)[1]);

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

            double StartY = Math.Abs(GetPoint(Start)[1]);

            double EndY = Math.Abs(GetPoint(End - Step)[1]);

            if (EndY is Double.NaN)
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
                Y0 = Math.Abs(GetPoint(X0)[1]);

                if (Y0 < 0 || Y0 is Double.NaN)
                {
                    Y0 = 0;
                }

                Y1 = Math.Abs(GetPoint(X1)[1]);

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

        double GetExactMethodValue(MathParser Parser, string Function, double Start, double End)
        {
            double StartY = GetY(Start);

            if (StartY == 0)
            {
                Start = GetFirstNoZeroX(Start, End);
            }

            double Square = NewtonCotesTrapeziumRule.IntegrateAdaptive(GetExactY, Start, End, 1e-5);

            return Square;
        }

        double GetFirstNoZeroX(double Start, double End)
        {
            double NowX = Start;
            double NowY;

            while (NowX < End)
            {
                NowY = GetY(NowX);

                if (NowY > 0)
                {
                    return NowX;
                }
                else
                {
                    NowX += 0.00001;
                }
            }

            return -1;
        }

        double GetY(double X)
        {
            string NowFunction = String.Copy(FunctionLine).ToLower();
            NowFunction = NowFunction.Replace("x", X.ToString());

            double Y = Parser.Parse(NowFunction, true);

            return Y;
        }

        double GetExactY(double X)
        {
            string NowFunction = String.Copy(FunctionLine).ToLower();
            NowFunction = NowFunction.Replace("x", X.ToString());

            double Y = Math.Abs(Parser.Parse(NowFunction, true));

            if (Y < 0 || Y is Double.NaN)
            {
                Y = 0;
            }

            return Y;
        }


        List<double> GetPoint(double X)
        {
            List<double> Point = new List<double>();
            double Y = GetY(X);

            Point.Add(X);
            Point.Add(Math.Round(Y, 8));

            return Point;
        }

        List<List<double>> GetPoints(double Start, double End, double AmountPoints)
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
                List<double> Point = GetPoint(X);
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
                List<double> Point = GetPoint(End);
                Points.Add(Point);
                XPoints.Add(End);
            }

            return Points;
        }

        void DrawGraphic(List<List<double>> Points, double Start, double End, List<List<List<double>>> RectanglesFigures, List<List<List<double>>> TrapezoidsFigures)
        {
            PlotModel Model = new PlotModel();
            FunctionSeries FunctionLine = new FunctionSeries { Color = OxyColors.Red };
            LineAnnotation BottomBorderLine = new LineAnnotation() { Y = 0, Color = OxyColors.Blue };
            LineAnnotation LeftBorderLine = new LineAnnotation() { X = Start, Color = OxyColors.Blue, Type = LineAnnotationType.Vertical };
            LineAnnotation RightBorderLine = new LineAnnotation() { X = End, Color = OxyColors.Blue, Type = LineAnnotationType.Vertical };

            double X0, X1, Y0, Y1;

            foreach (List<List<double>> RectanglesFigure in RectanglesFigures)
            {
                X0 = RectanglesFigure[2][0];
                X1 = RectanglesFigure[3][0];
                Y0 = RectanglesFigure[0][1];
                Y1 = RectanglesFigure[1][1];

                //Model.Annotations.Add(new RectangleAnnotation { MinimumX = X0, MaximumX = X1, MinimumY = 0, MaximumY = Y1, Stroke = OxyColors.Black, StrokeThickness = 1 });
                var Event = new PolygonAnnotation();

                Event.Layer = AnnotationLayer.BelowAxes;
                Event.StrokeThickness = 1;
                Event.Stroke = OxyColor.FromRgb(0, 0, 255);
                Event.LineStyle = LineStyle.Automatic;

                Event.Points.Add(new DataPoint(RectanglesFigure[2][0], RectanglesFigure[2][1]));
                Event.Points.Add(new DataPoint(RectanglesFigure[3][0], RectanglesFigure[3][1]));
                Event.Points.Add(new DataPoint(RectanglesFigure[1][0], RectanglesFigure[1][1]));
                Event.Points.Add(new DataPoint(RectanglesFigure[0][0], RectanglesFigure[0][1]));

                Model.Annotations.Add(Event);
            }

            foreach (List<List<double>> TrapezoidsFigure in TrapezoidsFigures)
            {
                var Event = new PolygonAnnotation();

                Event.Layer = AnnotationLayer.BelowAxes;
                Event.StrokeThickness = 1;
                Event.Stroke = OxyColor.FromRgb(0, 255, 0);
                Event.LineStyle = LineStyle.Automatic;

                Event.Points.Add(new DataPoint(TrapezoidsFigure[2][0], TrapezoidsFigure[2][1]));
                Event.Points.Add(new DataPoint(TrapezoidsFigure[3][0], TrapezoidsFigure[3][1]));
                Event.Points.Add(new DataPoint(TrapezoidsFigure[1][0], TrapezoidsFigure[1][1]));
                Event.Points.Add(new DataPoint(TrapezoidsFigure[0][0], TrapezoidsFigure[0][1]));

                Model.Annotations.Add(Event);
            }

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

            Model.Annotations.Add(BottomBorderLine);
            Model.Annotations.Add(LeftBorderLine);
            Model.Annotations.Add(RightBorderLine);
            Model.Series.Add(FunctionLine);
            Graphic.Model = Model;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
