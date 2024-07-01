using InsightHub.Models;
using Microsoft.EntityFrameworkCore;

namespace InsightHub.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<AreaConhecimento> AreaConhecimento { get; set; }
        public DbSet<SubareaConhecimento> SubareaConhecimento { get; set; }
        public DbSet<Captacao> Captacao { get; set; }
        public DbSet<Pesquisador> Pesquisador { get; set; }
        public DbSet<Producao> Producao { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<ProjetoPesquisadorPivot> ProjetoPesquisadorPivot { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseNpgsql("Server=localhost;Port=5432;Database=InsightHub;User Id=postgres;Password=ola;");

        //Edu: "Server=localhost;Port=5432;Database=InsightHub;User Id=postgres;Password=ola;"
        //Leo: "Server=localhost;Port=5433;Database=InsightHub;User Id=postgres;Password=1234;"
    }
}
