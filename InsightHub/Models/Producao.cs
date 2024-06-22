
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsightHub.Models
{
    public class Producao
    {
        public int Id { get; set; }

        [Required]
        public string? Titulo { get; set; }

        public string? Description { get; set; }

        public string? FilePath { get; set; }

        [Required]
        [ForeignKey("ProjetoKey")]
        public int ProjetoKey { get; set; }

        public virtual Projeto? Projeto { get; set; }
    }
}
