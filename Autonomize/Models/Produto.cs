using System.ComponentModel.DataAnnotations;

namespace Autonomize.Models
{
    public class Produto
    {
        [Key]
        public int IDProduto { get; set; }

        [Required]
        public string NomeProduto { get; set; }

        public string DescricaoProduto { get; set; }

        [Required]
        public decimal ValorProduto { get; set; }

        [Required]
        public int QuantidadeEstoque { get; set; }

       
    }
}
