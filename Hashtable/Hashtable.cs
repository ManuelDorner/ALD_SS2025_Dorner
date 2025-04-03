using ArrayList;
using SinglyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    public class Hashtable<K, V>
    {

        public ArrayList.ArrayList<SinglyLinkedList.SinglyLinkedList<Tuple<K, V>>> m_container;
        int count = 0;
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
            key.GetHashCode();
            int index = key.GetHashCode() % m_container.Count();
            if (m_container[index] == null)
            {
                m_container[index] = new SinglyLinkedList.SinglyLinkedList<Tuple<K, V>>();
            }
            for (int i = 0; i < m_container[index].Count(); i++)
            {
                if (m_container[index].FindByIndex(i).Item1.Equals(key))
                {
                    m_container[index].Remove(m_container[index].FindByIndex(i));
                    m_container[index].Add(new Tuple<K, V>(key, value));
                    
                    return;
                }

                m_container[index].Add(new Tuple<K, V>(key, value));
                count++;
            }
            if (LoadFactor() > 1.5)
            {
                Rehash();
            }

        }

        public bool get(K key, out V value)
        {
            int index = key.GetHashCode() % m_container.Count();
            for (int i = 0; i < m_container[index].Count(); i++)
            {
                if (m_container[index].FindByIndex(i).Item1.Equals(key))
                {
                    value = m_container[index].FindByIndex(i).Item2;
                    return true;
                }
            }
            value = default;
            return false;
        }

        public bool Remove(K key)
        {
            int index = key.GetHashCode() % m_container.Count();
            for (int i = 0; i < m_container[index].Count(); i++)
            {
                if (m_container[index].FindByIndex(i).Item1.Equals(key))
                {
                    count--;
                    return m_container[index].Remove(m_container[index].FindByIndex(i));

                }
            }
            return false;
        }
        public bool ContainsKey(K key)
        {
            int index = key.GetHashCode() % m_container.Count();
            for (int i = 0; i < m_container[index].Count(); i++)
            {
                if (m_container[index].FindByIndex(i).Item1.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }


        public float LoadFactor()
        {
            return count / m_container.Count();

        }

        private void Rehash()
        {
            int newSize = m_container.Count() * 2;
            var oldContainer = m_container;
            m_container = new ArrayList.ArrayList<SinglyLinkedList.SinglyLinkedList<Tuple<K, V>>>(newSize);

            // Neue Buckets initialisieren
            for (int i = 0; i < newSize; i++)
            {
                m_container[i] = new SinglyLinkedList.SinglyLinkedList<Tuple<K, V>>();
            }

            // Alle alten Werte neu einfügen
            count = 0;
            for (int i = 0; i < oldContainer.Count(); i++)
            {
                if (oldContainer[i] != null)
                {
                    for (int j = 0; j < oldContainer[i].Count(); j++)
                    {
                        var item = oldContainer[i].FindByIndex(j);
                        put(item.Item1, item.Item2);
                    }
                }
            }
        }
    }
}

