using System.Diagnostics;
using InsightHub.Data;
using Microsoft.AspNetCore.Mvc;

namespace InsightHub.Controllers;

[Route("/projetos")]
public class ProjectController : Controller
{

    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("{Id}")]
    public async Task<IActionResult> Detail([FromServices] AppDbContext context, int Id)
    {
        var projeto = await context.Projeto.FindAsync(Id);
        ViewBag.Projeto = projeto;
        return View();
    }

    [Route("favoritos")]
    public IActionResult Favorites()
    {
        return View();
    }
}
