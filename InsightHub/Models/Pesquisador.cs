
using System.ComponentModel.DataAnnotations;

namespace InsightHub.Models
{
    public class Pesquisador
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Email { get; set; }
    }
}
