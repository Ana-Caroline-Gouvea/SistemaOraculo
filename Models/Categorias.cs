using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oráculo.Models
{
    [Table("Categorias")]
    public class Categorias
    {
        [Column("CategoriaId")]
        [Display(Name = "Id")]
        public int CategoriasId { get; set; }

        [Column("CategoriasNomes")]
        [Display(Name = "Categoria Nome ")]
        public string DadosInfluencerSeguidores { get; set; } = string.Empty;
    }
}
