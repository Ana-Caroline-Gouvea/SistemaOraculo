using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oraculo.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Column("CategoriaId")]
        [Display(Name = "Id")]
        public int CategoriaId { get; set; }

        [Column("CategoriaNome")]
        [Display(Name = "Categoria Nome ")]
        public string CategoriaNome { get; set; } = string.Empty;

    }
}
