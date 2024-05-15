using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InsightHub.Controllers;

public class LoginController : Controller
{
    // private readonly ILogger<LoginController> _logger;

    public LoginController()
    {
        // _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Home()
    {
        return View();
    }

}
