using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinglyLinkedList;
using System.IO;

namespace Rechtschreibprüfung
{
    public class FileLoader
    {
        public string Path { get; set; }
        public string Filename { get; set; }

        public SinglyLinkedList<string> data { get; private set; }


        public FileLoader(string _filename)
        {
            Filename = _filename;
            Path = @"C:\Users\manue\OneDrive\Desktop\Master_Automatisierungstechnik\2_Semester\Algorithmen und Datenstrukturen\Projekt_Dorner\german\german.dic";
        }
        public void SaveFileDataToSingleLinkedList()
        {
            string helper = "";
            SinglyLinkedList<string> list = new SinglyLinkedList<string>();

            try
            {
                using (StreamReader newstream = new StreamReader(Path))
                {
                    int i = 0;
                    while ((helper = newstream.ReadLine()) != null)
                    {
                        string[] splitLine = helper.Split(',');
                        if (!splitLine[0].StartsWith("%"))
                        {
                            list.Add(splitLine[0]);
                        }
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Es ist ein Fehler ausgetreten {ex.StackTrace}");
                throw;
            }

            data = list;
        }

      
    }
}
