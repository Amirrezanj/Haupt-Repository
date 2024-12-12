namespace _04
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
            double hochUndPlus = ((x * x) + (y * y) + (z * z));
            double würzel = Math.Sqrt(hochUndPlus);
            return würzel;
        }
        public vector3 Multiply(vector3 a)
        {
            vector3 resault;
            resault.x = a.x * x;
            resault.y = a.y * y;
            resault.z = a.z * z;
            return resault;
        }
    }
}