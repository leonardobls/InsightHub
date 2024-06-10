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
    public IActionResult List()
    {
        return View();
    }

    [Route("/gerenciador/captacoes/edit/{id}")]
    public IActionResult Edit()
    {
        return View();
    }

    [Route("/gerenciador/captacoes/insert")]
    public async Task<IActionResult> Insert([FromServices] AppDbContext context)
    {
        var projetos = await context.Projeto.Select(a => new Projeto
            {
                Id = a.Id,
                Nome = a.Nome,
            }).ToListAsync();
        return View(projetos);
    }

    [HttpPost]
    [Route("/gerenciador/captacoes/add-form")]
    public IActionResult Add([FromServices] AppDbContext context,
                [FromForm] Captacao model)
    {

        context.Captacao.Add(model);
        context.SaveChanges();

        //return Ok();
        return Redirect("/gerenciador/captacoes");
    } 
}
