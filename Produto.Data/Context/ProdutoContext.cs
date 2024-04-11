using Microsoft.EntityFrameworkCore;
using Produto.Domain.Entities;

namespace Produto.Data.Context
{
    public class ProdutoContext : DbContext
    {
        public DbSet<ProdutoDomain> Produto { get; set; }

        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
            
        }
    }
}
