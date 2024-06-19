using InsightHub.Data;
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

        var projectList = await context.Projeto.Where(x => x.Nome!.Contains(search.FastSearch!)).ToListAsync();

        return View();
    }
}
