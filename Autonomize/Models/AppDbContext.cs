using Microsoft.EntityFrameworkCore;
using Autonomize.Models;

namespace Autonomize.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        // public DbSet<Fornecedor> Fornecedores { get; set; }
         public DbSet<ItemVenda> ItensVenda { get; set; }
        // public DbSet<PedidoCompra> PedidosCompra { get; set; }
        // public DbSet<Pagamento> Pagamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemVenda>()
                .HasOne(iv => iv.Venda)
                .WithMany(v => v.ItensVenda)
                .HasForeignKey(iv => iv.IDVenda)
                .OnDelete(DeleteBehavior.Restrict); // <- isso resolve o erro
        }
    }
}
