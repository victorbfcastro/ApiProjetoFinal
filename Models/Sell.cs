using System.ComponentModel.DataAnnotations;

namespace ApiProjetoFinal.Models
{
    public class Sell
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantidade inválida")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Produto Inválido")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string PaymentType { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Cliente deve ser maior que zero")]

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}