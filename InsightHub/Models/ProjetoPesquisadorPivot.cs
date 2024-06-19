using System.ComponentModel.DataAnnotations.Schema;

namespace InsightHub.Models
{
    public class ProjetoPesquisadorPivot
    {
        public int Id { get; set; }

        [ForeignKey("ProjetoId")]
        public int ProjetoId { get; set; }

        public virtual Projeto? Projeto { get; set; }

        [ForeignKey("PesquisadorId")]
        public int PesquisadorId { get; set; }

        public virtual Pesquisador? Pesquisador { get; set; }
    }
}