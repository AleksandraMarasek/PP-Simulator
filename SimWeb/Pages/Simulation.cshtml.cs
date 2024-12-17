using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimWeb.Pages;

public class SimulationModel : PageModel
{
    public int Counter { get; private set; }

    public required Simulator.SimulationHistory History { get; set; }
    public void OnGet()
    {
        Counter = HttpContext.Session.GetInt32("Counter") ?? 0;

        if (App._historia != null) { History = App._historia; }
        else { throw new Exception("SimHistory doesn't exist."); }
    }

    public void OnPostPrevious()
    {
        Counter = HttpContext.Session.GetInt32("Counter") ?? 0;
        History = App._historia;

        if (Counter > 0) { Counter--; }
        HttpContext.Session.SetInt32("Counter", Counter);

    }
    public void OnPostNext()
    {
        Counter = HttpContext.Session.GetInt32("Counter") ?? 0;
        History = App._historia;

        if (Counter < History.TurnLogs.Count - 1) { Counter++; }
        HttpContext.Session.SetInt32("Counter", Counter);
    }


}