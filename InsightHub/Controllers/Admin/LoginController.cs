using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InsightHub.Controllers;

public class LoginController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Home()
    {
        return View();
    }

}
