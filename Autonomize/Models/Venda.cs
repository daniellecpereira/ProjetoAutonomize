
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Autonomize.Models
{
    public class Venda
    {
        [Key]
        public int IDVenda { get; set; }

        [Required]
        public int IDUsuario { get; set; }

        [ForeignKey("IDUsuario")]
        public Usuario Usuario { get; set; }

        [Required]
        public int IDCliente { get; set; }

        [ForeignKey("IDCliente")]
        public Cliente Cliente { get; set; }

        [Required]
        public DateTime DataVenda { get; set; }

        [Required]
        public decimal TotalVenda { get; set; }

        public ICollection<ItemVenda> ItensVenda { get; set; }
    }
}
