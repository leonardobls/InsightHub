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
    public IActionResult List()
    {
        return View();
    }

    [Route("/gerenciador/projetos/edit/{id}")]
    public async Task<IActionResult> Edit([FromServices] AppDbContext context)
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

        return View();
    }

    [Route("/gerenciador/projetos/insert")]
    public async Task<IActionResult> Insert([FromServices] AppDbContext context)
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

        return View();
    }

    [HttpPost]
    [Route("/gerenciador/projetos/add-form")]
    public IActionResult Add([FromServices] AppDbContext context,
                [FromForm] Projeto model)
    {

        context.Projeto.Add(model);
        context.SaveChanges();

        //return Ok();
        return Redirect("/gerenciador/projetos");
    }
}
