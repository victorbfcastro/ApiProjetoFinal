using System.ComponentModel.DataAnnotations;

namespace ApiProjetoFinal.Models
{
    public class Purchase
    {
        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]

        public int Quantity { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]

        public int ProviderId { get; set; }
        public Provider Providers { get; set; }
    }
}