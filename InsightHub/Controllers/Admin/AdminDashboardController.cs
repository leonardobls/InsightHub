using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InsightHub.Controllers;

[Route("/gerenciador")]
public class AdminDashboardController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
