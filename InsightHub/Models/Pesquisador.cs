
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsightHub.Models
{
    public class Pesquisador
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        [ForeignKey("SubareaKey")]
        public int SubareaKey { get; set; }

        public virtual SubareaConhecimento? Subarea { get; set; }
    }
}
