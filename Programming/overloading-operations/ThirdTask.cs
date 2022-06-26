using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ThirdTask
{
    internal class ThirdTask
    {
        static SquareMatrix first = new SquareMatrix();
        static SquareMatrix second = new SquareMatrix();
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            while (true)
            {
                PrintMenu();

                int OptionId = Convert.ToInt32(Console.ReadLine());

                switch (OptionId)
                {
                    case 1:
                        SquareMatrix AdditionResult = first + second;
                        AdditionResult.PrintMatrix();
                        break;
                    case 2:
                        SquareMatrix MultiplicationResult = first * second;
                        MultiplicationResult.PrintMatrix();
                        break;
                    case 3:
                        SquareMatrix TranspositionResult = first.Transpose();
                        TranspositionResult.PrintMatrix();
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void PrintMenu()
        {
            first.PrintMatrix();
            second.PrintMatrix();

            Console.WriteLine("\n\nSelect an option:");
            Console.WriteLine("1) Addition");
            Console.WriteLine("2) Multiplication");
            Console.WriteLine("3) Transposition");
        }
    }


    public class SquareMatrix
    {
        public int Size { get; set; }
        public int[,] Matrix { get; set; }

        public SquareMatrix()
        {
            Size = 2;

            GenerateMatrix();
        }

        public SquareMatrix(int[,] Elements)
        {
            Matrix = new int[Size, Size];
            for (var rowIndex = 0; rowIndex < Size; ++rowIndex)
            {
                for (var columnIndex = 0; columnIndex < Size; ++columnIndex)
                {
                    Matrix[rowIndex, columnIndex] = Elements[rowIndex, columnIndex];
                }
            }
        }

        public void GenerateMatrix()
        {
            Matrix = new int[Size, Size];
            Random randomModule = new Random();

            for (var rowIndex = 0; rowIndex < Size; ++rowIndex)
            {
                for (var columnIndex = 0; columnIndex < Size; ++columnIndex)
                {
                    Matrix[rowIndex, columnIndex] = randomModule.Next(-1024, 1024);
                }
            }
        }

        public static SquareMatrix operator +(SquareMatrix Self, SquareMatrix Other)
        {
            if (Self.Size != Other.Size)
            {
                throw new MatrixDifferentSize();
            }
            var ElementsAmount = Self.Size * Self.Size;
            int[,] NewElements = new int[Self.Size, Self.Size];
            var ElementsCount = 0;
            for (var RowIndex = 0; RowIndex < Self.Size; ++RowIndex)
            {
                for (var columnIndex = 0; columnIndex < Self.Size; ++columnIndex)
                {
                    NewElements[RowIndex, columnIndex] = Self.Matrix[RowIndex, columnIndex] + Other.Matrix[RowIndex, columnIndex];
                    ++ElementsCount;
                }
            }
            return new SquareMatrix(NewElements);
        }

        public static SquareMatrix operator *(SquareMatrix Self, SquareMatrix Other)
        {
            if (Self.Size != Other.Size)
            {
                throw new MatrixDifferentSize();
            }
            var ElementsAmount = Self.Size * Self.Size;
            int[,] NewElements = new int[Self.Size, Self.Size];
            var ElementsCount = 0;
            for (var RowIndex = 0; RowIndex < Self.Size; ++RowIndex)
            {
                for (var columnIndex = 0; columnIndex < Self.Size; ++columnIndex)
                {
                    NewElements[RowIndex, columnIndex] = Self.Matrix[RowIndex, columnIndex] * Other.Matrix[RowIndex, columnIndex];
                    ++ElementsCount;
                }
            }
            return new SquareMatrix(NewElements);
        }

        public static bool operator >(SquareMatrix Self, SquareMatrix Other)
        {
            return Self.GetAmount() > Other.GetAmount();
        }

        public static bool operator <(SquareMatrix Self, SquareMatrix Other)
        {
            return Self.GetAmount() < Other.GetAmount();
        }

        public static bool operator >=(SquareMatrix Self, SquareMatrix Other)
        {
            return Self.GetAmount() > Other.GetAmount();
        }

        public static bool operator <=(SquareMatrix Self, SquareMatrix Other)
        {
            return Self.GetAmount() < Other.GetAmount();
        }

        public static bool operator ==(SquareMatrix Self, SquareMatrix Other)
        {
            for (var RowIndex = 0; RowIndex < Self.Size; ++RowIndex)
            {
                for (var ColumnIndex = 0; ColumnIndex < Self.Size; ++ColumnIndex)
                {
                    if (Self.Matrix[RowIndex, ColumnIndex] != Other.Matrix[RowIndex, ColumnIndex])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator !=(SquareMatrix Self, SquareMatrix Other)
        {
            for (var RowIndex = 0; RowIndex < Self.Size; ++RowIndex)
            {
                for (var ColumnIndex = 0; ColumnIndex < Self.Size; ++ColumnIndex)
                {
                    if (Self.Matrix[RowIndex, ColumnIndex] == Other.Matrix[RowIndex, ColumnIndex])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator true(SquareMatrix Self)
        {
            return (Self.GetAmount() >= 0);
        }

        public static bool operator false(SquareMatrix Self)
        {
            return (Self.GetAmount() < 0);
        }

        public int GetAmount()
        {
            int Amount = 0;
            for (var RowIndex = 0; RowIndex < Size; ++RowIndex)
            {
                for (var ColumnIndex = 0; ColumnIndex < Size; ++ColumnIndex)
                {
                    Amount += Matrix[RowIndex, ColumnIndex];
                }
            }
            return Amount;
        }

        public double Determinant()
        {
            return (this.Matrix[0, 0] * this.Matrix[1, 1] - this.Matrix[0, 1] * this.Matrix[1, 0]);
        }

        public SquareMatrix Transpose()
        {
            var TransposedMatrix = new SquareMatrix();
            for (var RowIndex = 0; RowIndex < this.Size; ++RowIndex)
            {
                for (var ColumnIndex = 0; ColumnIndex < this.Size; ++ColumnIndex)
                {
                    TransposedMatrix.Matrix[ColumnIndex, RowIndex] = this.Matrix[RowIndex, ColumnIndex];
                }
            }
            return TransposedMatrix;
        }

        public void PrintMatrix()
        {
            String[] RowStrings = new string[Size];

            for (var rowIndex = 0; rowIndex < Size; ++rowIndex)
            {
                String[] Row = new string[Size];

                for (var columnIndex = 0; columnIndex < Size; ++columnIndex)
                {
                    int MatrixElement = Matrix[rowIndex, columnIndex];
                    Row[columnIndex] = MatrixElement.ToString();
                }

                string RowString = String.Join(", ", Row);
                RowStrings[rowIndex] = "[" + RowString + "]";
            }

            string MatrixString = "Matrix:[" + String.Join(", ", RowStrings) + "]";
            Console.WriteLine(MatrixString);
        }

        public static implicit operator string(SquareMatrix Self)
        {
            String[] RowStrings = new string[Self.Size];

            for (var rowIndex = 0; rowIndex < Self.Size; ++rowIndex)
            {
                String[] Row = new string[Self.Size];

                for (var columnIndex = 0; columnIndex < Self.Size; ++columnIndex)
                {
                    int MatrixElement = Self.Matrix[rowIndex, columnIndex];
                    Row[columnIndex] = MatrixElement.ToString();
                }

                string RowString = String.Join(", ", Row);
                RowStrings[rowIndex] = "[" + RowString + "]";
            }

            string MatrixString = "Matrix:[" + String.Join(", ", RowStrings) + "]";
            return MatrixString;
        }

        public override string ToString()
        {
            String[] RowStrings = new string[this.Size];

            for (var rowIndex = 0; rowIndex < this.Size; ++rowIndex)
            {
                String[] Row = new string[this.Size];

                for (var columnIndex = 0; columnIndex < this.Size; ++columnIndex)
                {
                    int MatrixElement = this.Matrix[rowIndex, columnIndex];
                    Row[columnIndex] = MatrixElement.ToString();
                }

                string RowString = String.Join(", ", Row);
                RowStrings[rowIndex] = "[" + RowString + "]";
            }

            string MatrixString = "Matrix:[" + String.Join(", ", RowStrings) + "]";
            return MatrixString;
        }

        public int CompareTo(object OtherObject)
        {
            var Other = OtherObject as SquareMatrix;

            int ThisAmount = this.GetAmount();
            var OtherAmount = Other.GetAmount();
            if (OtherAmount > ThisAmount)
            {
                return -1;
            }
            if (OtherAmount < ThisAmount)
            {
                return 1;
            }
            if (OtherAmount == ThisAmount)
            {
                return 0;
            }
           return -1;
        }

        public override bool Equals(object OtherObject)
        {
            var Other = OtherObject as SquareMatrix;
            for (var RowIndex = 0; RowIndex < Other.Size; ++RowIndex)
            {
                for (var ColumnIndex = 0; ColumnIndex < Other.Size; ++ColumnIndex)
                {
                    if (Other.Matrix[RowIndex, ColumnIndex] != this.Matrix[RowIndex, ColumnIndex])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return (Int32)this.GetAmount();
        }

        public class MatrixDifferentSize : ApplicationException
        {
        }
    }

    public class SquareMatrixCopied : SquareMatrix
    {
        public SquareMatrixCopied()
        {
        }

        public SquareMatrixCopied(int[,] Elements) : base(Elements)
        {
        }

        public object Copy()
        {
            var CopiedMatrix = new SquareMatrixCopied();
            CopiedMatrix.Matrix = this.Matrix;
            return CopiedMatrix;
        }
    }
}
