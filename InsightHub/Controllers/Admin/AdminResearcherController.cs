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
    public async Task<IActionResult> List([FromServices] AppDbContext context, [FromQuery] int? page)
    {
        int pageSize = 10;
        int currentPage = page ?? 1;

        var pesquisadores = await context.Pesquisador.Include(p => (p as Pesquisador).Subarea)
            .OrderBy(x => x.Id)
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        int totalItems = await context.Pesquisador.CountAsync();
        int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        ViewBag.CurrentPage = currentPage;
        ViewBag.TotalPages = totalPages;
        ViewBag.Pesquisadores = pesquisadores;

        return View();
    }

    [Route("/gerenciador/pesquisadores/edit/{id}")]
    public async Task<IActionResult> Edit([FromServices] AppDbContext context, int Id)
    {
        ViewBag.Subareas = await context.SubareaConhecimento.OrderBy(x => x.Nome).ToListAsync();
        ViewBag.Pesquisador = await context.Pesquisador
             .Include(p => p.Subarea)
             .FirstOrDefaultAsync(p => p.Id == Id);

        return View();
    }

    [Route("/gerenciador/pesquisadores/edit-form/{Id}")]
    public async Task<IActionResult> Update([FromServices] AppDbContext context, [FromForm] Pesquisador model, int? Id)
    {
        if (Id != null)
        {
            var subarea = context.SubareaConhecimento.First(x => x.Id == model.SubareaId);
            var pesquisador = context.Pesquisador.First(a => a.Id == Id);
            pesquisador.Nome = model.Nome;
            pesquisador.Email = model.Email;
            pesquisador.SubareaId = model.SubareaId;
            pesquisador.Subarea = subarea;
        }
        else
        {
            context.Pesquisador.Add(model);
        }

        await context.SaveChangesAsync();

        return Redirect("/gerenciador/pesquisadores");
    }


    [HttpPost]
    [Route("/gerenciador/pesquisadores/add-form")]
    public async Task<IActionResult> Add([FromServices] AppDbContext context,
                [FromForm] Pesquisador model)
    {
        // Encontra a Subarea associada
        var subarea = await context.SubareaConhecimento.FindAsync(model.SubareaId);

        if (subarea == null)
        {
            return NotFound("Subarea não encontrada");
        }

        model.Subarea = subarea;

        context.Pesquisador.Add(model);
        context.SaveChanges();

        //return Ok();
        return Redirect("/gerenciador/pesquisadores");
    }

    [HttpPost]
    [Route("/gerenciador/pesquisadores/delete")]
    public IActionResult Delete([FromServices] AppDbContext context, [FromForm] int id)
    {
        // Recuperar a instância existente no banco de dados
        var pesquisador = context.Pesquisador.FirstOrDefault(c => c.Id == id);

        if (pesquisador == null)
            return NotFound();

        context.Pesquisador.Remove(pesquisador);
        context.SaveChanges();

        return Ok();
    }
}
