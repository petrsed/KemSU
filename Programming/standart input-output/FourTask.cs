/**********************************************************
* Автор: Седельников П.В                                  *
* Дата: 13.06.2022                                        *
* Задача: 4. Стандартный ввод-вывод                       *
**********************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace FourTask
{
    internal class FourTask
    {
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
                        IndexFiles();
                        break;
                    case 2:
                        IndexTxtFiles();
                        break;
                    case 3:
                        Console.WriteLine("\nEnter keyword:");
                        string Keyword = Console.ReadLine();
                        IndexhByKeywords(Keyword);
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1) Index all files");
            Console.WriteLine("2) Index all txt files");
            Console.WriteLine("3) Search by keywords");
        }

        static void IndexFiles()
        {
            String CurrentDirectory = Directory.GetCurrentDirectory();
            string[] Files = Directory.GetFiles(CurrentDirectory);

            PrintFiles(Files, "Found " + Files.Length + " files in the directory: '" + CurrentDirectory + "':");
        }

        static void IndexTxtFiles()
        {
            String CurrentDirectory = Directory.GetCurrentDirectory();
            string[] Files = GetAllTxtFiles(CurrentDirectory);

            PrintFiles(Files, "Found " + Files.Length + " txt files in the directory: '" + CurrentDirectory + "':");
        }

        static void IndexhByKeywords(string Keyword)
        {
            String CurrentDirectory = Directory.GetCurrentDirectory();
            string[] Files = SearchTxtFilesByKeyword(CurrentDirectory, Keyword);

            PrintFiles(Files, "Found " + Files.Length + " txt files in the directory: '" + CurrentDirectory + "' with keyword '" + Keyword + "':");
        }

        static string[] SearchTxtFilesByKeyword(string CurrentDirectory, string Keyword)
        {
            string[] Files = GetAllTxtFiles(CurrentDirectory);
            List<string> NeedFiles = new List<string> { };

            foreach(string FileName in Files)
            {
                TextFile File = new TextFile(FileName);
                string FileContent = File.Content;

                if (FileContent.Contains(Keyword))
                {
                    NeedFiles.Add(FileName);
                }
            }

            return NeedFiles.ToArray();
        }

        static void PrintFiles(string[] Files, string Message)
        {
            int fileIndex = 0;

            Console.WriteLine();
            Console.WriteLine(Message);
            foreach (string File in Files)
            {
                ++fileIndex;
                Console.WriteLine(fileIndex + ") " + File);
            }
            Console.WriteLine();
        }

        static string[] GetAllTxtFiles(string NeedDirectory)
        {
            List<string> NeedFiles = new List<string> { };
            string[] Files = Directory.GetFiles(NeedDirectory);
   
            foreach (string File in Files)
            {
                if (File.Contains(".txt")) {
                    NeedFiles.Add(File);
                }
                
            }

            return NeedFiles.ToArray();
        }
    }
    
    [Serializable]
    public class TextFile
    {
        public string Name { get; set; } = "Undefined";
        public string Content { get; set; } = "";

        FileHistory History = new FileHistory();
        public TextFile() {
            Content = Read();
        }
        public TextFile(string name)
        {
            Name = name;
            Content = Read();
        }

        public void BinarySerialize()
        {
            Console.WriteLine("* Сontent is serialize to binary *");
            FileStream File = Open();
            BinaryFormatter Formatter = new BinaryFormatter();
            Formatter.Serialize(File, this);
            File.Close();
        }

        public void BinaryDeserialize()
        {
            Console.WriteLine("* Сontent is deserialize from binary *");
            FileStream File = Open();
            var Formatter = new BinaryFormatter();
            var DeserializedFile = (TextFile) Formatter.Deserialize(File);
            File.Close();
        }

        public void XMLSerialize()
        {
            Console.WriteLine("* Сontent is serialize to XML *");
            FileStream File = Open();
            XmlSerializer Formatter = new XmlSerializer(typeof(TextFile));
            Formatter.Serialize(File, this);
            File.Close();
        }

        public void XMLDeserialize()
        {
            Console.WriteLine("* Сontent is deserialize from XML *");
            FileStream File = Open();
            var Formatter = new XmlSerializer(typeof(TextFile));
            var DeserializedFile = (TextFile) Formatter.Deserialize(File);
            File.Close();
        }

        public FileStream Open()
        {
            FileStream File = new FileStream(Name, FileMode.OpenOrCreate);
            return File;
        }

        public String Read()
        {
            using (FileStream fstream = File.OpenRead(Name))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);
                Content = textFromFile;
                return textFromFile;
            }
        }

        public void Write()
        {
            StreamWriter File = new StreamWriter(Name);
            File.WriteLine(Content);
            File.Close();
        }

        public void SaveToMemento()
        {
            Console.WriteLine("* Сontent is recorded in Memento memory *");
            History.Memento.Push(GetFileMemento());
        }

        public FileMemento GetFileMemento()
        {
            return new FileMemento(Content);
        }

        public void GetFromMemento()
        {
            Console.WriteLine("* Сontent is recovered from Memento memory *");
            FileMemento Memento = History.Memento.Pop();
            this.Content = Memento.Content;
        }

        public void Print()
        {
            Console.WriteLine("File '" + Name + "': " + Content);
        }
    }

    public class FileMemento
    {
        public string Content { get; private set; }
        public FileMemento(string Content)
        {
            this.Content = Content;
        }
    }

    public class FileHistory
    {
        public Stack<FileMemento> Memento { get; private set; }
        public FileHistory()
        {
            Memento = new Stack<FileMemento>();
        }
    }
}
