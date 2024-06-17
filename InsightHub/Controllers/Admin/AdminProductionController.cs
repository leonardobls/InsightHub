using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InsightHub.Models;
using InsightHub.Data;
using Microsoft.EntityFrameworkCore;

namespace InsightHub.Controllers;

[Route("/gerenciador/projetos")]
public class AdminProductionController : Controller
{
    [Route("/gerenciador/projetos")]
    public async Task<IActionResult> List([FromServices] AppDbContext context)
    {

        var projetos = await context.Projeto.ToListAsync();

        ViewBag.Projetos = projetos;
        return View();
    }

    [Route("/gerenciador/projetos/edit/{Id?}")]
    public async Task<IActionResult> Edit([FromServices] AppDbContext context, int Id)
    {
        var areas = await context.AreaConhecimento.Select(a => new AreaConhecimento
        {
            Id = a.Id,
            Nome = a.Nome,
            Numero = a.Numero
        }).ToListAsync();
        var subareas = await context.SubareaConhecimento.Select(a => new SubareaConhecimento
        {
            Id = a.Id,
            Nome = a.Nome,
            Numero = a.Numero
        }).ToListAsync();


        ViewBag.Areas = areas;
        ViewBag.Subareas = subareas;

        Projeto projeto = null;

        if (Id != 0)
        {
            Projeto teste = await context.Projeto
       .Include(p => (p as Projeto).QualquerCoisa) // Acesso direto à propriedade de navegação
       .FirstOrDefaultAsync(p => p.Id == Id);
        }

        ViewBag.Projeto = projeto;

        return View();
    }

    [Route("/gerenciador/projetos/edit-form/{Id}")]
    public async Task<IActionResult> Insert([FromServices] AppDbContext context, [FromForm] Projeto model, int Id)
    {

        var projeto = await context.Projeto.Where(a => a.Id == Id).FirstAsync();
        projeto = model;

        context.Projeto.Update(projeto);
        context.SaveChanges();

        return Redirect("/gerenciador/projetos");
    }

    [HttpPost]
    [Route("/gerenciador/projetos/add-form")]
    public IActionResult Add([FromServices] AppDbContext context,
                [FromForm] Projeto model)
    {

        context.Projeto.Add(model);
        context.SaveChanges();

        return Redirect("/gerenciador/projetos");
    }
}
