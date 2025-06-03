using LCC_BasicInventorySystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LCC_BasicInventorySystem.Models;

namespace LCC_BasicInventorySystem.Pages.Products
{
    public class AddProductModel : PageModel
    {
        private readonly InventoryService _inventoryService;

        [BindProperty]
        public Product Product { get; set; }
        public string Message { get; set; }

        public AddProductModel(InventoryService inventoryService)
        {
            if (inventoryService == null)
                throw new ArgumentNullException("InventoryService null");

            _inventoryService = inventoryService;
        }


        // Clear the input on submission.
        public IActionResult OnPost() //For return (to navigate).
        {
            //TODO Possibly remove!
            //not needed - using input control here.
            //if(Product.Quantity < 0)
            //{
            //    Message = "Cannot enter a less than zero quantity!";
            //    return Page();
            //}

            _inventoryService.AddProduct(Product);
            Message = "Product added successfully!";

            // Redirect to itself to force a fresh page load
            // to clear the fields
            return RedirectToPage("/Products/AddProduct");
        }
    }


}
