using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oraculo.Models
{
    [Table ("Novidade")]
    public class Novidade
    {
        [Column("NovidadeId")]
        [Display(Name = "Código da Novidade")]
        public int NovidadeId { get; set; }

        [Column("NovidadeFoto")]
        [Display(Name = "Foto da Novidade")]
        public string NovidadeFoto { get; set; } = string.Empty;

        [Column("NovidadeTexto")]
        [Display(Name = "Texto da Novidade")]
        public string NovidadeTexto { get; set; } = string.Empty;
    }
}
