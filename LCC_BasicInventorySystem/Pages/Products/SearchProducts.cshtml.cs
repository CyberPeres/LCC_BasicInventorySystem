using Microsoft.AspNetCore.Mvc.RazorPages;
using LCC_BasicInventorySystem.Models;
using LCC_BasicInventorySystem.Services;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace LCC_BasicInventorySystem.Pages.Products
{
    public class SearchProductsModel : PageModel
    {
        private readonly InventoryService _inventoryService;

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? MinQty { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? MaxQty { get; set; }

        public List<Product> SearchResults { get; set; }

        public SearchProductsModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void OnGet()
        {
            var products = _inventoryService.GetAllProducts().ToList();

            if (!string.IsNullOrEmpty(SearchName))
                products = products.Where(p => p.Name.Contains(SearchName, System.StringComparison.OrdinalIgnoreCase)).ToList();

            if (MinQty.HasValue)
                products = products.Where(p => p.Quantity >= MinQty.Value).ToList();

            if (MaxQty.HasValue)
                products = products.Where(p => p.Quantity <= MaxQty.Value).ToList();

            SearchResults = products;
        }
    }
}
