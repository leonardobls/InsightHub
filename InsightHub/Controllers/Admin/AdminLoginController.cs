using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InsightHub.Controllers;

[Route("/gerenciador/login")]
public class LoginController : Controller
{
    [Route("/gerenciador/login")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("/gerenciador/check")]
    public IActionResult Check(string username, string password)
    {
        if(username == "admin" && password == "admin")
            return Redirect("/gerenciador");
        else
        {
            TempData["ErrorMessage"] = "Username or password is incorrect.";
            return Redirect("/gerenciador/login");
        }
    }
}
