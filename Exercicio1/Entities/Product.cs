using System.Globalization;

namespace Exercicio1.Entities
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public double TotalValue()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            return Name + "," + TotalValue().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
