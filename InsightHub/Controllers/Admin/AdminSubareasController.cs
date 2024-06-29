using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InsightHub.Models;
using InsightHub.Data;
using Microsoft.EntityFrameworkCore;

namespace InsightHub.Controllers;

[Route("/gerenciador/subareas")]
public class AdminSubareasController : Controller
{
    [Route("/gerenciador/subareas")]
    public async Task<IActionResult> List([FromServices] AppDbContext context, [FromQuery] int? page)
    {
        int pageSize = 10; // Número de itens por página
        int currentPage = page ?? 1; // Página atual, padrão é 1 se não for fornecido

        var subareas = await context.SubareaConhecimento.Include(x => x.AreaConhecimento).OrderBy(x => x.Nome)
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        int totalItems = await context.SubareaConhecimento.CountAsync();
        int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        ViewBag.CurrentPage = currentPage;
        ViewBag.TotalPages = totalPages;
        ViewBag.Subareas = subareas;

        return View();
    }

    [Route("/gerenciador/subareas/edit/{Id?}")]
    public async Task<IActionResult> Edit([FromServices] AppDbContext context, int? Id)
    {
        ViewBag.Areas = await context.AreaConhecimento.OrderBy(x => x.Nome).ToListAsync();
        ViewBag.Subarea = null;

        if (Id != 0)
        {
            ViewBag.Subarea = await context.SubareaConhecimento
            .FirstOrDefaultAsync(p => p.Id == Id);
        }

        return View();
    }


    [Route("/gerenciador/subareas/edit-form/{Id?}")]
    public async Task<IActionResult> Insert([FromServices] AppDbContext context, [FromForm] SubareaConhecimento model, int? Id)
    {
        var area = await context.AreaConhecimento.FindAsync(model.AreaKey);

        if (Id != null)
        {
            var subarea = await context.SubareaConhecimento.FindAsync(Id);
            if (subarea != null)
            {
                subarea.Nome = model.Nome;
                subarea.Numero = model.Numero;
                subarea.AreaKey = model.AreaKey;
                subarea.AreaConhecimento = area;
                context.SubareaConhecimento.Update(subarea);
            }
        }
        else
        {
            model.AreaConhecimento = area;
            context.SubareaConhecimento.Add(model);
        }

        _ = await context.SaveChangesAsync();
        return Redirect("/gerenciador/subareas");
    }

    [Route("/gerenciador/subareas/delete-form/{Id}")]
    public IActionResult Delete([FromServices] AppDbContext context, int? id)
    {
        // Recuperar a instância existente no banco de dados
        var subarea = context.SubareaConhecimento.FirstOrDefault(c => c.Id == id);

        if (subarea == null)
            return NotFound();

        context.SubareaConhecimento.Remove(subarea);
        context.SaveChanges();

        return Redirect("/gerenciador/subareas");
    }
}
