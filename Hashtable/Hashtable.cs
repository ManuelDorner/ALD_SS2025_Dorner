using ArrayList;
using SinglyLinkedList;
using System;

namespace Hashtable
{
    public class Hashtable<K, V>
    {
        private ArrayList.ArrayList<SinglyLinkedList.SinglyLinkedList<Tuple<K, V>>> m_container;
        private int counter = 0;

        public Hashtable(int size)
        {
            m_container = new ArrayList.ArrayList<SinglyLinkedList.SinglyLinkedList<Tuple<K, V>>>(size);
            for (int i = 0; i < size; i++)
            {
                m_container.Add(new SinglyLinkedList.SinglyLinkedList<Tuple<K, V>>());
            }
        }

        public void put(K key, V value)
        {
            int index = Math.Abs(key.GetHashCode() % m_container.Count());
            var bucket = m_container[index];

            for (int i = 0; i < bucket.Count(); i++)
            {
                if (bucket.FindByIndex(i).Item1.Equals(key))
                {
                    bucket.Remove(bucket.FindByIndex(i));
                    bucket.Add(new Tuple<K, V>(key, value));
                    return;
                }
            }

            bucket.Add(new Tuple<K, V>(key, value));
            counter++;

            if (LoadFactor() > 1.5f)
            {
                Rehash();
            }
        }

        public bool get(K key, out V value)
        {
            int index = Math.Abs(key.GetHashCode() % m_container.Count());
            var bucket = m_container[index];

            for (int i = 0; i < bucket.Count(); i++)
            {
                if (bucket.FindByIndex(i).Item1.Equals(key))
                {
                    value = bucket.FindByIndex(i).Item2;
                    return true;
                }
            }

            value = default;
            return false;
        }

        public bool Remove(K key)
        {
            int index = Math.Abs(key.GetHashCode() % m_container.Count());
            var bucket = m_container[index];

            for (int i = 0; i < bucket.Count(); i++)
            {
                if (bucket.FindByIndex(i).Item1.Equals(key))
                {
                    counter--;
                    return bucket.Remove(bucket.FindByIndex(i));
                }
            }

            return false;
        }

        public bool ContainsKey(K key)
        {
            int index = Math.Abs(key.GetHashCode() % m_container.Count());
            var bucket = m_container[index];

            for (int i = 0; i < bucket.Count(); i++)
            {
                if (bucket.FindByIndex(i).Item1.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public float LoadFactor()
        {
            return (float)counter / m_container.Count();
        }

        private void Rehash()
        {
            int newSize = m_container.Count() * 2;
            var oldContainer = m_container;

            m_container = new ArrayList.ArrayList<SinglyLinkedList.SinglyLinkedList<Tuple<K, V>>>(newSize);
            for (int i = 0; i < newSize; i++)
            {
                m_container.Add(new SinglyLinkedList.SinglyLinkedList<Tuple<K, V>>());
            }

            counter = 0;
            for (int i = 0; i < oldContainer.Count(); i++)
            {
                var oldBucket = oldContainer[i];
                if (oldBucket != null)
                {
                    for (int j = 0; j < oldBucket.Count(); j++)
                    {
                        var item = oldBucket.FindByIndex(j);
                        put(item.Item1, item.Item2);
                    }
                }
            }
        }
    }
}
