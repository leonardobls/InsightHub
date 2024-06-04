using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InsightHub.Controllers;

[Route("/pesquisador")]
public class ResearcherController : Controller
{

    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("{slug}")]
    public IActionResult Detail(String slug)
    {
        ViewBag.TituloDetalhe = slug;
        return View();
    }
}
