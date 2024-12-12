namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}










































using System;
using System.IO;

public class Person
{
    private string _name;
    private DateTime _geburtsdatum;

    // Konstruktor
    public Person(string name, DateTime geburtsdatum)
    {
        _name = name;
        _geburtsdatum = geburtsdatum;
    }

    // Einfacher Getter und Setter für Name
    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    // Einfacher Getter und Setter für Geburtsdatum
    public DateTime GetGeburtsdatum()
    {
        return _geburtsdatum;
    }

    public void SetGeburtsdatum(DateTime geburtsdatum)
    {
        _geburtsdatum = geburtsdatum;
    }

    // Methode zur Berechnung des Alters
    public int BerechneAlter()
    {
        int alter = DateTime.Today.Year - _geburtsdatum.Year;

        // Überprüfen, ob der Geburtstag in diesem Jahr schon war
        if (DateTime.Today < _geburtsdatum.AddYears(alter))
        {
            alter--;
        }

        return alter;
    }
}

public class Program
{
    public static void Main()
    {
        // Pfad zur Datei
        string dateiPfad = "Personen.txt";

        // Anzahl der Personen (Hier manuell auf 6 gesetzt, da wir 6 Zeilen in der Datei haben)
        int personenCount = 6;

        // Array zur Speicherung der Personen
        Person[] personen = new Person[personenCount];

        // Datei einlesen und Personen erstellen
        string[] zeilen = File.ReadAllLines(dateiPfad);

        // Personen aus den Dateizeilen erstellen
        for (int i = 0; i < zeilen.Length; i++)
        {
            string[] teile = zeilen[i].Split(':');
            string name = teile[0];
            DateTime geburtsdatum = DateTime.Parse(teile[1]);

            // Person ins Array einfügen
            personen[i] = new Person(name, geburtsdatum);
        }

        // Alter jeder Person berechnen und ausgeben
        int gesamtAlter = 0;
        for (int i = 0; i < personen.Length; i++)
        {
            int alter = personen[i].BerechneAlter();
            Console.WriteLine($"{personen[i].GetName()} ist {alter} Jahre alt.");
            gesamtAlter += alter;
        }

        // Durchschnittsalter berechnen
        double durchschnittsalter = (double)gesamtAlter / personen.Length;
        Console.WriteLine($"\nDurchschnittsalter der Gruppe: {durchschnittsalter:F2} Jahre.");
    }
}
