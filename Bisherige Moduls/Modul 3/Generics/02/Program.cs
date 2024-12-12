namespace _02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class SimpleList<T> where T : IComparable<T>
    {
        private class Element
        {
            public Element nextelement;
            public Element()
            {
                nextelement = null;
            } 
        }
        private Element _head;
        private int _count;

        public void Add(T element)
        {
            Element newelement = new Element();
            if (_head == null)
            {
                _head = newelement;
            }
            else
            {
                Element jetzige = _head;
                while (jetzige!=null)
                {
                    jetzige=jetzige.nextelement;
                }
                jetzige.nextelement=newelement;
            }
            _count++;
        }
        public void Remove(T element)
        {
            if (_head == null)
            {
                Console.WriteLine("sowieso leer");
            }
            if (_head.nextelement.CompareTo(element) == null)
            {
                
                
                
            }
            
                
            
        }
    }
}









namespace _02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SimpleList<int> myList = new SimpleList<int>();
            myList.Add(10);
            myList.Add(20);
            myList.Add(30);

            Console.WriteLine("Vor dem Entfernen:");
            myList.PrintList();

            myList.Remove(20);
            Console.WriteLine("Nach dem Entfernen:");
            myList.PrintList();

            int element = 30;
            bool found = myList.Search(element);
            Console.WriteLine(found ? $"Element {element} gefunden." : $"Element {element} nicht gefunden.");

            Console.WriteLine($"Anzahl der Elemente in der Liste: {myList.Count()}");
        }
    }

    public class SimpleList<T> where T : IComparable<T>
    {
        private class Element
        {
            public T Value { get; set; }
            public Element Next { get; set; }

            public Element(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Element _head;
        private int _count;

        public void Add(T value)
        {
            Element newElement = new Element(value);
            if (_head == null)
            {
                _head = newElement;
            }
            else
            {
                Element current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newElement;
            }
            _count++;
        }

        public void Remove(T value)
        {
            if (_head == null)
            {
                Console.WriteLine("Die Liste ist leer.");
                return;
            }

            if (_head.Value.CompareTo(value) == 0)
            {
                _head = _head.Next;
                _count--;
                return;
            }

            Element current = _head;
            while (current.Next != null && current.Next.Value.CompareTo(value) != 0)
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
                _count--;
            }
            else
            {
                Console.WriteLine("Element nicht gefunden.");
            }
        }

        public bool Search(T value)
        {
            Element current = _head;
            while (current != null)
            {
                if (current.Value.CompareTo(value) == 0)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public int Count()
        {
            return _count;
        }

        public void PrintList()
        {
            Element current = _head;
            while (current != null)
            {
                Console.Write(current.Value + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }
    }
}







public void Remove(T value)
{
    if (_head == null)
    {
        Console.WriteLine("Die Liste ist leer.");
        return;
    }

    if (_head.Value.CompareTo(value) == 0)
    {
        _head = _head.Next;
        _count--;
        return;
    }

    Element current = _head;
    for (int i = 0; current != null && current.Next != null; i++)
    {
        // Wir überprüfen, ob der nächste Knoten das zu entfernende Element ist
        if (current.Next.Value.CompareTo(value) == 0)
        {
            // Verknüpfung überspringen (next aus der Verkettung entfernen)
            current.Next = current.Next.Next;
            _count--;
            return;
        }

        current = current.Next;
    }

    // Wenn das Element nicht gefunden wurde
    Console.WriteLine("Element nicht gefunden.");
}













namespace _02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SimpleList<int> myList = new SimpleList<int>();
            myList.Add(10);
            myList.Add(20);
            myList.Add(30);

            Console.WriteLine("Vor dem Entfernen:");
            myList.PrintList();

            myList.Remove(20);
            Console.WriteLine("Nach dem Entfernen:");
            myList.PrintList();

            int element = 30;
            bool found = myList.Search(element);
            Console.WriteLine(found ? $"Element {element} gefunden." : $"Element {element} nicht gefunden.");

            Console.WriteLine($"Anzahl der Elemente in der Liste: {myList.Count()}");
        }
    }

    public class SimpleList<T> where T : IComparable<T>
    {
        private class Element
        {
            public Element Next { get; set; }
            public T Value;

            public Element(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Element _head;
        private int _count;

        public void Add(T value)
        {
            Element newElement = new Element(value);
            if (_head == null)
            {
                _head = newElement;
            }
            else
            {
                Element current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newElement;
            }
            _count++;
        }

        public void Remove(T value)
        {
            if (_head == null)
            {
                Console.WriteLine("Die Liste ist leer.");
                return;
            }

            if (_head.Value.CompareTo(value) == 0)
            {
                _head = _head.Next;
                _count--;
                return;
            }

            Element current = _head;
            while (current.Next != null && current.Next.Value.CompareTo(value) != 0)
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
                _count--;
            }
            else
            {
                Console.WriteLine("Element nicht gefunden.");
            }
        }

        public bool Search(T value)
        {
            Element current = _head;
            while (current != null)
            {
                if (current.Value.CompareTo(value) == 0)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public int Count()
        {
            return _count;
        }

        public void PrintList()
        {
            Element current = _head;
            while (current != null)
            {
                Console.Write(current.Value + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }
    }
}
