using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InsightHub.Models;
using InsightHub.Data;
using Microsoft.EntityFrameworkCore;

namespace InsightHub.Controllers;

[Route("/gerenciador/areas")]
public class AdminAreasController : Controller
{
    [Route("/gerenciador/areas")]
    public async Task<IActionResult> List([FromServices] AppDbContext context, [FromQuery] int? page)
    {
        int pageSize = 10; // Número de itens por página
        int currentPage = page ?? 1; // Página atual, padrão é 1 se não for fornecido

        var areas = await context.AreaConhecimento.Select(c => new AreaConhecimento
        {
            Id = c.Id,
            Nome = c.Nome,
            Numero = c.Numero,
        })
            .OrderBy(x => x.Nome)
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        int totalItems = await context.AreaConhecimento.CountAsync();
        int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        ViewBag.CurrentPage = currentPage;
        ViewBag.TotalPages = totalPages;
        ViewBag.Areas = areas;

        return View();
    }

    [Route("/gerenciador/areas/edit/{Id?}")]
    public async Task<IActionResult> Edit([FromServices] AppDbContext context, int? Id)
    {
        ViewBag.Areas = null;

        if (Id != 0)
        {
            ViewBag.Areas = await context.AreaConhecimento
            .FirstOrDefaultAsync(p => p.Id == Id);
        }

        return View();
    }


    [Route("/gerenciador/areas/edit-form/{Id?}")]
    public async Task<IActionResult> Insert([FromServices] AppDbContext context, [FromForm] AreaConhecimento model, int? Id)
    {
        if (Id != null)
        {

            var area = await context.AreaConhecimento.FindAsync(Id);

            if (area != null)
            {
                area.Nome = model.Nome;
                area.Numero = model.Numero;

                context.AreaConhecimento.Update(area);
            }
        }
        else
        {
            context.AreaConhecimento.Add(model);
        }

        _ = await context.SaveChangesAsync();
        return Redirect("/gerenciador/areas");
    }

    [Route("/gerenciador/areas/delete-form/{Id}")]
    public IActionResult Delete([FromServices] AppDbContext context, int? id)
    {
        // Recuperar a instância existente no banco de dados
        var area = context.AreaConhecimento.FirstOrDefault(c => c.Id == id);

        if (area == null)
            return NotFound();

        context.AreaConhecimento.Remove(area);
        context.SaveChanges();

        return Redirect("/gerenciador/areas");
    }
}
