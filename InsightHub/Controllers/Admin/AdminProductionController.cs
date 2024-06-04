using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InsightHub.Controllers;

[Route("/gerenciador/producoes")]
public class AdminProductionController : Controller
{
    [Route("/gerenciador/producoes")]
    public IActionResult List()
    {
        return View();
    }

    [Route("/gerenciador/producoes/edit/{id}")]
    public IActionResult Edit()
    {
        return View();
    }

    [Route("/gerenciador/producoes/insert")]
    public IActionResult Insert()
    {
        return View();
    }
}
