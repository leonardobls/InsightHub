using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InsightHub.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
