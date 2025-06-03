using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LCC_BasicInventorySystem.Services;

namespace LCC_BasicInventorySystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly InventoryService _inventoryService;

        public int TotalProducts { get; set; }
        public int LowStockCount { get; set; }

        public IndexModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        public void OnGet()
        {
            TotalProducts = _inventoryService.GetTotalProducts();            
        }


    }
}
