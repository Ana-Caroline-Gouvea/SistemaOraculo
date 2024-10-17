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

        [Column("PostagemNome")]
        [Display(Name = "Nome a Postagem")]
        public string PostagemNome { get; set; } = string.Empty;

        [Column("PostagemImg")]
        [Display(Name = "Imagem da Postagem")]
        public string PostagemImg { get; set; } = string.Empty;

        [ForeignKey("ComunidadesId")]
        public int ComunidadesId { get; set; }
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
