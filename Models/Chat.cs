using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oráculo.Models
{
    [Table("Chat")]
    public class Chat
    {
        [Column("ChatId")]
        [Display(Name = "Id")]
        public int ChatId { get; set; }

        [Column("Mensagem")]
        [Display(Name = "Mensagem")]
        public string Mensagem { get; set; } = string.Empty;

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        [Display(Name = "Usuário")]
        public Categorias? Categorias { get; set; }

        [Column("Data")]
        [Display(Name = "Data")]
        public DateOnly Data { get; set; }


    }
}
