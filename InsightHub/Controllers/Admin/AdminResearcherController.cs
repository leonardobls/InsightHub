using System.Diagnostics;
using InsightHub.Data;
using InsightHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsightHub.Controllers;

[Route("/gerenciador/pesquisadores")]
public class AdminResearcherController : Controller
{
    [Route("/gerenciador/pesquisadores")]
    public IActionResult List()
    {
        return View();
    }

    [Route("/gerenciador/pesquisadores/edit/{id}")]
    public async Task<IActionResult> Edit([FromServices] AppDbContext context)
    {
        var subareas = await context.SubareaConhecimento.Select(a => new SubareaConhecimento
            {
                Id = a.Id,
                Nome = a.Nome,
                Numero = a.Numero
            }).ToListAsync();
        return View(subareas);
    }

    [Route("/gerenciador/pesquisadores/insert")]
    public async Task<IActionResult> Insert([FromServices] AppDbContext context)
    {
        var subareas = await context.SubareaConhecimento.Select(a => new SubareaConhecimento
            {
                Id = a.Id,
                Nome = a.Nome,
                Numero = a.Numero
            }).ToListAsync();
        return View(subareas);
    }

    [HttpPost]
    [Route("/gerenciador/pesquisadores/add-form")]
    public IActionResult Add([FromServices] AppDbContext context,
                [FromForm] Pesquisador model)
    {

        context.Pesquisador.Add(model);
        context.SaveChanges();

        //return Ok();
        return Redirect("/gerenciador/pesquisadores");
    }    
}
