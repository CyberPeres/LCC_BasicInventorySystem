using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LCC_BasicInventorySystem.Services;

namespace LCC_BasicInventorySystem.Pages.Products
{
    public class DeleteProductModel : PageModel
    {
        private readonly InventoryService _inventoryService;

        [BindProperty]
        public string ProductId { get; set; }
        public string Message { get; set; }

        public DeleteProductModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void OnPost()
        {
            var existingProduct = _inventoryService.GetProductById(ProductId);

            if (existingProduct != null)
            {
                _inventoryService.DeleteProduct(ProductId);
                Message = "Product deleted successfully!";
            }
            else
            {
                Message = "Error: Product not found!";
            }
        }
    }
}