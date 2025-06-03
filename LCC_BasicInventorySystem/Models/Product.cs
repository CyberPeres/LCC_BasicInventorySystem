using System.ComponentModel.DataAnnotations;

namespace LCC_BasicInventorySystem.Models
{
    public class Product
    {
        public string Id { get; set; }      // Unique product ID
        public string Name { get; set; }    // Name of the product
        public int Quantity { get; set; }   // Current stock quantity

        // (Important) Parameterless constructor required for model binding
        public Product() { }

        // Constructor for initializing products
        // More robustly, I'd build in limits with exception handling to prevent
        // negative values from entering. this could be controlled by the
        // database engine of choice also.
        public Product(string id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        // Override ToString() for readable output
        public override string ToString()
        {
            return $"ID: {Id} | Name: {Name} | Quantity: {Quantity}";
        }


    }
}
