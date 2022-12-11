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

namespace Sedelnikov_4
{
    public partial class Form1 : Form
    {
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

            //List<double> PointsList = new List<double>() { 7, 4, 0, 5, 3, 1, 9, 4 };

            return Points;
        }

        void DrawPoints(List<double> Points)
        {
            Chart.Series[0].Points.Clear();

            foreach (double Point in Points)
            {
                Chart.Series[0].Points.Add(Point);
            }

            Chart.Series[0].Points.ResumeUpdates();
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            List<double> Points = GetAllPoints();
            int Pause = PauseBar.Value;
            bool Reverse = ReversStatus.Checked;

            if (Points.Count > 0)
            {
                try
                {
                    Stopwatch Timer = new Stopwatch();
                    Timer.Start();
                    Data.Started = true;
                    Data.Status = true;

                    List<double> TempPoints;
                    var ProgressObj = new Progress<List<double>>(DrawPoints);
                    List<double> ResultPoints = await Task.Run(() => Start(ProgressObj, Points, Pause, Reverse));
                    DrawPoints(ResultPoints);

                    Timer.Stop();
                    double TimerSecondsDouble = Timer.ElapsedMilliseconds / 1000;
                    int TimerSeconds = Convert.ToInt32(Math.Round(TimerSecondsDouble));
                    MessageBox.Show($"Сортировка завершена за {TimerSeconds} секунд!");
                    Data.Started = false;
                } catch
                {
                    Data.Started = false;
                    Chart.Series[0].Points.Clear();
                    Table.Rows.Clear();
                    MessageBox.Show("Операция прервана!");
                }
            } else
            {
                MessageBox.Show("Добавьте хотя бы одну точку!");
            }
        }

        List<double> Start(IProgress<List<double>> ProgressObj, List<double> Points, int Pause, bool Reverse)
        {
            int AmountPoints = Points.Count;

            if (BubbleSortStatus.Checked)
            {
                if (!Reverse)
                {
                    return BubbleSort(ProgressObj, Points, Pause, Reverse);
                } else
                {
                    return BubbleSortReverse(ProgressObj, Points, Pause, Reverse);
                }
            } else if (InsertsSortStatus.Checked)
            {
                if (!Reverse)
                {
                    return InsertsSort(ProgressObj, Points, Pause, Reverse);
                } else
                {
                    return InsertsSortReverse(ProgressObj, Points, Pause, Reverse);
                }
            } else if (ShakerSortStatus.Checked)
            {
                if (!Reverse)
                {
                    return ShakerSort(ProgressObj, Points, Pause, Reverse);
                }
                else
                {
                    return ShakerSortReverse(ProgressObj, Points, Pause, Reverse);
                }
            }
            else if (FastSortStatus.Checked)
            {
                if (!Reverse)
                {
                    return FastSort(Points, 0, AmountPoints - 1, ProgressObj, Pause, Reverse);
                }
                else
                {
                    return FastSortReverse(Points, 0, AmountPoints - 1, ProgressObj, Pause, Reverse);
                }
            }
            else if (BogoSortStatus.Checked)
            {
                if (!Reverse)
                {
                    return BogoSort(ProgressObj, Points, Pause, Reverse);
                }
                else
                {
                    return BogoSortReverse(ProgressObj, Points, Pause, Reverse);
                }
            } else
            {
                return FastSort(Points, 0, AmountPoints - 1, ProgressObj, Pause, Reverse);
            }
        }

        List<double> BubbleSort(IProgress<List<double>> ProgressObj, List<double> Points, int Pause, bool Reverse)
        {
            double Temp;

            for (int FirstIndex = 0; FirstIndex < Points.Count; FirstIndex++)
            {
                for (int SecondIndex = FirstIndex + 1; SecondIndex < Points.Count; SecondIndex++)
                {
                    if (Points[FirstIndex] > Points[SecondIndex])
                    {
                        Temp = Points[FirstIndex];
                        Points[FirstIndex] = Points[SecondIndex];
                        Points[SecondIndex] = Temp;

                        ProgressObj.Report(Points);
                        Task.Delay(Pause).Wait();

                        if (!Data.Status)
                        {
                            Data.Status = true;
                            throw new Exception("Опепация прервана!");
                        }
                    }
                }
            }

            return Points;
        }

        List<double> BubbleSortReverse(IProgress<List<double>> ProgressObj, List<double> Points, int Pause, bool Reverse)
        {
            double Temp;

            for (int FirstIndex = 0; FirstIndex < Points.Count; FirstIndex++)
            {
                for (int SecondIndex = FirstIndex + 1; SecondIndex < Points.Count; SecondIndex++)
                {
                    if (Points[FirstIndex] < Points[SecondIndex])
                    {
                        Temp = Points[FirstIndex];
                        Points[FirstIndex] = Points[SecondIndex];
                        Points[SecondIndex] = Temp;

                        ProgressObj.Report(Points);
                        Task.Delay(Pause).Wait();

                        if (!Data.Status)
                        {
                            Data.Status = true;
                            throw new Exception("Опепация прервана!");
                        }
                    }
                }
            }

            return Points;
        }

        List<double> InsertsSort(IProgress<List<double>> ProgressObj, List<double> Points, int Pause, bool Reverse)
        {
            for (int FirstIndex = 1; FirstIndex < Points.Count; FirstIndex++)
            {
                double Temp = Points[FirstIndex];
                int SecondIndex = FirstIndex - 1;

                while (SecondIndex >= 0 && Points[SecondIndex] > Temp)
                {
                    Points[SecondIndex + 1] = Points[SecondIndex];
                    Points[SecondIndex] = Temp;
                    SecondIndex--;
                    ProgressObj.Report(Points);
                    Task.Delay(Pause).Wait();

                    if (!Data.Status)
                    {
                        Data.Status = true;
                        throw new Exception("Опепация прервана!");
                    }
                }
            }

            return Points;
        }

        List<double> InsertsSortReverse(IProgress<List<double>> ProgressObj, List<double> Points, int Pause, bool Reverse)
        {
            for (int FirstIndex = 1; FirstIndex < Points.Count; FirstIndex++)
            {
                double Temp = Points[FirstIndex];
                int SecondIndex = FirstIndex - 1;

                while (SecondIndex >= 0 && Points[SecondIndex] < Temp)
                {
                    Points[SecondIndex + 1] = Points[SecondIndex];
                    Points[SecondIndex] = Temp;
                    SecondIndex--;
                    ProgressObj.Report(Points);
                    Task.Delay(Pause).Wait();

                    if (!Data.Status)
                    {
                        Data.Status = true;
                        throw new Exception("Опепация прервана!");
                    }
                }
            }

            return Points;
        }

        List<double> ShakerSort(IProgress<List<double>> ProgressObj, List<double> Points, int Pause, bool Reverse)
        {
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
                        ProgressObj.Report(Points);
                        Task.Delay(Pause).Wait();

                        if (!Data.Status)
                        {
                            Data.Status = true;
                            throw new Exception("Опепация прервана!");
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
                        ProgressObj.Report(Points);
                        Task.Delay(Pause).Wait();

                        if (!Data.Status)
                        {
                            Data.Status = true;
                            throw new Exception("Опепация прервана!");
                        }
                    }
                }
                LeftIndex++;
            }

            return Points;
        }

        List<double> ShakerSortReverse(IProgress<List<double>> ProgressObj, List<double> Points, int Pause, bool Reverse)
        {
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
                        ProgressObj.Report(Points);
                        Task.Delay(Pause).Wait();

                        if (!Data.Status)
                        {
                            Data.Status = true;
                            throw new Exception("Опепация прервана!");
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
                        ProgressObj.Report(Points);
                        Task.Delay(Pause).Wait();

                        if (!Data.Status)
                        {
                            Data.Status = true;
                            throw new Exception("Опепация прервана!");
                        }
                    }
                }
                LeftIndex++;
            }

            return Points;
        }

        List<double> FastSort(List<double> Points, int LeftIndex, int RightIndex, IProgress<List<double>> ProgressObj, int Pause, bool Reverse)
        {
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
                ProgressObj.Report(Points);
                Task.Delay(Pause).Wait();
                FastSort(Points, LeftIndex, SecondIndex, ProgressObj, Pause, Reverse);

                if (!Data.Status)
                {
                    Data.Status = true;
                    throw new Exception("Опепация прервана!");
                }
            }
            if (FirstIndex < RightIndex)
            {
                ProgressObj.Report(Points);
                Task.Delay(Pause).Wait();
                FastSort(Points, FirstIndex, RightIndex, ProgressObj, Pause, Reverse);

                if (!Data.Status)
                {
                    Data.Status = true;
                    throw new Exception("Опепация прервана!");
                }
            }

            return Points;
        }

        List<double> FastSortReverse(List<double> Points, int LeftIndex, int RightIndex, IProgress<List<double>> ProgressObj, int Pause, bool Reverse)
        {
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
                ProgressObj.Report(Points);
                Task.Delay(Pause).Wait();
                FastSortReverse(Points, LeftIndex, SecondIndex, ProgressObj, Pause, Reverse);

                if (!Data.Status)
                {
                    Data.Status = true;
                    throw new Exception("Опепация прервана!");
                }
            }
            if (FirstIndex < RightIndex)
            {
                ProgressObj.Report(Points);
                Task.Delay(Pause).Wait();
                FastSortReverse(Points, FirstIndex, RightIndex, ProgressObj, Pause, Reverse);

                if (!Data.Status)
                {
                    Data.Status = true;
                    throw new Exception("Опепация прервана!");
                }
            }

            return Points;
        }

        List<double> BogoSort(IProgress<List<double>> ProgressObj, List<double> Points, int Pause, bool Reverse)
        {
            while (!IsSorted(Points)) {
                ProgressObj.Report(Points);
                Task.Delay(Pause).Wait();
                Shuffle(Points);

                if (!Data.Status)
                {
                    Data.Status = true;
                    throw new Exception("Опепация прервана!");
                }
            }

            return Points;
        }

        List<double> BogoSortReverse(IProgress<List<double>> ProgressObj, List<double> Points, int Pause, bool Reverse)
        {
            while (!IsSortedReverse(Points))
            {
                ProgressObj.Report(Points);
                Task.Delay(Pause).Wait();
                Shuffle(Points);

                if (!Data.Status)
                {
                    Data.Status = true;
                    throw new Exception("Опепация прервана!");
                }
            }

            return Points;
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

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (Data.Started)
            {
                Data.Status = false;
            } else
            {
                Table.Rows.Clear();
                Chart.Series[0].Points.Clear();
                Chart.Refresh();
                MessageBox.Show("Операция прервана!");
            }
        }
    }
}
