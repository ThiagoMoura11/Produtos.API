

using Produto.Domain.Entities;
using Produto.Domain.ViewModels;

namespace Produto.Service.Interface
{
    public interface IProdutoService
    {
        ProdutoDomain AddProduto(ProdutoViewModel Produto);
        Task<IEnumerable<ProdutoDomain>> GetProduto();
        Task<ProdutoDomain> GetById(Guid id);    
        ProdutoDomain UpdateProduto(Guid id, ProdutoDomain Produto);
        bool DeleteProduto(Guid id);
    }
}
