
using System.ComponentModel.DataAnnotations;

namespace InsightHub.Models
{
    public class AreaConhecimento
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Numero { get; set; }
    }
}
