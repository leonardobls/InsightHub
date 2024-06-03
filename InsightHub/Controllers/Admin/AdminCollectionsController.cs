using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InsightHub.Controllers;

[Route("/gerenciador/arrecadacoes")]
public class AdminCollectionsController : Controller
{
    [Route("/gerenciador/arrecadacoes")]
    public IActionResult List()
    {
        return View();
    }

    [Route("/gerenciador/arrecadacoes/edit")]
    public IActionResult Edit()
    {
        return View();
    }
}
