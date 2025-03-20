using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rechtschreibpruefung
{
    internal class Program
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
                if (myfile.data.Contains(SplittedText[i]))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
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