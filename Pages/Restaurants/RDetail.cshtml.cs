using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class RDetailModel : PageModel
    {
        
        public Restaurant Restaurant { get; set; }
        [BindProperty(SupportsGet = true)]
        public int RestaurantId { get; set; }
        private readonly IRestaurantData restaurantData;
        public RDetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(/*int RestaurantId*/)
        {
            Restaurant = new Restaurant();
            Restaurant = restaurantData.GetById(RestaurantId);
            if(Restaurant== null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        
    }
}
