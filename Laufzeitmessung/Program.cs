using System;
using System.Diagnostics;
using Rechtschreibpruefung;
using ArrayList;
using SinglyLinkedList;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Datei laden
        var loader = new FileLoader("german.dic");
        loader.SaveFileDataToSingleLinkedList();

        // Daten aus der SinglyLinkedList in string[] umwandeln
        var words = new List<string>();
        var current = loader.data.Head;
        while (current != null)
        {
            words.Add(current.Value);
            current = current.Next;
        }
        string[] wordArray = words.ToArray();

        // Vorbereitung
        int total = wordArray.Length;
        int middle = total / 2;
        string searchWord = wordArray[total / 3];

        // Neue Instanzen erstellen
        var sll = new SinglyLinkedList<string>(); // leer!
        var arrList = new ArrayList<string>(wordArray.Length);

        Stopwatch sw = new Stopwatch();

        // SLL: Hinzufügen
        sw.Start();
        foreach (var word in wordArray)
            sll.Add(word);
        sw.Stop();
        Console.WriteLine($"SLL - Hinzufügen: {sw.ElapsedMilliseconds} ms");

        // ArrayList: Hinzufügen
        sw.Reset();
        sw.Start();
        foreach (var word in wordArray)
            arrList.Add(word);
        sw.Stop();
        Console.WriteLine($"ArrayList - Hinzufügen: {sw.ElapsedMilliseconds} ms");

        // SLL: Zugriff
        sw.Reset();
        sw.Start();
        var sllMid = sll[middle];
        sw.Stop();
        Console.WriteLine($"SLL - Zugriff (Index {middle}): {sw.ElapsedMilliseconds} ms");

        // ArrayList: Zugriff
        sw.Reset();
        sw.Start();
        var arrMid = arrList[middle];
        sw.Stop();
        Console.WriteLine($"ArrayList - Zugriff (Index {middle}): {sw.ElapsedMilliseconds} ms");

        // SLL: Suche
        sw.Reset();
        sw.Start();
        bool foundInSll = sll.Contains(searchWord);
        sw.Stop();
        Console.WriteLine($"SLL - Suche nach '{searchWord}': {sw.ElapsedMilliseconds} ms");

        // ArrayList: Suche
        sw.Reset();
        sw.Start();
        bool foundInArr = arrList.Contains(searchWord);
        sw.Stop();
        Console.WriteLine($"ArrayList - Suche nach '{searchWord}': {sw.ElapsedMilliseconds} ms");
    }
}

