
using Produto.Domain.Entities;
using Produto.Domain.Interface;
using Produto.Domain.ViewModels;
using Produto.Service.Interface;

namespace Produto.Service
{
    public class ProdutoService : IProdutoService 
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;   
        }

        public async Task<IEnumerable<ProdutoDomain>> GetProduto()
        {
            var produtolist = await _repository.GetProduto();
            return produtolist.OrderBy(t => t.Id);
        }
        public async Task<ProdutoDomain> GetById(Guid id)
        {
            var resposta = await _repository.GetById(id);
            if (resposta == null) throw new Exception("Tarefa inexistente");
            return resposta;
        }
        public ProdutoDomain AddProduto(ProdutoViewModel produto)
        {
            ProdutoDomain produtoDomain = new ProdutoDomain
            {
                Id = Guid.NewGuid(),
                Nome = produto.Nome,
                Valor = produto.Valor,
                QuantidadeEstoque = produto.QuantidadeEstoque,
                DataCompra = produto.DataCompra
            };
            return _repository.AddProduto(produtoDomain);
        }
        public ProdutoDomain UpdateProduto(Guid id, ProdutoDomain produto)
        {
            if (produto == null) throw new Exception("Tarefa inexistente");
            return _repository.UpdateProduto(id ,produto);
        }
        public bool DeleteProduto(Guid id)
        {
            var resposta = _repository.DeleteProduto(id);
            if (resposta == null || resposta == false) throw new Exception("Tarefa inexistente");
            return resposta;
        }
    }
}
