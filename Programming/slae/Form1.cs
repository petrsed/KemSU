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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Popcron.Sheets;
using System.IO;
using Google.Apis.Sheets.v4.Data;
using System.Threading;

namespace Sedelnikov_6
{
    public partial class Form1 : Form
    {
        int Dimension = 3;
        List<List<int>> MatrixA;
        List<List<int>> MatrixB;
        List<List<int>> MatrixX;
        public static Logic LogicObj;

        static string GOOGLE_SHEEETSSPREADSHEET_ID = "xxxxxxxxxxxxxxx";
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "Laba";
        static SheetsService service;


        public Form1()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

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
            try
            {
                Stopwatch Timer = new Stopwatch();

                Timer.Start();
                List<List<double>> GaussMatrix = LogicObj.GaussMethod();
                var GaussForm = new Form4(LogicObj, GaussMatrix, "Метод Гаусса");
                GaussForm.Show();
                Timer.Stop();
                int TimerMilliSeconds = Convert.ToInt32(Timer.ElapsedMilliseconds);
                GaussAnswer.Text = $"{TimerMilliSeconds} мс.";

                try
                {
                    if (!Double.IsNaN(GaussMatrix[0][0]))
                    {
                        ClearTable("MatrixX");
                        SyncVectorX(GaussMatrix);
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка синхронизации!");
                }
            } catch
            {
                MessageBox.Show("Матрица не имеет решения!");
            }
        }

        private void ExactLine_Click(object sender, EventArgs e)
        {

        }

        void SyncMatrix()
        {
            try
            {
                SyncMatrixA();
                SyncVectorB();
                MessageBox.Show("Матрицы синхронизированы!");
            }
            catch
            {
                MessageBox.Show("Ошибка синхронизации!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread SyncThread = new Thread(() => SyncMatrix());
            SyncThread.Start();
        }

        static void SyncMatrixA() //импорт данных
        {
            int Dimension = LogicObj.GetDimension();
            List<List<int>> MatrixA = new List<List<int>>();
            var range = $"MatrixA!A:C";
            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(GOOGLE_SHEEETSSPREADSHEET_ID, range);

            var response = request.Execute();
            IList<IList<object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    List<int> MatrixLine = new List<int>();
                    foreach (var num in row)
                    {
                        int Number;
                        try
                        {
                            Number = Convert.ToInt32(num);
                        } catch
                        {
                            Number = 0;
                        }

                        MatrixLine.Add(Number);
                    }
                    MatrixA.Add(MatrixLine);
                }
            }
            else
            {
                MatrixA = LogicObj.GetZeroMatrix(LogicObj.GetDimension());
            }

            MatrixA = LogicObj.ConvertMatrixSize(MatrixA, Dimension);
            LogicObj.SetMatrixA(MatrixA);
        }

        static void SyncVectorX(List<List<double>> Matrix) //экспорт
        {
            var range = $"MatrixX!A:A";
            var valueRange = new ValueRange();


            valueRange.Values = new List<IList<object>>();

            foreach (var row in Matrix)
            {
                var oblist = new List<object>();
                oblist.Add(row[0].ToString());
                valueRange.Values.Add(oblist);
            }

            var appendRequest = service.Spreadsheets.Values.Append(valueRange, GOOGLE_SHEEETSSPREADSHEET_ID, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendReponse = appendRequest.Execute();
        }

        static void ExportMatrixA(List<List<int>> Matrix) 
        {
            var range = $"MatrixA!A:C";
            var valueRange = new ValueRange();


            valueRange.Values = new List<IList<object>>();

            foreach (var row in Matrix)
            {
                var oblist = new List<object>();

                foreach (var col in row)
                {
                    oblist.Add(col.ToString());
                }

                valueRange.Values.Add(oblist);
            }

            var appendRequest = service.Spreadsheets.Values.Append(valueRange, GOOGLE_SHEEETSSPREADSHEET_ID, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendReponse = appendRequest.Execute();
        }

        static void ExportVectorB(List<List<int>> Matrix)
        {
            var range = $"MatrixB!A:A";
            var valueRange = new ValueRange();


            valueRange.Values = new List<IList<object>>();

            foreach (var row in Matrix)
            {
                var oblist = new List<object>();

                foreach (var col in row)
                {
                    oblist.Add(col.ToString());
                }

                valueRange.Values.Add(oblist);
            }

            var appendRequest = service.Spreadsheets.Values.Append(valueRange, GOOGLE_SHEEETSSPREADSHEET_ID, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendReponse = appendRequest.Execute();
        }

        static void ClearTable(string SheetName)
        {
            var range = $"{SheetName}!A:F";
            var requestBody = new ClearValuesRequest();

            var deleteRequest = service.Spreadsheets.Values.Clear(requestBody, GOOGLE_SHEEETSSPREADSHEET_ID, range);
            var deleteReponse = deleteRequest.Execute();
        }

        static void SyncVectorB()
        {
            int Dimension = LogicObj.GetDimension();
            List<List<int>> MatrixB = new List<List<int>>();
            var range = $"MatrixB!A:A";
            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(GOOGLE_SHEEETSSPREADSHEET_ID, range);

            var response = request.Execute();
            IList<IList<object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    List<int> MatrixLine = new List<int>();
                    foreach (var num in row)
                    {
                        int Number;
                        try
                        {
                            Number = Convert.ToInt32(num);
                        }
                        catch
                        {
                            Number = 0;
                        }

                        MatrixLine.Add(Number);
                    }
                    MatrixB.Add(MatrixLine);
                }
            }
            else
            {
                MatrixB = LogicObj.GetZeroMatrix(LogicObj.GetDimension());
            }

            MatrixB = LogicObj.ConvertVectorSize(MatrixB, Dimension);
            LogicObj.SetMatrixB(MatrixB);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearTable("MatrixA");
            List<List<int>> MatrixA = LogicObj.GetMatrixA();
            ExportMatrixA(MatrixA);

            ClearTable("MatrixB");
            List<List<int>> MatrixB = LogicObj.GetMatrixB();
            ExportVectorB(MatrixB);
        }
    }
}
