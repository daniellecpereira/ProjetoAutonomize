using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomize.Models
{
    public class ItemVenda
    {
        [Key]
        public int IDItemVenda { get; set; }

        [Required]
        public int IDVenda { get; set; }

        [ForeignKey("IDVenda")]
        public Venda Venda { get; set; }

        [Required]
        public int IDProduto { get; set; }

        [ForeignKey("IDProduto")]
        public Produto Produto { get; set; }

        [Required]
        public int QuantidadeVendida { get; set; }

        [Required]
        public decimal PrecoProduto { get; set; }

        public decimal Subtotal => QuantidadeVendida * PrecoProduto;
    }
}
