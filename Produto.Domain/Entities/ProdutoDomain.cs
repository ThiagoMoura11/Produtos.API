
using System.ComponentModel.DataAnnotations;

namespace Produto.Domain.Entities
{
    public class ProdutoDomain 
    {
        //public ProdutoDomain(int id, string nome, decimal valor, int quantidade, DateTime datacompra)
        //{
        //    id = Id;
        //    nome = Nome;
        //    valor = Valor;
        //    quantidade = QuantidadeEstoque;
        //    datacompra = DataCompra;
        //}
        [Required(ErrorMessage = "Inclua o Id do produto")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser nulo")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Valor não pode ser nulo")]
        [Range(1,int.MaxValue,ErrorMessage = "O preço deve ser maior que 0")]
        public decimal Valor { get; set; }
        public int QuantidadeEstoque { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
