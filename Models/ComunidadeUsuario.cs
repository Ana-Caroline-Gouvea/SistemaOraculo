using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oraculo.Models
{
    [Table("ComunidadeUsuario")]
    public class ComunidadeUsuario
    {
        [Column("ComunidadeUsuarioId")]
        [Display(Name = "Comunidade Usuário")]
        public int ComunidadeUsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [ForeignKey("ComunidadesId")]
        public int ComunidadesId { get; set; }
        public Comunidades? Comunidades { get; set; }
    }
}
