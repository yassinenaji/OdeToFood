using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using static OdeToFood.Core.Restaurant;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        [BindProperty(SupportsGet =true)]
        public int RestaurantId { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }   
      
        [TempData]
        public string Message { get; set; }

        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        public EditModel(IRestaurantData restaurantData,IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;   
        }
        public IActionResult OnGet(/*int restaurantId*/)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (RestaurantId != null)
            {
                Restaurant = restaurantData.GetById(RestaurantId);

            }
            else
            {
                Restaurant = new Restaurant();
          
            }
            /*if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }*/
            return Page();
        }
        public IActionResult Onpost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
                

            }
            if (Restaurant.Id > 0)
            {
                restaurantData.Update(Restaurant);
                TempData["Message"] = "Update Action";

            }
            else
            {
                restaurantData.Add(Restaurant);
                TempData["Message"] = "Create Action";


            }
            restaurantData.commit();
            return RedirectToPage("./RDetail", new { RestaurantId = Restaurant.Id});
        }
    }
}
