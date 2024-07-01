using System.Diagnostics;
using InsightHub.Data;
using InsightHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsightHub.Controllers;

[Route("/projetos")]
public class ProjectController : Controller
{

    [Route("")]
    public async Task<IActionResult> Index([FromServices] AppDbContext context)
    {
        ViewBag.Subareas = await context.SubareaConhecimento.ToListAsync();
        ViewBag.Areas = await context.AreaConhecimento.ToListAsync();
        ViewBag.Projetos = await context.Projeto.ToListAsync();
        return View();
    }

    [Route("{Id}")]
    public async Task<IActionResult> Detail([FromServices] AppDbContext context, int Id)
    {
        ViewBag.Projeto = await context.Projeto.FindAsync(Id);
        ViewBag.Productions = await context.Producao.Where(x => x.ProjetoId == Id).ToListAsync();

        var pesquisadoresEnvolvidos = await context.ProjetoPesquisadorPivot.Where(x => x.ProjetoId == Id).ToListAsync();
        var pesquisadoresIds = pesquisadoresEnvolvidos.Select(x => x.PesquisadorId).ToList();
        ViewBag.Pesquisadores = await context.Pesquisador.Where(x => pesquisadoresIds.Contains(x.Id)).ToListAsync();
        return View();
    }

    [Route("favoritos")]
    public IActionResult Favorites()
    {
        return View();
    }
}
