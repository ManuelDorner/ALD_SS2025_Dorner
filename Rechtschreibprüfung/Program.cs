using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rechtschreibprüfung
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLoader myfile = new FileLoader("german.txt");
            myfile.SaveFileDataToSingleLinkedList();


            Console.WriteLine("Bitte geben Sie eine Text ein:");
            string input = Console.ReadLine();
            string[] SplittedText = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < SplittedText.Length; i++)
            {
                if (myfile.data.Contains(SplittedText[i])) // Was muss ich ändern damit es funktioniert?
              
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(SplittedText[i] + " ");
            }


            Console.ReadKey();
        }

        private void SaveList()
        {

        }
    }
}