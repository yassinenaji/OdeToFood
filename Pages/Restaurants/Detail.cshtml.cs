using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        [BindProperty(SupportsGet = true)]
        public int RestaurantId { get; set; }
        public void OnGet()
        {
            Restaurant=new Restaurant();
            Restaurant.Id = RestaurantId;
        }
    }
}
