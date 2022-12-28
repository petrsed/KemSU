using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sedelnikov_4
{
    public partial class Form1 : Form
    {
        int RamdomMinNumber = 100;
        int RamdomMaxNumber = 999;
        int RamdomNumberQuantity = 60;
        bool Started = false;
        bool Status = true;
        public Form1()
        {
            InitializeComponent();
        }

        public class Data
        {
            public static bool Started = false;
            public static bool Status = true;
        }

        private void TableAddPoint(object sender, DataGridViewCellEventArgs e)
        {
            List<double> Points = GetAllPoints();
            DrawPoints(Points);
        }

        void DrawPoints(List<double> Points)
        {
            DrawChartPoints(BubbleChart, Points);
            DrawChartPoints(InsertsChart, Points);
            DrawChartPoints(ShakerChart, Points);
            DrawChartPoints(FastChart, Points);
            DrawChartPoints(BogoChart, Points);
        }

        List<double> GetAllPoints()
        {
            List<double> Points = new List<double>();

            for (int RowCount = 0; RowCount < Table.RowCount; RowCount++)
            {
                try
                {
                    var Row = Table.Rows[RowCount];
                    var CellValue = Row.Cells[0].EditedFormattedValue;
                    string CellValueLine = CellValue.ToString();
                    double Number = Double.Parse(CellValueLine);

                    Points.Add(Number);
                }
                catch
                {
                    continue;
                }
            }

            return Points;
        }

        void DrawChartPoints(Chart ChartObj, List<double> Points)
        {
            ChartObj.Series[0].Points.Clear();

            foreach (double Point in Points.ToList())
            {
                ChartObj.Series[0].Points.Add(Point);
            }

            ChartObj.Series[0].Points.ResumeUpdates();
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            if (Started && Status)
            {
                Status = false;
                Thread.Sleep(100);
            }

            Started = true;
            Status = true;
            List<double> Points = GetAllPoints();
            ClearResultLines();
            int Pause = PauseBar.Value;
            bool Reverse = ReversStatus.Checked;
            bool NowStarted = false;

            if (Points.Count > 0)
            {
                try
                {
                    if (BubbleStatus.Checked)
                    {
                        Thread BubbleSortThread = new Thread(() => StartBubbleSort(BubbleChart, Points.ToList(), Pause, Reverse));
                        BubbleSortThread.Start();
                        NowStarted = true;
                    }

                    if (InsertsStatus.Checked)
                    {
                        Thread InsertSortThread = new Thread(() => StartInsertsSort(InsertsChart, Points.ToList(), Pause, Reverse));
                        InsertSortThread.Start();
                        NowStarted = true;
                    }

                    if (ShakerStatus.Checked)
                    {
                        Thread ShakerSortThread = new Thread(() => StartShakerSort(ShakerChart, Points.ToList(), Pause, Reverse));
                        ShakerSortThread.Start();
                        NowStarted = true;
                    }

                    if (FastStatus.Checked)
                    {
                        Thread FastSortThread = new Thread(() => StartFastSort(FastChart, Points.ToList(), Pause, Reverse));
                        FastSortThread.Start();
                        NowStarted = true;
                    }

                    if (BogoStatus.Checked)
                    {
                        Thread BogoSortThread = new Thread(() => StartBogoSort(BogoChart, Points.ToList(), Pause, Reverse));
                        BogoSortThread.Start();
                        NowStarted = true;
                    }

                    if (!NowStarted)
                    {
                        MessageBox.Show("Выберите хотя бы один тип сортировки!");
                    } else
                    {
                        GenerateDataButton.Enabled = false;
                        ClearButton.Enabled = true;
                    }
                } catch
                {
                    Data.Started = false;
                    BubbleChart.Series[0].Points.Clear();
                    Table.Rows.Clear();
                    MessageBox.Show("Операция прервана!");
                }
            } else
            {
                MessageBox.Show("Добавьте хотя бы одну точку!");
            }
        }


        int BubbleSort(Chart ChartObj, List<double> BubblePoints, int Pause, bool Reverse)
        {
            double Temp;
            Stopwatch Timer = new Stopwatch();
            Timer.Start();

            for (int FirstIndex = 0; FirstIndex < BubblePoints.Count; FirstIndex++)
            {
                for (int SecondIndex = FirstIndex + 1; SecondIndex < BubblePoints.Count; SecondIndex++)
                {
                    if (BubblePoints[FirstIndex] > BubblePoints[SecondIndex])
                    {
                        Temp = BubblePoints[FirstIndex];
                        BubblePoints[FirstIndex] = BubblePoints[SecondIndex];
                        BubblePoints[SecondIndex] = Temp;

                        Timer.Stop();
                        
                        Invoke(new Action(() => {
                            DrawChartPoints(ChartObj, BubblePoints);
                        }));

                        Thread.Sleep(Pause);
                        Timer.Start();

                        if (!Status)
                        {
                            Thread CurrentThread = Thread.CurrentThread;
                            CurrentThread.Abort();
                        }
                    }
                }
            }

            Invoke(new Action(() => {
                DrawChartPoints(ChartObj, BubblePoints);
            }));

            Timer.Stop();
            int TimerMilliSeconds = Convert.ToInt32(Timer.ElapsedMilliseconds);

            return TimerMilliSeconds;
        }


        int BubbleSortReverse(Chart ChartObj, List<double> Points, int Pause, bool Reverse)
        {
            double Temp;
            Stopwatch Timer = new Stopwatch();
            Timer.Start();

            for (int FirstIndex = 0; FirstIndex < Points.Count; FirstIndex++)
            {
                for (int SecondIndex = FirstIndex + 1; SecondIndex < Points.Count; SecondIndex++)
                {
                    if (Points[FirstIndex] < Points[SecondIndex])
                    {
                        Temp = Points[FirstIndex];
                        Points[FirstIndex] = Points[SecondIndex];
                        Points[SecondIndex] = Temp;

                        Timer.Stop();
                        Invoke(new Action(() => {
                            DrawChartPoints(ChartObj, Points);
                        }));
                        Thread.Sleep(Pause);
                        Timer.Start();

                        if (!Status)
                        {
                            Thread CurrentThread = Thread.CurrentThread;
                            CurrentThread.Abort();
                        }
                    }
                }
            }

            Invoke(new Action(() => {
                DrawChartPoints(ChartObj, Points);
            }));

            Timer.Stop();
            int TimerMilliSeconds = Convert.ToInt32(Timer.ElapsedMilliseconds);

            return TimerMilliSeconds;
        }

        void StartBubbleSort(Chart ChartObj, List<double> Points, int Pause, bool Reverse)
        {
            int AmountPoints = Points.Count;
            int ResultTime;

            if (!Reverse)
            {
                ResultTime = BubbleSort(ChartObj, Points, Pause, Reverse);
            }
            else
            {
                ResultTime = BubbleSortReverse(ChartObj, Points, Pause, Reverse);
            }

            Invoke(new Action(() => {
                BubbleResultLine.Text = $"({ResultTime} мс.)";
            }));
        }
    

    int InsertsSort(Chart ChartObj, List<double> Points, int Pause, bool Reverse)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();

            for (int FirstIndex = 1; FirstIndex < Points.Count; FirstIndex++)
            {
                double Temp = Points[FirstIndex];
                int SecondIndex = FirstIndex - 1;

                while (SecondIndex >= 0 && Points[SecondIndex] > Temp)
                {
                    Points[SecondIndex + 1] = Points[SecondIndex];
                    Points[SecondIndex] = Temp;
                    SecondIndex--;

                    Timer.Stop();
                    Invoke(new Action(() => {
                        DrawChartPoints(ChartObj, Points);
                    }));
                    Thread.Sleep(Pause);
                    Timer.Start();

                    if (!Status)
                    {
                        Thread CurrentThread = Thread.CurrentThread;
                        CurrentThread.Abort();
                    }
                }
            }

            Timer.Stop();
            int TimerMilliSeconds = Convert.ToInt32(Timer.ElapsedMilliseconds);

            return TimerMilliSeconds;
        }

        int InsertsSortReverse(Chart ChartObj, List<double> Points, int Pause, bool Reverse)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();

            for (int FirstIndex = 1; FirstIndex < Points.Count; FirstIndex++)
            {
                double Temp = Points[FirstIndex];
                int SecondIndex = FirstIndex - 1;

                while (SecondIndex >= 0 && Points[SecondIndex] < Temp)
                {
                    Points[SecondIndex + 1] = Points[SecondIndex];
                    Points[SecondIndex] = Temp;
                    SecondIndex--;

                    Timer.Stop();
                    Invoke(new Action(() => {
                        DrawChartPoints(ChartObj, Points);
                    }));
                    Thread.Sleep(Pause);
                    Timer.Start();

                    if (!Status)
                    {
                        Thread CurrentThread = Thread.CurrentThread;
                        CurrentThread.Abort();
                    }
                }
            }

            Timer.Stop();
            int TimerMilliSeconds = Convert.ToInt32(Timer.ElapsedMilliseconds);

            return TimerMilliSeconds;
        }


        void StartInsertsSort(Chart ChartObj, List<double> Points, int Pause, bool Reverse)
        {
            int AmountPoints = Points.Count;
            int ResultTime;

            if (!Reverse)
            {
                ResultTime = InsertsSort(ChartObj, Points, Pause, Reverse);
            }
            else
            {
                ResultTime = InsertsSortReverse(ChartObj, Points, Pause, Reverse);
            }

            Invoke(new Action(() => {
                InsertsResultLine.Text = $"({ResultTime} мс.)";
            }));
        }

        int ShakerSort(Chart ChartObj, List<double> Points, int Pause, bool Reverse)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();

            int LeftIndex = 0;
            int RightIndex = Points.Count - 1;
            double Temp;

            while (LeftIndex < RightIndex)
            {
                for (int FirstIndex = LeftIndex; FirstIndex < RightIndex; FirstIndex++)
                {
                    if (Points[FirstIndex] > Points[FirstIndex + 1])
                    {
                        Temp = Points[FirstIndex];
                        Points[FirstIndex] = Points[FirstIndex + 1];
                        Points[FirstIndex + 1] = Temp;

                        Timer.Stop();
                        Invoke(new Action(() => {
                            DrawChartPoints(ChartObj, Points);
                        }));
                        Thread.Sleep(Pause);
                        Timer.Start();

                        if (!Status)
                        {
                            Thread CurrentThread = Thread.CurrentThread;
                            CurrentThread.Abort();
                        }
                    }
                }
                RightIndex--;

                for (int SecondIndex = RightIndex; SecondIndex > LeftIndex; SecondIndex--)
                {
                    if (Points[SecondIndex - 1] > Points[SecondIndex])
                    {
                        Temp = Points[SecondIndex - 1];
                        Points[SecondIndex - 1] = Points[SecondIndex];
                        Points[SecondIndex] = Temp;

                        Timer.Stop();
                        Invoke(new Action(() => {
                            DrawChartPoints(ChartObj, Points);
                        }));
                        Thread.Sleep(Pause);
                        Timer.Start();

                        if (!Status)
                        {
                            Thread CurrentThread = Thread.CurrentThread;
                            CurrentThread.Abort();
                        }
                    }
                }
                LeftIndex++;
            }

            Timer.Stop();
            int TimerMilliSeconds = Convert.ToInt32(Timer.ElapsedMilliseconds);

            return TimerMilliSeconds;
        }

        int ShakerSortReverse(Chart ChartObj, List<double> Points, int Pause, bool Reverse)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            int LeftIndex = 0;
            int RightIndex = Points.Count - 1;
            double Temp;

            while (LeftIndex < RightIndex)
            {
                for (int FirstIndex = LeftIndex; FirstIndex < RightIndex; FirstIndex++)
                {
                    if (Points[FirstIndex] < Points[FirstIndex + 1])
                    {
                        Temp = Points[FirstIndex];
                        Points[FirstIndex] = Points[FirstIndex + 1];
                        Points[FirstIndex + 1] = Temp;

                        Timer.Stop();
                        Invoke(new Action(() => {
                            DrawChartPoints(ChartObj, Points);
                        }));
                        Thread.Sleep(Pause);
                        Timer.Start();

                        if (!Status)
                        {
                            Thread CurrentThread = Thread.CurrentThread;
                            CurrentThread.Abort();
                        }
                    }
                }
                RightIndex--;

                for (int SecondIndex = RightIndex; SecondIndex > LeftIndex; SecondIndex--)
                {
                    if (Points[SecondIndex - 1] < Points[SecondIndex])
                    {
                        Temp = Points[SecondIndex - 1];
                        Points[SecondIndex - 1] = Points[SecondIndex];
                        Points[SecondIndex] = Temp;

                        Timer.Stop();
                        Invoke(new Action(() => {
                            DrawChartPoints(ChartObj, Points);
                        }));
                        Thread.Sleep(Pause);
                        Timer.Start();

                        if (!Status)
                        {
                            Thread CurrentThread = Thread.CurrentThread;
                            CurrentThread.Abort();
                        }
                    }
                }
                LeftIndex++;
            }

            Timer.Stop();
            int TimerMilliSeconds = Convert.ToInt32(Timer.ElapsedMilliseconds);

            return TimerMilliSeconds;
        }

        void StartShakerSort(Chart ChartObj, List<double> Points, int Pause, bool Reverse)
        {
            int AmountPoints = Points.Count;
            int ResultTime;

            if (!Reverse)
            {
                ResultTime = ShakerSort(ChartObj, Points, Pause, Reverse);
            }
            else
            {
                ResultTime = ShakerSortReverse(ChartObj, Points, Pause, Reverse);
            }

            Invoke(new Action(() => {
                ShakerResultLine.Text = $"({ResultTime} мс.)";
            }));
        }

        List<double> FastSort(List<double> Points, int LeftIndex, int RightIndex, Chart ChartObj, int Pause, bool Reverse, Stopwatch Timer)
        {
            Timer.Start();
            var FirstIndex = LeftIndex;
            var SecondIndex = RightIndex;
            var Pivot = Points[LeftIndex];
            while (FirstIndex <= SecondIndex)
            {
                while (Points[FirstIndex] < Pivot)
                {
                    FirstIndex++;
                }

                while (Points[SecondIndex] > Pivot)
                {
                    SecondIndex--;
                }
                if (FirstIndex <= SecondIndex)
                {
                    double Temp = Points[FirstIndex];
                    Points[FirstIndex] = Points[SecondIndex];
                    Points[SecondIndex] = Temp;
                    FirstIndex++;
                    SecondIndex--;
                }
            }

            if (LeftIndex < SecondIndex)
            {
                Timer.Stop();
                Invoke(new Action(() => {
                    DrawChartPoints(ChartObj, Points);
                }));

                Thread.Sleep(Pause);
                FastSort(Points, LeftIndex, SecondIndex, ChartObj, Pause, Reverse, Timer);
                Timer.Start();

                if (!Status)
                {
                    Thread CurrentThread = Thread.CurrentThread;
                    CurrentThread.Abort();
                }
            }
            if (FirstIndex < RightIndex)
            {
                Timer.Stop();
                Invoke(new Action(() => {
                    DrawChartPoints(ChartObj, Points);
                }));

                Thread.Sleep(Pause);
                FastSort(Points, FirstIndex, RightIndex, ChartObj, Pause, Reverse, Timer);
                Timer.Start();

                if (!Status)
                {
                    Thread CurrentThread = Thread.CurrentThread;
                    CurrentThread.Abort();
                }
            }

            Timer.Stop();
            return Points;
        }

        List<double> FastSortReverse(List<double> Points, int LeftIndex, int RightIndex, Chart ChartObj, int Pause, bool Reverse, Stopwatch Timer)
        {
            Timer.Start();
            var FirstIndex = LeftIndex;
            var SecondIndex = RightIndex;
            var Pivot = Points[LeftIndex];
            while (FirstIndex <= SecondIndex)
            {
                while (Points[FirstIndex] > Pivot)
                {
                    FirstIndex++;
                }

                while (Points[SecondIndex] < Pivot)
                {
                    SecondIndex--;
                }
                if (FirstIndex <= SecondIndex)
                {
                    double Temp = Points[FirstIndex];
                    Points[FirstIndex] = Points[SecondIndex];
                    Points[SecondIndex] = Temp;
                    FirstIndex++;
                    SecondIndex--;
                }
            }

            if (LeftIndex < SecondIndex)
            {
                Timer.Stop();
                Invoke(new Action(() => {
                    DrawChartPoints(ChartObj, Points);
                }));

                Thread.Sleep(Pause);
                FastSortReverse(Points, LeftIndex, SecondIndex, ChartObj, Pause, Reverse, Timer);
                Timer.Start();

                if (!Status)
                {
                    Thread CurrentThread = Thread.CurrentThread;
                    CurrentThread.Abort();
                }
            }
            if (FirstIndex < RightIndex)
            {
                Timer.Stop();
                Invoke(new Action(() => {
                    DrawChartPoints(ChartObj, Points);
                }));

                Thread.Sleep(Pause);
                FastSortReverse(Points, FirstIndex, RightIndex, ChartObj, Pause, Reverse, Timer);
                Timer.Start();

                if (!Status)
                {
                    Thread CurrentThread = Thread.CurrentThread;
                    CurrentThread.Abort();
                }
            }

            Timer.Stop();
            return Points;
        }

        void StartFastSort(Chart ChartObj, List<double> Points, int Pause, bool Reverse)
        {
            int AmountPoints = Points.Count;
            Stopwatch Timer = new Stopwatch();
            List<double> ResultPoints;

            if (!Reverse)
            {
                ResultPoints = FastSort(Points, 0, Points.Count - 1, ChartObj, Pause, Reverse, Timer);
            }
            else
            {
                ResultPoints = FastSortReverse(Points, 0, Points.Count - 1, ChartObj, Pause, Reverse, Timer);
            }

            Invoke(new Action(() => {
                DrawChartPoints(ChartObj, ResultPoints);
            }));

            Timer.Stop();
            int TimerMilliSeconds = Convert.ToInt32(Timer.ElapsedMilliseconds);

            Invoke(new Action(() => {
                FastResultLine.Text = $"({TimerMilliSeconds} мс.)";
            }));
        }

        void StartBogoSort(Chart ChartObj, List<double> Points, int Pause, bool Reverse)
        {
            int AmountPoints = Points.Count;
            int ResultTime;

            if (!Reverse)
            {
                ResultTime = BogoSort(ChartObj, Points, Pause, Reverse);
            }
            else
            {
                ResultTime = BogoSortReverse(ChartObj, Points, Pause, Reverse);
            }

            Invoke(new Action(() => {
                BogoResultLine.Text = $"({ResultTime} мс.)";
            }));
        }

        void ClearResultLines()
        {
            BubbleResultLine.Text = "";
            InsertsResultLine.Text = "";
            ShakerResultLine.Text = "";
            FastResultLine.Text = "";
            BogoResultLine.Text = "";
        }

        int BogoSort(Chart ChartObj, List<double> Points, int Pause, bool Reverse)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();

            while (!IsSorted(Points)) {
                Timer.Stop();
                Invoke(new Action(() => {
                    DrawChartPoints(ChartObj, Points);
                }));
                Thread.Sleep(Pause);
                Timer.Start();
                Shuffle(Points);

                if (!Status)
                {
                    Thread CurrentThread = Thread.CurrentThread;
                    CurrentThread.Abort();
                }
            }

            Timer.Stop();
            int TimerMilliSeconds = Convert.ToInt32(Timer.ElapsedMilliseconds);

            Invoke(new Action(() => {
                DrawChartPoints(ChartObj, Points);
            }));

            return TimerMilliSeconds;
        }

        int BogoSortReverse(Chart ChartObj, List<double> Points, int Pause, bool Reverse)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();

            while (!IsSortedReverse(Points))
            {
                Timer.Stop();
                Invoke(new Action(() => {
                    DrawChartPoints(ChartObj, Points);
                }));
                Thread.Sleep(Pause);
                Timer.Start();
                Shuffle(Points);

                if (!Status)
                {
                    Thread CurrentThread = Thread.CurrentThread;
                    CurrentThread.Abort();
                }
            }

            Timer.Stop();
            int TimerMilliSeconds = Convert.ToInt32(Timer.ElapsedMilliseconds);

            return TimerMilliSeconds;
        }

        bool IsSorted(List<double> Points)
        {
            int Count = Points.Count;

            while (--Count >= 1)
                if (Points[Count] < Points[Count - 1])
                {
                    return false;
                }

            return true;
        }

        bool IsSortedReverse(List<double> Points)
        {
            int Count = Points.Count;

            while (--Count >= 1)
                if (Points[Count] > Points[Count - 1])
                {
                    return false;
                }

            return true;
        }

        void Shuffle(List<double> Points)
        {
            double Temp;
            int RandomIndex;
            Random rand = new Random();

            for (int FirstIndex = 0; FirstIndex < Points.Count; ++FirstIndex)
            {
                RandomIndex = rand.Next(Points.Count);
                Temp = Points[FirstIndex];
                Points[FirstIndex] = Points[RandomIndex];
                Points[RandomIndex] = Temp;
            }
        }

        void ClearCharts()
        {
            ClearChart(BubbleChart);
            ClearChart(InsertsChart);
            ClearChart(ShakerChart);
            ClearChart(FastChart);
            ClearChart(BogoChart);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearButton.Enabled = false;
            GenerateDataButton.Enabled = true;

            Status = false;
            ClearResultLines();
            ClearCharts();
            ClearTable();
            MessageBox.Show("Операция прервана!");
            ClearCharts();
        }

        private void ClearChart(System.Windows.Forms.DataVisualization.Charting.Chart Chart)
        {
            Chart.Series[0].Points.Clear();
            Chart.Refresh();
        }

        private void Chart_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void ClearTable()
        {
            Table.Rows.Clear();
        }

        private void GenerateDataButton_Click(object sender, EventArgs e)
        {
            ClearTable();
            Random rng = new Random();

            for (int RowIndex = 0; RowIndex < RamdomNumberQuantity; RowIndex++)
            {
                int Number = rng.Next(RamdomMinNumber, RamdomMaxNumber);
                Table.Rows.Add();
                Table.Rows[RowIndex].Cells[0].Value = Number.ToString();
            }

            List<double> Points = GetAllPoints();
            DrawPoints(Points);

            ClearButton.Enabled = true;
        }
    }
}
