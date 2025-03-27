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
        
        private ArrayList.ArrayList<SinglyLinkedList.SinglyLinkedList<Tuple<K, V>>> m_container;

        public void put(K key, V value)
        { 
            key.GetHashCode();
            
        }
        public V get(K key)
        {
            return default(V);
        }

        public bool get(K key, out V value)
        {
            value = default(V);
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
