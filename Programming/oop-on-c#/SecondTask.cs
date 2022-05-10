/**********************************************************
* Автор: Седельников П.В                                  *
* Дата: 10.05.2022                                        *
* Задача: 2. ООП на С#                                    *
**********************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    internal class SecondTask
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select the file type to display information about:");
                Console.WriteLine("1) .DOC");
                Console.WriteLine("2) .PDF");
                Console.WriteLine("3) .XLS");
                Console.WriteLine("4) .TXT");
                Console.WriteLine("5) .HTML\n");

                int FileType = Convert.ToInt32((Console.ReadLine()));
                Singleton.Instance.Create(FileType);
            }
        }
    }
    class Document
    {
        public string Name;
        public string Author;
        public string Keywords;
        public string Thematics;
        public string Path;

        public void Print()
        {
            Console.WriteLine("\nFile:");
            Console.WriteLine($"Name - {this.Name}");
            Console.WriteLine($"Author - {this.Author}");
            Console.WriteLine($"Keywords - {this.Keywords}");
            Console.WriteLine($"Thematics - {this.Thematics}");
            Console.WriteLine($"Path - {this.Path}\n");
        }
    }

    class DOC : Document
    {
        public DOC()
        {
            Name = "Microsoft Word file";
            Author = "User";
            Keywords = "doc, docx, file";
            Thematics = "docs";
            Path = "C:\\Files\\";
        }
    }

    class PDF : Document
    {
        public PDF()
        {
            Name = "PDF file";
            Author = "User";
            Keywords = "pdf, file";
            Thematics = "docs";
            Path = "C:\\Files\\";
        }
    }

    class XLS : Document
    {
        public XLS()
        {
            Name = "XLS file";
            Author = "User";
            Keywords = "xls, xlsx, file";
            Thematics = "docs";
            Path = "C:\\Files\\";
        }
    }

    class TXT : Document
    {
        public TXT()
        {
            Name = "TXT file";
            Author = "User";
            Keywords = "txt, file";
            Thematics = "docs";
            Path = "C:\\Files\\";
        }
    }

    class HTML : Document
    {
        public HTML()
        {
            Name = "HTML file";
            Author = "User";
            Keywords = "html, file";
            Thematics = "docs";
            Path = "C:\\Files\\";
        }
    }

    public class Singleton
    {
        public static Singleton Instance
        {
            get
            {
                if (instance == null) instance = new Singleton();
                return instance;
            }
        }

        private Singleton() { }
        private static Singleton instance;

        public void Create(int FileType)
        {
            Document File;

            switch (FileType)
            {
                case 1:
                    {
                        File = new DOC();
                        break;
                    }
                case 2:
                    {
                        File = new PDF();
                        break;
                    }
                case 3:
                    {
                        File = new XLS();
                        break;
                    }
                case 4:
                    {
                        File = new TXT();
                        break;
                    }
                case 5:
                    {
                        File = new HTML();
                        break;
                    }
                default: {
                        File = new TXT();
                        break;
                    }
            }

            File.Print();
        }
    }
}
