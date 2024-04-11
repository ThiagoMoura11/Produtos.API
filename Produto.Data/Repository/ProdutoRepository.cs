﻿

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

        public bool DeleteProduto(Guid id)
        {
            var produto = _context.Produto.Find(id);
            if (produto == null)
            {
                return false;
            }
            _context.Produto.Remove(produto);
            _context.SaveChanges();
            return true;
        }


        public Task<ProdutoDomain> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProdutoDomain>> GetProduto()
        {
            return _context.Produto.ToList(); 
        }

        public ProdutoDomain UpdateProduto(Guid id, ProdutoDomain produto)
        {
            var produtoExistente = _context.Produto.Find(id);

            if (produtoExistente != null)
            {
                _context.Entry(produtoExistente).CurrentValues.SetValues(produto);
                _context.SaveChanges();
                return produtoExistente;
            }
            else
            {
                return null;
            }
        }
    }
}
