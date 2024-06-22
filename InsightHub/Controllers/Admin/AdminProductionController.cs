using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InsightHub.Models;
using InsightHub.Data;
using Microsoft.EntityFrameworkCore;

namespace InsightHub.Controllers;

[Route("/gerenciador/producoes")]
public class AdminProductionController : Controller
{
    [Route("/gerenciador/producoes")]
    public async Task<IActionResult> List([FromServices] AppDbContext context, [FromQuery] int? page)
    {
        int pageSize = 10; // Número de itens por página
        int currentPage = page ?? 1; // Página atual, padrão é 1 se não for fornecido

        var producoes = await context.Producao.Select(c => new Producao{
            Id = c.Id,
            Titulo = c.Titulo,
            Description = c.Description,
            FilePath = c.FilePath,
            Projeto = (c.Projeto as Projeto)
        })
            .OrderBy(x => x.Id)
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        int totalItems = await context.Producao.CountAsync();
        int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        ViewBag.CurrentPage = currentPage;
        ViewBag.TotalPages = totalPages;
        ViewBag.Producoes = producoes;

        return View();
    }

    [Route("/gerenciador/producoes/edit/{Id?}")]
    public async Task<IActionResult> Edit([FromServices] AppDbContext context, int? Id)
    {
        ViewBag.Projetos = await context.Projeto.ToListAsync();

        ViewBag.Producao = null;

        if (Id != 0)
        {
            ViewBag.Producao = await context.Producao
            .Include(p => p.Projeto)
            .FirstOrDefaultAsync(p => p.Id == Id);
        }

        return View();
    }


    [Route("/gerenciador/producoes/edit-form/{Id?}")]
    public async Task<IActionResult> Insert([FromServices] AppDbContext context, [FromForm] Producao model, int? Id)
    {
        var projeto = await context.Projeto.FindAsync(model.ProjetoKey);

        if (projeto == null)
        {
            return NotFound("Subarea não encontrada");
        }
        model.Projeto = projeto;
        
        if (Id != null)
        {

            var producao = await context.Producao.FindAsync(Id);

            if (producao != null)
            {
                producao.Titulo = model.Titulo;
                producao.Description = model.Description;
                producao.FilePath = model.FilePath;
                producao.ProjetoKey = model.ProjetoKey;
                producao.Projeto = model.Projeto;

                context.Producao.Update(producao);
            }
        }
        else
        {
            context.Producao.Add(model);
        }

        _ = await context.SaveChangesAsync();
        return Redirect("/gerenciador/producoes");
    }

    [Route("/gerenciador/producoes/delete-form/{Id}")]
    public IActionResult Delete([FromServices] AppDbContext context, int? id)
    {
        // Recuperar a instância existente no banco de dados
        var producao = context.Producao.FirstOrDefault(c => c.Id == id);

        if (producao == null)
            return NotFound();

        context.Producao.Remove(producao);
        context.SaveChanges();

        return Redirect("/gerenciador/producoes");
    }
}
