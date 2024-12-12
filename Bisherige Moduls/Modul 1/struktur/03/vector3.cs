

using System.Transactions;

namespace _03
{
    struct vector3
    {
        public double x;
        public double y;
        public double z;


        public string AsString()
        {
            return $"„{x},{y},{z}“";
        }
        public double Länge()
        {
            double hochUndPlus=((x*x)+(y*y)+(z*z));
            double würzel = Math.Sqrt(hochUndPlus);
            return würzel;
        }
    }
}
