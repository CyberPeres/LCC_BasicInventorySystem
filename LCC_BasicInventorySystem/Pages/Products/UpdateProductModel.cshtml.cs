using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LCC_BasicInventorySystem.Services;

namespace LCC_BasicInventorySystem.Pages.Products
{
    public class UpdateProductModel : PageModel
    {
        private readonly InventoryService _inventoryService;

        [BindProperty]
        public string ProductId { get; set; }
        [BindProperty]
        public int CurrentQuantity { get; set; }
        [BindProperty]
        public int AdjustAmount { get; set; }
        public string Message { get; set; }

        public UpdateProductModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // Lookup Product (OnGet)
        public void OnGet([FromQuery] string productId) //FromQuery gets the prod id from the URL. AH ha moment -KP.
        {
            Console.WriteLine($"Received Product ID: {productId}");

            if (!string.IsNullOrEmpty(productId))
            {
                var existingProduct = _inventoryService.GetProductById(productId);
                if (existingProduct != null)
                {
                    ProductId = existingProduct.Id;
                    CurrentQuantity = existingProduct.Quantity;
                }
                else
                {
                    Message = "Error: Product not found!";
                }
            }
        }

        // Handle Stock Update (OnPost)
        public void OnPost(string action)
        {
            var existingProduct = _inventoryService.GetProductById(ProductId);

            if (existingProduct == null)
            {
                Message = "Error: Product not found!";
                return;
            }

            //supress negatives here.
            if (AdjustAmount < 0)
            {
                Message = "Quantity cannot be negative.";
                return;
            }

            CurrentQuantity = existingProduct.Quantity;

            if (action == "increase")
            {
                if (AdjustAmount > 0)
                {
                    _inventoryService.UpdateQuantity(ProductId, CurrentQuantity + AdjustAmount);
                    Message = $"Stock increased by {AdjustAmount}!";
                }
                else
                {
                    Message = $"No Change in stock amt.";
                }
            }
            else if (action == "decrease")
            {

                if (AdjustAmount == 0)
                {
                    Message = $"No Change in stock amt.";
                    return;
                }

                if (CurrentQuantity - AdjustAmount >= 0)
                {
                    _inventoryService.UpdateQuantity(ProductId, CurrentQuantity - AdjustAmount);
                    Message = $"Stock decreased by {AdjustAmount}!";
                }
                else
                {
                    Message = "Error: Cannot reduce stock below zero!";
                }
            }
        }
    }
}