using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InsightHub.Controllers;

[Route("/gerenciador/producoes")]
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
    public IActionResult Insert()
    {
        return View();
    }
}
