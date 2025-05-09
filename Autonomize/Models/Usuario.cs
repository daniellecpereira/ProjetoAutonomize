using System.ComponentModel.DataAnnotations;

namespace Autonomize.Models
{
    public class Usuario
    {
        [Key]
        public int IDUsuario { get; set; }

        [Required]
        public string NomeUsuario { get; set; }

        [Required]
        public string EmailUsuario { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string TipoUsuario { get; set; } // admin, vendedor, funcionario
    }
}
