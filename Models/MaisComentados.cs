using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oraculo.Models
{
    [Table("MaisComentados")]
    public class MaisComentados
    {
        [Column("MaisComentadosId")]
        [Display(Name = "Código de Mais comentados")]
        public int MaisComentadosId { get; set; }

        [ForeignKey("PostagemId")]
        [Display(Name = "Postagem")]
        public int PostagemId { get; set; }
        public Postagem? Postagem { get; set; }
    }
}
