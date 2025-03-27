using System;

namespace ArrayList
{
    public class ArrayList<T>
    {
        private T[] items;
        private int count;

        // Konstruktor mit Startgröße
        public ArrayList(int initialSize = 4)
        {
            if (initialSize <= 0)
                throw new ArgumentException("Initialgröße muss größer als 0 sein.");
            items = new T[initialSize];
            count = 0;
        }

        // Anzahl belegter Elemente
        public int Count() => count;

        // Indexer: list[i]
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();
                items[index] = value;
            }
        }

        // Fügt ein Element am Ende hinzu
        public void Add(T item)
        {
            if (count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
            items[count++] = item;
        }

        // Einfügen an bestimmtem Index
        public void InsertAt(int index, T item)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }

            for (int i = count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
            count++;
        }

        // Entfernt Element an Index
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                return false;

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            count--;
            ShrinkIfNeeded();
            return true;
        }

        // Entfernt erstes passendes Element
        public bool Remove(T item)
        {
            int index = -1;

            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return false;

            return RemoveAt(index);
        }

        // Gibt true zurück, wenn item enthalten ist
        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                    return true;
            }
            return false;
        }

        // Setzt die Liste zurück
        public void Clear()
        {
            items = new T[4];
            count = 0;
        }

        // Verkleinert, wenn zur Hälfte leer
        private void ShrinkIfNeeded()
        {
            if (count <= items.Length / 2 && items.Length > 4)
            {
                int newSize = Math.Max(items.Length / 2, 4);
                Array.Resize(ref items, newSize);
            }
        }
    }
}
