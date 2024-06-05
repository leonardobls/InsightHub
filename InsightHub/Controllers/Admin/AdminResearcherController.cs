using System.Diagnostics;
using InsightHub.Data;
using InsightHub.Models;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult Edit()
    {
        return View();
    }

    [Route("/gerenciador/pesquisadores/insert")]
    public IActionResult Insert()
    {
        return View();
    }

    [HttpPost]
    [Route("/gerenciador/add-form")]
    public IActionResult Add([FromServices] AppDbContext context,
                [FromForm] Pesquisador model)
    {

        context.Pesquisador.Add(model);
        context.SaveChanges();

        return Ok();
    }
}
