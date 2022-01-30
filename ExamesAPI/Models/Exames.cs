using System.ComponentModel.DataAnnotations;

namespace ExamesAPI.Models
{
    public class Exames
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Código do procedimento é obrigatório")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome do procedimento é obrigatório")]
        public string Descricao { get; set; }
        
        [Required]
        public string TipoExame { get; set; }

        public string PreRequisitos { get; set; }
    }
}
