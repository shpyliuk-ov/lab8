// Гуменюк Макс КІ2-21-4

using Microsoft.AspNetCore.Mvc;
// HomeController.cs
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Message"] = "Hello from HTML Helper!";
        return View();
    }
}

public class GreetingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var model = "Привіт з View Component!";
        return View("Default", model);
    }
}