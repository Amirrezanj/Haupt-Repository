
using _04.Models;

namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wiederstand wiederstand1 = new Wiederstand(100,"r1");
            Wiederstand wiederstand2 = new Wiederstand(200,"r2");
            Wiederstand wiederstand3 = new Wiederstand(300,"r3");
            Wiederstand wiederstand4 = new Wiederstand(400,"r4");
            Wiederstand wiederstand5 = new Wiederstand(500,"r5");
            Wiederstand wiederstand6 = new Wiederstand(600,"r6");

            Paralelschaltung paralelschaltung1 = new Paralelschaltung(wiederstand1,wiederstand3);
            paralelschaltung1.Ausgabe();

            Reihenschaltung reihenschaltung1 = new Reihenschaltung(wiederstand4,wiederstand5);
            reihenschaltung1 .Ausgabe();
            
            Reihenschaltung reihenschaltung2 = new Reihenschaltung(paralelschaltung1,wiederstand2 );
            reihenschaltung2 .Ausgabe();

            Paralelschaltung paralelschaltung3 = new Paralelschaltung(reihenschaltung2,reihenschaltung1,wiederstand6 );
            paralelschaltung3 .Ausgabe();
        }
    }
}