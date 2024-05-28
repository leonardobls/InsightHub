
using System.ComponentModel.DataAnnotations;

namespace InsightHub.Models
{
    public class SubareaConhecimento
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }
    }
}
