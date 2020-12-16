using System.ComponentModel.DataAnnotations;

namespace ApiProjetoFinal.Models
{
    public class Provider
    {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um email válido! (exemplo@email.com)")]
        public string Email { get; set; } 

    }
}