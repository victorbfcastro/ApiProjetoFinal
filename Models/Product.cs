using System.ComponentModel.DataAnnotations;

namespace ApiProjetoFinal.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; } 


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Fornecedor inválido")]

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        
    }
}