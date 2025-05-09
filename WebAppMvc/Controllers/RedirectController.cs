using Microsoft.AspNetCore.Mvc;

namespace WebAppMvc.Controllers;

public class RedirectController : Controller
{
    public IActionResult Index()
    {
        //return Redirect("https://duckduckgo.com");
        //return new RedirectResult("https://duckduckgo.com");
        //return new RedirectToActionResult("Index", "Home",null);
        //return RedirectToAction("Index", "Home");
        return LocalRedirect("/Home/Index");
    }
}
