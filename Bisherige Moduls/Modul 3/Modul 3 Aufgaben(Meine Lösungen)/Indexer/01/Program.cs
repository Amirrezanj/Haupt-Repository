namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShopingList shopingList = new ShopingList(3);
            shopingList[0]= "milch";
            shopingList[1]= "käse";
            shopingList[2]= "Butter";

            string ind = shopingList[0];
            Console.WriteLine(ind);

            int ind2 = shopingList["Butter"];
            Console.WriteLine(ind2);



        }
    }
    public class ShopingList
    {
        public string[] obj;
        public ShopingList(int Kapazität)
        {
            obj = new string[Kapazität];
        }
        public string this[int index]
        {
            get
            {
                return obj[index];
            }
            set
            {
                obj[index] = value;
            }
        }
        public int this[string wort]
        {
            get
            {
                for (int i = 0; i < obj.Length; i++)
                {
                    if (obj[i] == wort)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }


    }
}