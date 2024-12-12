using static System.Net.Mime.MediaTypeNames;

namespace Aufgabe6_MylinkedQueue_
{
    public class Entry
    {
        private string _data;
        private Entry _next;

        public Entry(string data)
        {
            _data = data;
            _next = null;
        }

        public string GetData()
        {
            return _data;
        }


        public void SetNext(Entry nextEntry)
        {
            _next = nextEntry;
        }

        public Entry GetNext()
        {
            return _next;
        }
    }

    public class MyLinkedQueue
    {
        private Entry _head; //  erste element in schlange
        private Entry _tail; // und letzter

        public MyLinkedQueue()
        {
            _head = null;
            _tail = null;
        }

        public bool IsEmpty()
        {
            return _head == null;
        }

        public void Enqueue(string data)
        {
            Entry newEntry = new Entry(data);

            _tail.SetNext(newEntry);
            _tail = newEntry;
        }


        public string Dequeue()
        {
            if (IsEmpty())
            {
                return "leer";
            }
            string result = _head.GetData();
            _head=_head.GetNext();

            return result;
        }
        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("leer.");
                return;
            }
            Entry current = _head;
            while (current != null)
            {
                Console.WriteLine(current.GetData());
                current = current.GetNext();
            }
        }
    }
}
