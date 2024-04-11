

using Produto.Domain.Entities;

namespace Produto.Service.Interface
{
    public interface IProdutoService
    {
        ProdutoDomain AddProduto(ProdutoDomain tarefa);
        Task<IEnumerable<ProdutoDomain>> GetProduto();
        Task<ProdutoDomain> GetById(int id);
        ProdutoDomain UpdateProduto(int id, ProdutoDomain tarefa);
        bool DeleteProduto(int id);
    }
}
