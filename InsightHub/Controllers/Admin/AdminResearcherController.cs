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
        int pageSize = 10; // Número de itens por página
        int currentPage = page ?? 1; // Página atual, padrão é 1 se não for fornecido

        var pesquisadores = await context.Pesquisador.Include(p => (p as Pesquisador).Subarea)
            .OrderBy(x => x.Id)
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        int totalItems = await context.Projeto.CountAsync();
        int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        ViewBag.CurrentPage = currentPage;
        ViewBag.TotalPages = totalPages;
        ViewBag.Pesquisadores = pesquisadores;

        return View();
    }
    // public async Task<IActionResult> List([FromServices] AppDbContext context)
    // {
    //     var pesquisadores = await context.Pesquisador.Include(p => (p as Pesquisador).Subarea).OrderBy(p => p.Nome).ToListAsync();

    //     ViewBag.Pesquisadores = pesquisadores;
    //     return View();
    // }

    [Route("/gerenciador/pesquisadores/edit/{id}")]
    public async Task<IActionResult> Edit([FromServices] AppDbContext context, int Id)
    {
        var subareas = await context.SubareaConhecimento.Select(a => new SubareaConhecimento
            {
                Id = a.Id,
                Nome = a.Nome,
                Numero = a.Numero
            }).ToListAsync();

        ViewBag.Subareas = subareas;

        Pesquisador pesquisador = null;

        if (Id != 0)
        {
            pesquisador = await context.Pesquisador
            .Include(p => (p as Pesquisador).Subarea) // Acesso direto à propriedade de navegação
            .FirstOrDefaultAsync(p => p.Id == Id);
        }

        ViewBag.Pesquisador = pesquisador;

        return View();
    }

    [Route("/gerenciador/pesquisadores/edit-form/{Id}")]
    public async Task<IActionResult> Update([FromServices] AppDbContext context, [FromForm] Pesquisador model, int Id)
    {
        model.Id = Id;
        var pesquisador = context.Pesquisador.FirstOrDefault(a => a.Id == Id);
        //projeto = model;

        if (pesquisador == null)
        {
            // Se a instância não for encontrada, retornar um erro ou redirecionar
            return NotFound();
        }

        // Atualizar os valores dos campos
        pesquisador.Nome = model.Nome;
        pesquisador.Email = model.Email;
        pesquisador.SubareaKey = model.SubareaKey;

        var subarea = await context.SubareaConhecimento.FindAsync(model.SubareaKey);

        if (subarea == null)
        {
            return NotFound("Subarea não encontrada");
        }

        pesquisador.Subarea = subarea;


        //context.Projeto.Update(projeto);
        context.SaveChanges();

        return Redirect("/gerenciador/pesquisadores");
    }


    [HttpPost]
    [Route("/gerenciador/pesquisadores/add-form")]
    public async Task<IActionResult> Add([FromServices] AppDbContext context,
                [FromForm] Pesquisador model)
    {
        // Encontra a Subarea associada
        var subarea = await context.SubareaConhecimento.FindAsync(model.SubareaKey);

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
