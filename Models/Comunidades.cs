using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oraculo.Models
{
    [Table("Comunidades")]
    public class Comunidades

    {
        [Column("ComunidadesId")]
        [Display(Name = "Id")]
        public int ComunidadesId { get; set; }

        [Column("NomeComunidade")]
        [Display(Name = "Nome Comunidade")]
        public string NomeComunidade { get; set; } = string.Empty;


    }
}
