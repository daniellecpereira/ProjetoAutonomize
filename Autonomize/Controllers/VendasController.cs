using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autonomize.Models;
using Autonomize.Models.ViewModels;

namespace Autonomize.Controllers
{
    public class VendasController : Controller
    {
        private readonly AppDbContext _context;

        public VendasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var vendas = _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario);
            return View(await vendas.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var venda = await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .Include(v => v.ItensVenda)
                    .ThenInclude(iv => iv.Produto)
                .FirstOrDefaultAsync(m => m.IDVenda == id);

            if (venda == null) return NotFound();

            return View(venda);
        }

        // GET: Vendas/CriarVenda
        public IActionResult CriarVenda()
        {
            ViewData["Clientes"] = new SelectList(_context.Clientes, "IDCliente", "NomeCliente");
            ViewData["Produtos"] = new SelectList(_context.Produtos, "IDProduto", "NomeProduto");
            ViewData["TiposPagamento"] = new SelectList(new[] { "Dinheiro", "Crédito", "Débito", "PIX", "Boleto" });

            return View(new CriarVendaViewModel
            {
                DataVenda = DateTime.Today,
                Quantidade = 1,
                PrecoUnitario = 0
            });
        }

        // POST: Vendas/CriarVenda
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarVenda(CriarVendaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Clientes"] = new SelectList(_context.Clientes, "IDCliente", "NomeCliente", model.IDCliente);
                ViewData["Produtos"] = new SelectList(_context.Produtos, "IDProduto", "NomeProduto", model.IDProduto);
                ViewData["TiposPagamento"] = new SelectList(new[] { "Dinheiro", "Crédito", "Débito", "PIX", "Boleto" }, model.TipoPagamento);
                return View(model);
            }

            var produto = await _context.Produtos.FindAsync(model.IDProduto);
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(); // Simulação

            if (produto == null || usuario == null)
            {
                ModelState.AddModelError("", "Produto ou usuário não encontrado.");
                return View(model);
            }

            var venda = new Venda
            {
                IDCliente = model.IDCliente,
                IDUsuario = usuario.IDUsuario,
                DataVenda = model.DataVenda,
                TotalVenda = produto.ValorProduto * model.Quantidade
            };

            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            var item = new ItemVenda
            {
                IDVenda = venda.IDVenda,
                IDProduto = produto.IDProduto,
                QuantidadeVendida = model.Quantidade,
                PrecoProduto = produto.ValorProduto
            };

            _context.ItensVenda.Add(item);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var venda = await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.IDVenda == id);

            if (venda == null) return NotFound();

            return View(venda);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.IDVenda == id);
        }
    }
}
