

using Produto.Domain.Entities;

namespace Produto.Domain.Interface
{
    public interface IProdutoRepository
    {
        ProdutoDomain AddProduto(ProdutoDomain produto);
        Task<IEnumerable<ProdutoDomain>> GetProduto();
        Task<ProdutoDomain> GetById(Guid id);
        ProdutoDomain UpdateProduto(Guid id, ProdutoDomain produto);
        bool DeleteProduto(Guid id);
    }
}