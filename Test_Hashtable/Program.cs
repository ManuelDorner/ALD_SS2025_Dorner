using System;
using Hashtable;

namespace Test_Hashtable
{
    class Program
    {
        static void Main(string[] args)
        {
            int tableSize = 10;
            var hashtable = new Hashtable<person, int>(tableSize);

            Console.WriteLine("--- Test: Änderung einer Schlüssel-Instanz nach Einfügen ---");

            var p = new person("Hansi", 30);
            hashtable.put(p, 999);

            int hash1 = p.GetHashCode();
            int bucket1 = Math.Abs(hash1 % tableSize);
            Console.WriteLine($"\n1. Name: {p.name}, Hash: {hash1}, Bucket: {bucket1}");

            if (hashtable.get(p, out int val1))
                Console.WriteLine("Vor Änderung: Gefunden! Wert = " + val1);
            else
                Console.WriteLine("Vor Änderung: Nicht gefunden!");


            p.name = "Michael";
            int hash2 = p.GetHashCode();
            int bucket2 = Math.Abs(hash2 % tableSize);
            Console.WriteLine($"\n3. Name: {p.name}, Hash: {hash2}, Bucket: {bucket2}");

            if (hashtable.get(p, out int val2))
                Console.WriteLine("Nach zweiter Änderung: Gefunden! Wert = " + val2);
            else
                Console.WriteLine("Nach zweiter Änderung: Nicht gefunden!");
        }

        class person
        {
            public string name { get; set; }
            public int age { get; set; }

            public person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                person p = (person)obj;
                return name.Equals(p.name) && age.Equals(p.age);
            }

            public override int GetHashCode()
            {
                return (name.GetHashCode() * 397) ^ age.GetHashCode();
            }

            public override string ToString()
            {
                return $"Person(Name: {name}, Age: {age})";
            }
        }
    }
}
