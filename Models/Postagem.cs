using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Oraculo.Models

{
    [Table("Postagem")]
    public class Postagem
    {
        [Column("PostagemId")]
        [Display(Name = "Id")]
        public int PostagemId { get; set; }

        [ForeignKey("ComunidadeId")]
        public int ComunidadeId { get; set; }
        public Comunidades? Comunidades { get; set; }

        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        public Categoria? Categorias { get; set; }

        [Column("Like")]
        [Display(Name = "Like")]
        public int Like { get; set; }

        [Column("Compartilhamento")]
        [Display(Name = "Compartilhamento")]
        public int Compartilhamento { get; set; }






    }
}
