using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
  public class SinglyLinkedList<T>
  {
    public SinglyLinkedList()
    {
      head = null;
      tail = null;
      count = 0;
    }

    private class Node<T>
    {
      public Node(T value)
      {
        this.Value = value;
      }
      public T Value { get; private set; }
      public Node<T> next { get; set; }
    }

    Node<T> head;
    Node<T> tail;
    int count;

    public void Add(T value)
    {
      count++;
      if(head == null) //list is empty
      {
        Node<T> element = new Node<T>(value);
        head = element;
        //head.Value = value;
        tail = head;
        return;
      }

      //constant
      tail.next = new Node<T>(value);
      //tail.next.Value = value;
      tail = tail.next;

            //linar
            //Node<T> current = head;
            //while (current.next != null)
            //{
            //  current = current.next;
            //}

            ////current is the last element of the list
            //current.next = new Node<T>();
            //current.next.Value = value;
        }

        int Size()
    {
      return count;
    }

    public bool Contains(T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }
    public bool Remove(T value) //Hier wird das Objekt value aus der Liste entfernt.
        {
        if (head == null) return false; //in case of empty list

        Node<T> prev = null;
        Node<T> current = head;
        while (current.next != null) 
        {
            if (current.Value.Equals(value)) //Hier wird überprüft, ob das Objekt an der Stelle current gleich dem übergebenen Objekt value ist.
                {
                if (current == head) 
                {
                    head = head.next; //Hier wird das erste Element der Liste entfernt.
                    }
                else
                {
                    prev.next = current.next; //Hier wird ein Element aus der Liste entfernt.
                    }

                count--; //Hier wird die Anzahl der Elemente in der Liste um 1 verringert.
                   return true;
            }

            prev = current;
            current = current.next;
        }

        return false;
    }

    public bool IsObjectAtIndex(T value, int index)
        {
            //IsObjectAtIndex überprüft, ob das Objekt an der Stelle index im SinglyLinkedList-Objekt gleich dem übergebenen Objekt value ist.
            if (index < 0 || index >= count) return false; //Hier wird überprüft, ob der Index im gültigen Bereich liegt.
            Node<T> current = head; 
            for (int i = 0; i < index; i++)
            {
                current = current.next; //Hier wird der Index durchlaufen.
            }
            return current.Value.Equals(value); //Hier wird überprüft, ob das Objekt an der Stelle index gleich dem übergebenen Objekt ist.
        }

    public T FindByIndex(int index)
        {
            if (index < 0 || index >= count) return default(T); //Hier wird überprüft, ob der Index im gültigen Bereich liegt. Count ist die Anzahl der Elemente in der Liste.
            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.next; //Hier wird der Index durchlaufen.
            }
            return current.Value; //Hier wird das Objekt an der Stelle index zurückgegeben.
        }

    public int Count()  //Hier wird die Anzahl der Elemente in der Liste zurückgegeben.
        {
            return count;
        }

    public void Clear() //Hier wird die Liste geleert.
        {
            head = null;
            tail = null;
            count = 0;
        }


    }
}
