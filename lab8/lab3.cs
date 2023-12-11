// Гуменюк Макс КІ2-21-4

using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

public class SessionController : Controller
{
    public IActionResult SetSession()
    {
        HttpContext.Session.SetString("MySessionKey", "Hello from session!");
        return RedirectToAction("ReadSession");
    }

    public IActionResult ReadSession()
    {
        string sessionValue = HttpContext.Session.GetString("MySessionKey");
        ViewData["SessionValue"] = sessionValue;
        return View();
    }
}

public class CookieController : Controller
{
    public IActionResult SetCookie()
    {
        Response.Cookies.Append("MyCookie", "Hello from cookie!");
        return RedirectToAction("ReadCookie");
    }

    public IActionResult ReadCookie()
    {
        string cookieValue = Request.Cookies["MyCookie"];
        ViewData["CookieValue"] = cookieValue;
        return View();
    }
}