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

        // Indexer
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

        // Hinzufügen am Ende
        public void Add(T item)
        {
            if (count == items.Length)
            {
                Resize(items.Length * 2);
            }
            items[count++] = item;
        }

        // Einfügen an einer bestimmten Position
        public void InsertAt(int index, T item)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (count == items.Length)
            {
                Resize(items.Length * 2);
            }

            for (int i = count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
            count++;
        }

        // Entfernt das Element an einer bestimmten Position
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

        // Entfernt das erste Vorkommen eines Wertes
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

        // Prüft, ob das Element enthalten ist
        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                    return true;
            }
            return false;
        }

        // Liste leeren
        public void Clear()
        {
            count = 0;
            items = new T[4]; // Rücksetzen auf Startgröße
        }

        // Verkleinert das Array, wenn mehr als die Hälfte ungenutzt ist
        private void ShrinkIfNeeded()
        {
            if (count <= items.Length / 2 && items.Length > 4)
            {
                Resize(Math.Max(items.Length / 2, 4));
            }
        }

        // Größe ändern
        private void Resize(int newSize)
        {
            T[] newArray = new T[newSize];
            for (int i = 0; i < count; i++)
            {
                newArray[i] = items[i];
            }
            items = newArray;
        }
    }
}
