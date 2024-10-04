using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Oráculo.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("UsuarioId")]
        [Display(Name = "Código do Usuário")]
        public int UsuarioId { get; set; }

        [Column("UsuarioNome")]
        [Display(Name = "Nome do Usuário")]
        public string UsuarioNome { get; set; } = string.Empty;

        [Column("UsuarioEmail")]
        [Display(Name = "Email do Usuário")]
        public string UsuarioEmail { get; set; } = string.Empty;

        [Column("UsuarioApelido")]
        [Display(Name = "Apelido do Usuário")]
        public string UsuarioApelido { get; set; } = string.Empty;

        [Column("UsuarioDataNascimento")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimeto { get; set; }

        [Column("UsuarioSenha")]
        [Display(Name = "Senha")]
        public string UsuarioSenha { get; set; } = string.Empty;

        [Column("UsuarioConfirmarSenha")]
        [Display(Name = "Confirmar senha")]
        public string UsuarioConfirmarSenha { get; set; } = string.Empty;
    }

}
