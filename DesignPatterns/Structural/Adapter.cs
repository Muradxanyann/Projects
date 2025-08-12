using System.ComponentModel.DataAnnotations;

namespace StructuralTask1
{
    public class Product
    {
        public required string Name { get; set; }
        public double Price { get; set; }
    }

    interface IProductProvider
    {
        Product GetProduct();
    }

    class CsvProductAdapter : IProductProvider
    {
        private readonly string csvText;
        public CsvProductAdapter(string csvText) => this.csvText = csvText;
        public Product GetProduct()
        {
            var temp = csvText.Split(',');
            string name = temp[0];
            if (!double.TryParse(temp[1], out double price))
                throw new FormatException("price must be figure.");
            return new Product
            {
                Name = name,
                Price = price
            };
        }
    }

}

