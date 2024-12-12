//using System.Net;

//namespace _02
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            string directoryPath = @"C:\Lookup";
//            FileSystemWatcher watcher = new FileSystemWatcher(directoryPath);
//            watcher.Created += Watcher_Created;
//            watcher.EnableRaisingEvents = true;
//        }

//        private static void Watcher_Created(object sender, FileSystemEventArgs e)
//        {
//            Console.WriteLine();
//        }
//    }
//}


















using System.Globalization;
using System.Net;
 
namespace aufgabe_2
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string fqdn = "server1.example.com.";
            string path = "C:\\";
            path = Path.Combine(path, "Lookup");

            Console.WriteLine(path);
            FileSystemWatcher watcher = new FileSystemWatcher(path, "*.lookup");
            watcher.Created += GetIPAdresse;
            watcher.EnableRaisingEvents = true;
            Console.ReadLine();
        }

        private static void GetIPAdresse(object sender, FileSystemEventArgs e)
        {
            string fqdn;
            string[] text = File.ReadAllLines(e.FullPath);
            string ausgabePath = Path.Combine(@"C:\resolved", "resolved.resolved");

            FileStream st = new FileStream(ausgabePath, FileMode.Append);

            StreamWriter write = new StreamWriter(st);
            write.AutoFlush = true;

            for (int i = 0; i < text.Length; i++)
            {
                IPAddress[] ips;
                ips = Dns.GetHostAddresses(text[i]);
                for (int j = 0; j < ips.Length; j++)
                {
                    write.WriteLine(ips[j].ToString());
                }
            }
            st.Close();
        }
    }
}