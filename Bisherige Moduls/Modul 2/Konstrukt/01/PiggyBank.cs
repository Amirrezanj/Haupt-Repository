namespace _01
{
    internal class PiggyBank
    {
        private int _1cent;
        private int _10cent;
        private int _50cent;
        private int _1euro;

        private int _gesamt;
        private int _gesamtbetrag;

        private int _max;
        private bool _aufgebrochen=false;

        public PiggyBank(int max)
        {
            _max = max;
        }

        public void Add1Cent(int anzahl1)
        {
            if (_max > _gesamt+anzahl1)
            {
                _1cent += anzahl1;
                //_1cent += 1;
                _gesamt += anzahl1;
                //_max -= anzahl1;
                Console.WriteLine(anzahl1 +" mal 1 cent added");
                
            }
            else
            {
                int rest = _max - _gesamt; 
                _1cent += rest;
                _gesamt += rest;
                Console.WriteLine($"{rest} mal 1Cent hinzugefügt, aber {anzahl1 - rest} münzen passen nicht mehr");
            }

        }

        public void Add10Cent(int anzahl10)
        {
            if (_max > _gesamt+anzahl10)
            {
                //_10cent += 1;
                _10cent += anzahl10;
                _gesamt += anzahl10;
                //_max -= anzahl10;
                Console.WriteLine(anzahl10+" mal 10 cent added");

            }
            else
            {
                int rest = _max - _gesamt; 
                _1cent += rest;
                _gesamt += rest;
                Console.WriteLine($"{rest} mal 1Cent hinzugefügt, aber {anzahl10 - rest} münzen passen nicht mehr");
            }
        }

        public void Add50Cent(int anzahl50)
        {
            if (_max > _gesamt+anzahl50)
            {
                //_50cent += 1;
                _50cent += anzahl50;
                _gesamt += anzahl50;
                //_max -= anzahl50;
                Console.WriteLine(anzahl50+" mal 50 cent added");
            }
            else
            {
                int rest = _max - _gesamt; 
                _1cent += rest;
                _gesamt += rest;
                Console.WriteLine($"{rest} mal 1Cent hinzugefügt, aber {anzahl50 - rest} münzen passen nicht mehr");
            }
        }

        public void Add1euro(int anzahl100)
        {
            if (_max > _gesamt+anzahl100)
            {
                //_1euro += 1;
                _1euro += anzahl100 ;
                _gesamt += anzahl100;
                //_max -= anzahl100;
                Console.WriteLine(anzahl100+" mal 1 Euro added");
            }
            else
            {
                int rest = _max - _gesamt; 
                _1cent += rest;
                _gesamt += rest;
                Console.WriteLine($"{rest} mal 1Cent hinzugefügt, aber {anzahl100 - rest} münzen passen nicht mehr");
            }
        }

        public void shake()
        {
            if (_gesamt == 0)
            {
                Console.WriteLine("piggy ist leer");
            }
            else if (_gesamt < _max / 3)
            {
                Console.WriteLine("piggy ist etwa ein Drittel voll");
            }
            else if (_gesamt < _max / 2)
            {
                Console.WriteLine("piggy ist etwa halb voll");
            }
            else if (_gesamt == _max)
            {
                Console.WriteLine("piggy ist voll ! nicht alles ausgeben!!!");
            }
            else if (_gesamt > _max / 2)
            {
                Console.WriteLine("piggy ist etwa 2/3 voll");
            }
        }

        public void Breackinto()
        {
            _aufgebrochen= true;
            Console.WriteLine($"insgesamt sind {_gesamt} münzen drin und zwar \n{_1cent} mal 1Cent\n{_10cent} mal 10Cent\n{_50cent} mal 50Cent\n{_1euro} mal 1 euro ");
            int gesamtbetrag=(_1cent*1)+(_10cent*10)+(_50cent*50)+(_1euro*100);
            Console.WriteLine("gesamt betrag in cent: "+gesamtbetrag);
            _1cent = 0;
            _10cent = 0;
            _50cent = 0;
            _1euro = 0;
            _gesamt = 0;
        }
        public bool IsBrocken()
        {
            return _aufgebrochen;
        }
    }
}