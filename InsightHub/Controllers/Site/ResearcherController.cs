using System.Diagnostics;
using InsightHub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsightHub.Controllers;

[Route("/pesquisador")]
public class ResearcherController : Controller
{

    [Route("/pesquisador/{Id}")]
    public async Task<IActionResult> Detail([FromServices] AppDbContext context, int? Id)
    {

        ViewBag.Pesquisador = await context.Pesquisador.Where(x => x.Id == Id).FirstAsync();
        ViewBag.Projetos = await context.ProjetoPesquisadorPivot.Include(x => x.Projeto).Where(x => x.PesquisadorId == Id).ToListAsync();
        return View();
    }
}
