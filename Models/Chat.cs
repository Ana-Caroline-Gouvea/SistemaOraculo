using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oraculo.Models
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
        public Categoria? Categorias { get; set; }

        [Column("Data")]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }


    }
}
