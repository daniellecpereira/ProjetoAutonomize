using System;
using System.ComponentModel.DataAnnotations;

namespace Autonomize.Models
{
    public class Cliente
    {
        [Key]
        public int IDCliente { get; set; }

        [Required]
        public string NomeCliente { get; set; }

        public string EmailCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public string EnderecoCliente { get; set; }
        public DateTime DataCadastro { get; set; }
        public string HistoricoCompra { get; set; }
    }
}
