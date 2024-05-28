using System.ComponentModel.DataAnnotations;

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
    }
}