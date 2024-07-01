using InsightHub.Data;
using InsightHub.Models;
using InsightHub.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsightHub.Controllers;

[Route("/busca")]
public class SearchController : Controller
{

    [Route("/busca")]
    public async Task<IActionResult> List([FromServices] AppDbContext context, [FromForm] FastSearchDTO search)
    {
        ViewBag.Subareas = await context.SubareaConhecimento.ToListAsync();
        ViewBag.Areas = await context.AreaConhecimento.ToListAsync();
        ViewBag.Search = search;

        var projetosResultado = context.Set<Projeto>().AsQueryable();
        var pesquisadoresResultado = context.Set<Pesquisador>().AsQueryable();

        if (search!.FastSearch != null)
        {
            projetosResultado = projetosResultado.Where(x => x.Nome != null && x.Nome.Trim().ToLower().Contains(search.FastSearch.Trim().ToLower()));
            pesquisadoresResultado = pesquisadoresResultado.Where(x => x.Nome != null && x.Nome.Trim().ToLower().Contains(search.FastSearch.Trim().ToLower()));
        }

        if (search.AreaId != null)
        {
            projetosResultado = projetosResultado.Where(x => x.Subarea != null && x.Subarea.AreaId == search.AreaId);
            pesquisadoresResultado = pesquisadoresResultado.Where(x => x.Subarea != null && x.Subarea.AreaId == search.AreaId);
        }

        if (search.SubareaId != null)
        {
            projetosResultado = projetosResultado.Where(x => x.SubareaId == search.SubareaId);
            pesquisadoresResultado = pesquisadoresResultado.Where(x => x.SubareaId == search.SubareaId);
        }

        if (search.Goal != null && search.Goal == "projeto")
        {
            pesquisadoresResultado = context.Set<Pesquisador>().Where(x => false);
        }

        if (search.Goal != null && search.Goal == "pesquisador")
        {
            projetosResultado = context.Set<Projeto>().Where(x => false);
        }

        if (search.Order != null && search.Order == "recente")
        {
            projetosResultado = projetosResultado.OrderByDescending(x => x.DataInicio);
            pesquisadoresResultado = pesquisadoresResultado.OrderByDescending(x => x.Id);
        }

        if (search.Order != null && search.Order == "alfabetica")
        {
            projetosResultado = projetosResultado.OrderBy(x => x.Nome);
            pesquisadoresResultado = pesquisadoresResultado.OrderBy(x => x.Nome);
        }

        if (search.Order != null && search.Order == "antiga")
        {
            projetosResultado = projetosResultado.OrderBy(x => x.DataInicio);
            pesquisadoresResultado = pesquisadoresResultado.OrderBy(x => x.Id);
        }

        projetosResultado = projetosResultado.Include(x => x.Subarea).ThenInclude(s => s.AreaConhecimento);
        pesquisadoresResultado = pesquisadoresResultado.Include(x => x.Subarea).ThenInclude(s => s.AreaConhecimento);

        projetosResultado = projetosResultado.AsNoTracking();
        pesquisadoresResultado = pesquisadoresResultado.AsNoTracking();

        ViewBag.Projetos = await projetosResultado.ToListAsync();
        ViewBag.Pesquisadores = await pesquisadoresResultado.ToListAsync();

        return View();
    }
}
