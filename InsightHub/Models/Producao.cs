
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsightHub.Models
{
    public class Producao
    {
        public int Id { get; set; }

        [Required]
        public string? Titulo { get; set; }

        [Required]
        public string? Tipo { get; set; }

        public string? Description { get; set; }

        public string? FilePath { get; set; }

        [Required]
        [ForeignKey("ProjetoId")]
        public int ProjetoId { get; set; }

        public virtual Projeto? Projeto { get; set; }
    }
}
