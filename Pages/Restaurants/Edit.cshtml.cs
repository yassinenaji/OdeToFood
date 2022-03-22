using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;
using static OdeToFood.Core.Restaurant;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {

        public Restaurant Restaurant { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public int RestaurantId { get; set; }
        [BindProperty(SupportsGet = true)]
        public CuisineType CuisineType { get; set; }
        private readonly IRestaurantData restaurantData;
        public EditModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(/*int restaurantId*/)
        {
            Restaurant = new Restaurant();
            Restaurant = restaurantData.GetById(RestaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
