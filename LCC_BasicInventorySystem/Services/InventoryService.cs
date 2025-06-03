//using InventoryApp.Models; //not found at the moment.

using LCC_BasicInventorySystem.Models;

namespace LCC_BasicInventorySystem.Services
{
    public class InventoryService
    {
        private readonly List<Product> _products = new();
        private Product _selectedProduct;
        public void SetSelectedProduct(Product product) => _selectedProduct = product;
        public Product GetSelectedProduct() => _selectedProduct;



        public IEnumerable<Product> GetAllProducts() => _products;

        public Product GetProductById(string id) => _products.FirstOrDefault(p => p.Id == id);

        public void AddProduct(Product product)
        {
            if (!_products.Any(p => p.Id == product.Id)) // Ensure unique ID
            {
                _products.Add(product);
            }
        }

        public void UpdateQuantity(string id, int newQuantity)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null && newQuantity >= 0) //Prevents negative numbers TODO NEED TO WARN USERS
            {
                product.Quantity = newQuantity;
            }
        }

        public void DeleteProduct(string id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public int GetTotalProducts()
        {
            return _products.Count; 
        }
    }


}
