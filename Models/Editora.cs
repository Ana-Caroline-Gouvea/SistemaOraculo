using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Oraculo.Models
{
    [Table("Editora")]
    public class Editora
    {
        [Column("EditoraId")]
        [Display(Name = "Código do Editora")]
        public int EditoraId { get; set; }

        [Column("EditoraFoto")]
        [Display(Name = "Foto da Editora")]
        public string EditoraFoto { get; set; } = string.Empty;

        [Column("EditoraTexto")]
        [Display(Name = "Texto da Editora")]
        public string EditoraTexto { get; set; } = string.Empty;
    }
}
