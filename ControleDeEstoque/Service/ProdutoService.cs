using ControleDeEstoque.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Service
{
    public class ProdutoService
    {
        private readonly Db.AppDbContext _context;

        public ProdutoService(Db.AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Model.Produto>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Model.Produto> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task AddAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Produto produto)
        {
            var produtoExistente = await _context.Produtos.FindAsync(id); // Busca o registro
            if (produtoExistente == null) // Verifica se o registro existe
            {
                throw new Exception("Produto não encontrado");
            }
            {
                produtoExistente.Nome = produto.Nome;
                produtoExistente.Preco = produto.Preco;
                produtoExistente.Quantidade = produto.Quantidade;
                
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task UpdatePartialAsync(int id, Produto produto)
        {
            var produtoExistente = await _context.Produtos.FindAsync(id);
            if (produtoExistente == null)
            {
                throw new Exception("Produto não encontrado");
            }
            {
                if (!string.IsNullOrEmpty(produto.Nome))
                {
                    produtoExistente.Nome = produto.Nome;
                }
                if (produto.Preco > 0)
                {
                    produtoExistente.Preco = produto.Preco;
                }
                if (produto.Quantidade > 0)
                {
                    produtoExistente.Quantidade = produto.Quantidade;
                }
                
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }
            _context.Produtos.Remove(produto);

            await _context.SaveChangesAsync();
        }
    }
}