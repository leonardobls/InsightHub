using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InsightHub.Controllers;

[Route("/gerenciador/pesquisadores")]
public class AdminResearcherController : Controller
{
    [Route("/gerenciador/pesquisadores")]
    public IActionResult List()
    {
        return View();
    }

    [Route("/gerenciador/pesquisadores/edit/{id}")]
    public IActionResult Edit()
    {
        return View();
    }

    [Route("/gerenciador/pesquisadores/insert")]
    public IActionResult Insert()
    {
        return View();
    }
}