using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLL_Test
{
  internal class Program
  {
    private class Student
    {
      private int MatNr;
      private String Name;

      public override bool Equals(object obj)
      {
        Student other = (Student)obj;
        return other.MatNr.Equals(this.MatNr);
      }
    }
        static void Main(string[] args)
        {
            /*
                  SinglyLinkedList.SinglyLinkedList<int> sll = 
              new SinglyLinkedList.SinglyLinkedList<int>();

            sll.Add(10);
            sll.Add(11);
            sll.Add(12);
            sll.Add(13);
            sll.Add(14);
            sll.Add(15);

                  sll.Remove(11);

            */
            SinglyLinkedList.SinglyLinkedList<string> sll = new SinglyLinkedList.SinglyLinkedList<string>();
            sll.Add("Hello");
            sll.Add("World");
            sll.Add("!");
            sll.Add("How");
            sll.Add("are");
            sll.Add("you");

            string[] strArr = new string[] { "Hello", "World", "!", "How", "are", "you" };

            for (int i = 0; i < strArr.Length; i++) //Hier wird überprüft, ob das Objekt an der Stelle i im Array strArr gleich dem Objekt an der Stelle i in der Liste sll ist.
            {
                if (sll.Contains(strArr[i]))
                {
                    Console.WriteLine("Element found at index " + i);
                }
                else
                {
                    Console.WriteLine("Element not found at index " + i);
                }
            }

            Console.WriteLine();

            for (int j = 0; j < strArr.Length ; j++) 
            {
                Console.WriteLine("Element at position " + j + " is " + sll.FindByIndex(j));
            }

            Console.WriteLine();

            sll.Remove("How"); //Hier wird das Objekt "How" aus der Liste entfernt.
                            
            if (sll.Contains("How")) 
            {
                Console.WriteLine("Element found");
            }
            else
            {
                Console.WriteLine("Element not found");
            }

           
        }
    }
 }
