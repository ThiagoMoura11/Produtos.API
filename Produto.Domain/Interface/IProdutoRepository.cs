

using Produto.Domain.Entities;

namespace Produto.Domain.Interface
{
    public interface IProdutoRepository
    {
        ProdutoDomain AddProduto(ProdutoDomain produto);
        Task<IEnumerable<ProdutoDomain>> GetProduto();
        Task<ProdutoDomain> GetById(int id);
        ProdutoDomain UpdateProduto(int id, ProdutoDomain produto);
        bool DeleteProduto(int id);
    }
}