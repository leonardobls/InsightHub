using InsightHub.Controllers;
using InsightHub.Data;
using InsightHub.DataTransferObjects;
using InsightHub.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace InsightHub.Test;

public class Tests
{
    [TestFixture]
    public class InsightHubTestController
    {
        private SearchController _search;
        private AppDbContext _context;
        [SetUp]
        public void Setup()
        {
            _search = new SearchController();
            _context = new AppDbContext();
        }
        [Test]
        public async Task ProcuraPeloTermo()
        {
            // Arrange - Dados reais do banco de dados
            var search = new FastSearchDTO
            {
                FastSearch = "projeto",
            };

            // Act - Chama o método do controlador usando o contexto real
            var result = await _search.List(_context, search) as ViewResult;

            // Assert - Verifica os resultados
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.ViewData["Projetos"], Is.Not.Null);

            // Captura a lista de projetos do ViewData
            var projetos = result.ViewData["Projetos"] as List<Projeto>;

            // Verifica se a quantidade de projetos é igual a 7
            Assert.That(7, Is.EqualTo(projetos!.Count), "Não foi");
        }

        [Test]
        public async Task ProcuraPorAreaEspecifica()
        {
            // Arrange - Dados reais do banco de dados
            var search = new FastSearchDTO
            {
                AreaId = 1,
            };

            // Act - Chama o método do controlador usando o contexto real
            var result = await _search.List(_context, search) as ViewResult;

            // Assert - Verifica os resultados
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.ViewData["Projetos"], Is.Not.Null);

            // Captura a lista de projetos do ViewData
            var projetos = result.ViewData["Projetos"] as List<Projeto>;

            // Verifica se a quantidade de projetos é igual a 7
            Assert.That(7, Is.EqualTo(projetos!.Count), "Não foi");
        }

        [Test]
        public async Task ProcuraPorSubreaEspecifica()
        {
            // Arrange - Dados reais do banco de dados
            var search = new FastSearchDTO
            {
                SubareaId = 2,
            };

            // Act - Chama o método do controlador usando o contexto real
            var result = await _search.List(_context, search) as ViewResult;

            // Assert - Verifica os resultados
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.ViewData["Projetos"], Is.Not.Null);

            // Captura a lista de projetos do ViewData
            var projetos = result.ViewData["Projetos"] as List<Projeto>;

            // Verifica se a quantidade de projetos é igual a 7
            Assert.That(8, Is.EqualTo(projetos!.Count), "Não foi");
        }
    }
}