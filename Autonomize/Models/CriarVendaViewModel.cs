using System.ComponentModel.DataAnnotations;

namespace Autonomize.Models.ViewModels
{
    public class CriarVendaViewModel
    {
        [Required]
        public int IDCliente { get; set; }

        [Required]
        public DateTime DataVenda { get; set; }

        [Required]
        public int IDProduto { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public string TipoPagamento { get; set; }

        public decimal PrecoUnitario { get; set; }

        public decimal ValorTotal => Quantidade * PrecoUnitario;
    }
}
