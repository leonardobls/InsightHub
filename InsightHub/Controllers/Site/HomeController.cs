using System.Diagnostics;
using InsightHub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsightHub.Controllers;

[Route("/")]
public class HomeController : Controller
{
    public async Task<IActionResult> Index([FromServices] AppDbContext context)
    {
        ViewBag.Subareas = await context.SubareaConhecimento.ToListAsync();
        return View();
    }
}
