using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InsightHub.Models;
using InsightHub.Data;
using Microsoft.EntityFrameworkCore;

namespace InsightHub.Controllers;

[Route("/gerenciador/captacoes")]
public class AdminCaptacoesController : Controller
{
    [Route("/gerenciador/captacoes")]
    public async Task<IActionResult> List([FromServices] AppDbContext context, [FromQuery] int? page)
    {
        int pageSize = 10; // Número de itens por página
        int currentPage = page ?? 1; // Página atual, padrão é 1 se não for fornecido

        var captacoes = await context.Captacao.Select(c => new Captacao
        {
            Id = c.Id,
            Valor = c.Valor,
            Data = c.Data,
            Descricao = c.Descricao,
            Fornecedor = c.Fornecedor,
            Proj = (c.Proj as Projeto)
        })
            .OrderBy(x => x.Id)
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        int totalItems = await context.Captacao.CountAsync();
        int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        ViewBag.CurrentPage = currentPage;
        ViewBag.TotalPages = totalPages;
        ViewBag.Captacoes = captacoes;

        return View();
    }

    [Route("/gerenciador/captacoes/edit/{Id?}")]
    public async Task<IActionResult> Edit([FromServices] AppDbContext context, int Id)
    {
        var projetos = await context.Projeto.ToListAsync();
        ViewBag.Projetos = projetos;

        Captacao captacao = null;

        if (Id != 0)
        {
            captacao = await context.Captacao
            .Include(p => (p as Captacao).Proj) // Acesso direto à propriedade de navegação
            .FirstOrDefaultAsync(p => p.Id == Id);
        }

        ViewBag.Captacao = captacao;

        return View();
    }

    [Route("/gerenciador/captacoes/edit-form/{Id?}")]
    public async Task<IActionResult> Insert([FromServices] AppDbContext context, [FromForm] Captacao model, int? Id)
    {

        var projeto = await context.Projeto.FindAsync(model.ProjetoId);

        if (Id != null)
        {
            var captacao = await context.Captacao.FindAsync(Id);

            if (captacao != null)
            {
                captacao.Valor = model.Valor;
                captacao.Data = model.Data;
                captacao.Descricao = model.Descricao;
                captacao.Fornecedor = model.Fornecedor;
                captacao.ProjetoId = model.ProjetoId;
                captacao.Proj = projeto;

                context.Captacao.Update(captacao);
            }
        }
        else
        {
            context.Captacao.Add(model);
        }

        _ = await context.SaveChangesAsync();
        return Redirect("/gerenciador/captacoes");
    }

    // [HttpPost]
    // [Route("/gerenciador/captacoes/add-form")]
    // public async Task<IActionResult> Add([FromServices] AppDbContext context,
    //             [FromForm] Captacao model)
    // {
    //     var projeto = await context.Projeto.FindAsync(model.ProjetoId);

    //     if (projeto == null)
    //     {
    //         return NotFound("Subarea não encontrada");
    //     }

    //     model.Proj = projeto;

    //     context.Captacao.Add(model);
    //     context.SaveChanges();

    //     //return Ok();
    //     return Redirect("/gerenciador/captacoes");
    // }

    [HttpPost]
    [Route("/gerenciador/captacoes/delete")]
    public IActionResult Delete([FromServices] AppDbContext context, [FromForm] int id)
    {
        // Recuperar a instância existente no banco de dados
        var captacao = context.Captacao.FirstOrDefault(c => c.Id == id);

        if (captacao == null)
            return NotFound();

        context.Captacao.Remove(captacao);
        context.SaveChanges();

        return Ok();
    }
}
