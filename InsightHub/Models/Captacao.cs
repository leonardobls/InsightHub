
using System.ComponentModel.DataAnnotations;

namespace InsightHub.Models
{
    public class Captacao
    {
        public int Id { get; set; }

        [Required]
        public double? Valor { get; set; }

        [Required]
        public string? Tipo { get; set; }

        [Required]
        public string? Descricao { get; set; }

        [Required]
        public string? Fornecedor { get; set; }
    }
}
