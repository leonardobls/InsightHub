
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsightHub.Models
{
    public class Captacao
    {
        public int Id { get; set; }

        [Required]
        public double? Valor { get; set; }

        [Required]
        public DateOnly Data { get; set; }

        [Required]
        public string? Descricao { get; set; }

        [Required]
        public string? Fornecedor { get; set; }

        [ForeignKey("ProjetoId")]
        public int ProjetoId { get; set; }

        public virtual Projeto? Proj { get; set; }
    }
}
