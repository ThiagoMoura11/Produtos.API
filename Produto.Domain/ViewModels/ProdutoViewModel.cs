using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Produto.Domain.ViewModels
{
    public class ProdutoViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser nulo")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Valor não pode ser nulo")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que 0")]
        public decimal Valor { get; set; }
        public int QuantidadeEstoque { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
