using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants;

public class ListModel : PageModel
{
    
    

    public string Message { get; private set; } = "Restaurant List";
    public string MessageConfig { get; private set; }
    private readonly IConfiguration config;
    private readonly IRestaurantData restaurantData;
    public IEnumerable<Restaurant> Restaurants { get; set;}
    [BindProperty(SupportsGet =true)]
    public string SearchTerm { get; set; }  
    [ActivatorUtilitiesConstructor]
    public ListModel(IConfiguration config, IRestaurantData restaurantData)
    {

        this.restaurantData = restaurantData;  
        this.config=config;


    }
    
    public void OnGet()
    {

        Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
         Message += $" Server time is { DateTime.Now }";
        //access to appsettings file
         MessageConfig=config["Message"];
    }
}

