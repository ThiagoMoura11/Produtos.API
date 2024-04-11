
using Produto.Domain.Entities;
using Produto.Domain.Interface;
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
        public async Task<ProdutoDomain> GetById(int id)
        {
            var resposta = await _repository.GetById(id);
            if (resposta == null) throw new Exception("Tarefa inexistente");
            return resposta;
        }
        public ProdutoDomain AddProduto(ProdutoDomain produto)
        {
            return _repository.AddProduto(produto);
        }
        public ProdutoDomain UpdateProduto(int id, ProdutoDomain produto)
        {
            if (produto == null) throw new Exception("Tarefa inexistente");
            return _repository.UpdateProduto(id ,produto);
        }
        public bool DeleteProduto(int id)
        {
            var resposta = _repository.DeleteProduto(id);
            if (resposta == null || resposta == false) throw new Exception("Tarefa inexistente");
            return resposta;
        }
    }
}
