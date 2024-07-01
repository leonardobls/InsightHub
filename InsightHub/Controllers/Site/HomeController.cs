using System.Diagnostics;
using InsightHub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsightHub.Controllers;

[Route("/")]
public class HomeController : Controller
{
    public async Task<IActionResult> Index([FromServices] AppDbContext context)
    {
        ViewBag.Areas = await context.AreaConhecimento.ToListAsync();
        ViewBag.Subareas = await context.SubareaConhecimento.ToListAsync();

        ViewBag.Recentes = await context.Projeto.Include(x => x.Subarea).ThenInclude(s => s!.AreaConhecimento).OrderByDescending(x => x.DataInicio).Take(5).ToListAsync();

        return View();
    }
}
