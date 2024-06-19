using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsightHub.Models
{
    public class Projeto
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly DataInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly DataFim { get; set; }

        [Required]
        [ForeignKey("SubareaId")]
        public int SubareaId { get; set; }

        public virtual SubareaConhecimento? Subarea { get; set; }

        [NotMapped]
        public virtual List<int>? Pesquisadores { get; set; }
    }
}