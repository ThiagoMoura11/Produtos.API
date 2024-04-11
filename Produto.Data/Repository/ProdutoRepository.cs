

using Produto.Data.Context;
using Produto.Domain.Entities;
using Produto.Domain.Interface;

namespace Produto.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _context;
        public ProdutoRepository(ProdutoContext context)
        {
            _context = context;
        }
        public ProdutoDomain AddProduto(ProdutoDomain produto)
        {
            _context.Produto.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public bool DeleteProduto(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoDomain> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProdutoDomain>> GetProduto()
        {
            return _context.Produto.ToList(); 
        }

        public ProdutoDomain UpdateProduto(int id, ProdutoDomain produto)
        {
            throw new NotImplementedException();
        }
    }
}
