using System;

namespace SinglyLinkedList
{
    // Öffentliche Node-Klasse
    public class Node<T>
    {
        public T Value { get; private set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    public class SinglyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public SinglyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        // Zugriff auf den Kopf (für externes Durchlaufen)
        public Node<T> Head => head;

        // Indexer: Zugriff wie sll[3]
        public T this[int index]
        {
            get => FindByIndex(index);
        }

        public void Add(T value)
        {
            Node<T> element = new Node<T>(value);
            count++;

            if (head == null)
            {
                head = element;
                tail = head;
                return;
            }

            tail.Next = element;
            tail = tail.Next;
        }

        public bool Contains(T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public bool Remove(T value)
        {
            if (head == null) return false;

            Node<T> prev = null;
            Node<T> current = head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current == head)
                        head = head.Next;
                    else
                        prev.Next = current.Next;

                    if (current == tail)
                        tail = prev;

                    count--;
                    return true;
                }

                prev = current;
                current = current.Next;
            }

            return false;
        }

        public bool IsObjectAtIndex(T value, int index)
        {
            if (index < 0 || index >= count) return false;

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value.Equals(value);
        }

        public T FindByIndex(int index)
        {
            if (index < 0 || index >= count) return default(T);

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public int Count()
        {
            return count;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
    }
}
