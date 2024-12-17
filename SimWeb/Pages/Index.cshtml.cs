using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace SimWeb.Pages;

public class IndexModel : PageModel
{
    public required Simulator.SimulationHistory History { get; set; }
    public void OnGet()
    {
        History = App._historia;
    }

}