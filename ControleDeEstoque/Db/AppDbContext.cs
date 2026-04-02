using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Model.Produto> Produtos { get; set; }
    }
}