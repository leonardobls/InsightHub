using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InsightHub.Controllers;

[Route("/producoes")]
public class ProductionController : Controller
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

    [Route("favoritos")]
    public IActionResult Favorites()
    {
        return View();
    }
}
