using System.ComponentModel.DataAnnotations;
namespace ApiProjetoFinal.Models
{
    public class Stock
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
        //public double ValorTotal{ get; set; }
    }
}