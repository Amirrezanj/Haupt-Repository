using GenerischeFlascheApp;

namespace _01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Bier bier = new Bier("Pilsener", "Musterbrauerei");
            Rotwein rotwein = new Rotwein("Merlot", "Bordeaux");
            Weißwein weißwein = new Weißwein("Riesling", "Mosel");

            Flasche<Bier> bierFlasche = new Flasche<Bier>();
            Flasche<Rotwein> rotweinFlasche = new Flasche<Rotwein>();
            Flasche<Weißwein> weißweinFlasche = new Flasche<Weißwein>();

            bierFlasche.Füllen(bier);
            rotweinFlasche.Füllen(rotwein);
            weißweinFlasche.Füllen(weißwein);

            bier.ZeigeInfo();
            rotwein.ZeigeInfo();
            weißwein.ZeigeInfo();

            bierFlasche.Leeren();
            rotweinFlasche.Leeren();
            weißweinFlasche.Leeren();

        }
    }
}
































public class SimpleList<T> where T : IComparable<T>
{
    private class Node
    {
        public T Data;
        public Node Next;

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;
    private int count;

    public SimpleList()
    {
        head = null;
        count = 0;
    }

    public void Insert(T element)
    {
        Node newNode = new Node(element);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        count++;
    }

    // 2. Elemente aus der Liste löschen
    public bool Delete(T element)
    {
        if (head == null)
        {
            return false; // Liste ist leer
        }

        if (head.Data.CompareTo(element) == 0)
        {
            head = head.Next;
            count--;
            return true;
        }

        Node current = head;
        while (current.Next != null)
        {
            if (current.Next.Data.CompareTo(element) == 0)
            {
                current.Next = current.Next.Next;
                count--;
                return true;
            }
            current = current.Next;
        }
        return false; // Element nicht gefunden
    }

    // 3. Elemente in der Liste suchen
    public bool Search(T element)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.CompareTo(element) == 0)
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    // 4. Anzahl der gerade in der Liste enthaltenen Elemente zurückgeben
    public int Count()
    {
        return count;
    }

    // 5. Aus der Liste ein Array von Elementen erzeugen
    public T[] ToArray()
    {
        T[] array = new T[count];
        Node current = head;
        int index = 0;
        while (current != null)
        {
            array[index++] = current.Data;
            current = current.Next;
        }
        return array;
    }
}



class Program
{
    static void Main(string[] args)
    {
        // Erstellen einer SimpleList von int
        SimpleList<int> intList = new SimpleList<int>();

        // Elemente einfügen
        intList.Insert(10);
        intList.Insert(20);
        intList.Insert(30);
        Console.WriteLine("Elemente in der Liste eingefügt.");

        // Elemente zählen
        Console.WriteLine("Anzahl der Elemente in der Liste: " + intList.Count());

        // Suche nach einem Element
        int elementToSearch = 20;
        bool found = intList.Search(elementToSearch);
        Console.WriteLine($"Element {elementToSearch} gefunden: {found}");

        // Element löschen
        int elementToDelete = 20;
        bool deleted = intList.Delete(elementToDelete);
        Console.WriteLine($"Element {elementToDelete} gelöscht: {deleted}");

        // Anzahl der Elemente nach dem Löschen
        Console.WriteLine("Anzahl der Elemente in der Liste nach dem Löschen: " + intList.Count());

        // Die Liste in ein Array konvertieren und ausgeben
        int[] array = intList.ToArray();
        Console.WriteLine("Liste als Array: " + string.Join(", ", array));

        // Beispiel für eine SimpleList mit Strings
        SimpleList<string> stringList = new SimpleList<string>();
        stringList.Insert("Apfel");
        stringList.Insert("Banane");
        stringList.Insert("Kirsche");
        Console.WriteLine("Anzahl der Elemente in der String-Liste: " + stringList.Count());
    }
}
