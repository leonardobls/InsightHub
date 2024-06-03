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

    [Route("/gerenciador/pesquisadores/{id}")]
    public IActionResult Edit()
    {
        return View();
    }
}
