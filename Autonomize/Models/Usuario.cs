using System.ComponentModel.DataAnnotations;

namespace Autonomize.Models
{
    public class Usuario
    {
        [Key]
        public int IDUsuario { get; set; }

        [Display(Name = "Nome")]
        public string NomeUsuario { get; set; }

        [Display(Name = "Email")]
        public string EmailUsuario { get; set; }

        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "Perfil")]
        public string TipoUsuario { get; set; }
    }
}
