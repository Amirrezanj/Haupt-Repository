using System.Xml.Serialization;

namespace _001
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //serialisierung
            Books books = new Books()
            {
                books = new List<Book>()
                {
                    new Book()
                    {
                        id=1,
                        title="The Great Gatsby",
                        author="F. Scott Fitzgerald",
                        ISBN=978,
                        publisher=new Publisher()
                        {
                            Name="Scribner",
                            Year=2020
                        }
                        ,
                        Price=new Price()
                        {
                            Currency="usd",
                            Value=15
                        }
                        ,
                        Tags= new Tags()
                        {
                            Tag = new List<Tag>()
                            {
                                new Tag()
                                {
                                    Name="classic"
                                }
                            }
                        }
                        ,
                        Reviews=new Reviews()
                        {
                            review=new List<Review>()
                            {
                                new Review()
                                {
                                    Rating=5,
                                    Comment="A masterpiece of the Jazz Age.",

                                }
                            }
                            
                        }
                    }
                }
            };
            XmlSerializer serializer = new XmlSerializer(typeof(Books));
            using TextWriter writer = new StreamWriter(@"C:\Users\ITAD2-TN15\Desktop\books.xml");
            serializer.Serialize(writer, books);
        }
        [XmlRoot]
        public class Books
        {
            public List<Book> books { get; set; }
        }
        [XmlRoot]
        public class Book
        {
            [XmlAttribute]
            public int id { get; set; }

            [XmlAttribute]
            public string title { get; set; }

            [XmlAttribute]
            public string author { get; set; }

            public int ISBN { get; set; }

            public Publisher publisher { get; set; }
            public Price Price { get; set; }
            public Tags Tags { get; set; }
            public Reviews Reviews { get; set; }
        }
        public class Publisher
        {
            [XmlAttribute]
            public string Name { get; set; }

            [XmlAttribute]
            public int Year { get; set; }
        }
        public class Price
        {
            [XmlAttribute]
            public string Currency { get; set; }

            public double Value { get; set; }
        }
        public class Tags
        {
            public List<Tag> Tag { get; set; }
        }
        public class Tag 
        {
            public string Name { get; set; }
        }
        public class Reviews
        {
            public List<Review> review { get; set; }
        }
        public class Review
        {
            [XmlAttribute]
            public int Rating { get; set; }

            [XmlAttribute]
            public string Comment { get; set; }
        }
    }
}