
namespace BehaviouralTask6
{
    interface IProduct
    {
        void Accept(IDiscountVisitor visitor);
        decimal Price { get; }
        string Name { get; }
    }

    class Book : IProduct
    {
        public string Name { get; }
        public decimal Price { get; private set; }

        public Book(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void Accept(IDiscountVisitor visitor)
        {
            visitor.Visit(this);
        }
        public void SetPrice(decimal price) => Price = price;

    }
    class Electronics : IProduct
    {
        public string Name { get; }
        public decimal Price { get; private set; }

        public Electronics(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void Accept(IDiscountVisitor visitor)
        {
            visitor.Visit(this);
        }
        public void SetPrice(decimal price) => Price = price;
    }
    class Clothing : IProduct
    {
        public string Name { get; }
        public decimal Price { get; private set; }

        public Clothing(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void Accept(IDiscountVisitor visitor)
        {
            visitor.Visit(this);
        }
        public void SetPrice(decimal price) => Price = price;
    }

    interface IDiscountVisitor
    {
        void Visit(Book product);
        void Visit(Electronics product);
        void Visit(Clothing product);
    }

    class HolidayDiscountVisitor : IDiscountVisitor
    {
        // e.g., 10% off books, 5% off electronics, 15% off clothing
        public void Visit(Book product)
        {
            var newPrice = product.Price * 0.9m;
            product.SetPrice(newPrice);
        }

        public void Visit(Electronics product)
        {
            var newPrice = product.Price * 0.95m;
            product.SetPrice(newPrice);
        }

        public void Visit(Clothing product)
        {
            var newPrice = product.Price * 0.85m;
            product.SetPrice(newPrice);
        }
    }

    class BlackFridayVisitor : IDiscountVisitor
    {
        // e.g., 50% off electronics, 30% off clothing, no book discounts
        public void Visit(Book product)
        {
            return;
        }

        public void Visit(Electronics product)
        {
            var newPrice = product.Price * 0.5m;
            product.SetPrice(newPrice);
        }

        public void Visit(Clothing product)
        {
           var newPrice = product.Price * 0.7m;
            product.SetPrice(newPrice);
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            List<IProduct> cart = new()
            {
                new Book("Design Patterns", 40),
                new Electronics("Headphones", 120),
                new Clothing("Jacket", 80)
            };

            IDiscountVisitor holidaySale = new BlackFridayVisitor();

            foreach (var item in cart)
            {
                item.Accept(holidaySale);
                Console.WriteLine(item.Price);
            }


        }
    }
}