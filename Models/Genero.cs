using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Oraculo.Models
{
    [Table ("Genero")]
    public class Genero
    {
        [Column("GeneroId")]
        [Display(Name = "Código do Genero")]
        public int GeneroId { get; set; }

        [Column("GeneroNome")]
        [Display(Name = "Texto do Gênero")]
        public string GeneroNome { get; set; } = string.Empty;
    }
}
