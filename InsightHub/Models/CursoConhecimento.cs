
using System.ComponentModel.DataAnnotations;

namespace InsightHub.Models
{
    public class CursoConhecimento
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Numero { get; set; }

        [Required]
        public int? SubsubKey { get; set; }
    }
}
