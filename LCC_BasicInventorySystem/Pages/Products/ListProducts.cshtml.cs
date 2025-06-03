using Microsoft.AspNetCore.Mvc.RazorPages;
using LCC_BasicInventorySystem.Models;
using LCC_BasicInventorySystem.Services;
using System.Collections.Generic;

namespace LCC_BasicInventorySystem.Pages.Products
{
    public class ListProductsModel : PageModel
    {
        private readonly InventoryService _inventoryService;
        public List<Product> Products { get; set; }

        public ListProductsModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void OnGet()
        {
            Products = _inventoryService.GetAllProducts().ToList();
        }
    }
}
