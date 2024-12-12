namespace _7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };

            //1
            var first5 = numbers.Take(5);
            foreach (var x in first5)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();
            //2
            var last5 = numbers.Skip(numbers.Length - 5).Take(5);
            foreach (var x in last5)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();

            //3
            var bis = numbers.Skip(3).Take(numbers.Length-6);
            foreach (var x in bis)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();

            //4
            var positiveNumbers = numbers.Where(x => x > 0);
            foreach (var x in positiveNumbers)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();

            //5
            int indexOf12 = Array.IndexOf(numbers, 12);
            var after12 = numbers.Skip(indexOf12 + 1);
            foreach (var x in after12)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();

            //6
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderpath = Path.Combine(desktop, "AE");
            DirectoryInfo directoryInfo = new DirectoryInfo(folderpath);

            foreach (var file in directoryInfo.GetFiles().OrderByDescending(x =>x.LastWriteTime).Take(5))
            {
                Console.Write($"{file.Name} ,");
            }
        }
    }
}
