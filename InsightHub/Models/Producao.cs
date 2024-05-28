
using System.ComponentModel.DataAnnotations;

namespace InsightHub.Models
{
    public class Producao
    {
        public int Id { get; set; }

        [Required]
        public string? Tipo { get; set; }

        [Required]
        public string? FilePath { get; set; }
    }
}
