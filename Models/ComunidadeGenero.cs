using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oraculo.Models
{
    [Table("ComunidadeGenero")]
    public class ComunidadeGenero
    {
        [Column("ComunidadeGeneroId")]
        [Display(Name = "Comunidade Genero Código")]
        public int ComunidadeGeneroId { get; set; }

        [ForeignKey("ComunidadesId")]
        [Display(Name = "Comunidades")]
        public int ComunidadesId { get; set; }
        public Comunidades? Comunidades { get; set; }

        [ForeignKey("GeneroId")]
        [Display(Name = "Genero")]
        public int GeneroId { get; set; }
        public Genero? Genero { get; set; }
    }
}
