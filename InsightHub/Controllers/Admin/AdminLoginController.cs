using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InsightHub.Controllers;

[Route("/gerenciador/login")]
public class LoginController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
