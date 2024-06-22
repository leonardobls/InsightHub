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
        ViewBag.FastSearch = search.FastSearch;
        ViewBag.Area = search.Area;
        ViewBag.Goal = search.Goal;

        var areas = await context.SubareaConhecimento.Where(x => x.Nome!.Contains(search.FastSearch!))
        .ToListAsync();

        var projectList = await context.Projeto.Where(x => x.Nome!.Contains(search.FastSearch!))
        .Include(p => (p as Projeto).Subarea)
        .ToListAsync();

        var pesquisadorList = await context.Pesquisador.Where(x => x.Nome!.Contains(search.FastSearch!))
        .Include(p => (p as Pesquisador).Subarea)
        .ToListAsync();

        if (search.Goal != null){
            if (search.Goal == "Pesquisador")
                projectList = null;
            else if (search.Goal == "Projeto")
                pesquisadorList = null;
        }

        if (search.Area != null){

            projectList = projectList != null ? projectList.Where(x => x.SubareaId == int.Parse(search.Area)).ToList() : null;
            

            pesquisadorList = pesquisadorList != null ? pesquisadorList.Where(x => x.SubareaKey == int.Parse(search.Area)).ToList() : null;
        }

        ViewBag.Projetos = projectList;
        ViewBag.Pesquisadores = pesquisadorList;
        ViewBag.Subareas = areas;

        return View();
    }
}
