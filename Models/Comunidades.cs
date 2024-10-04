using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oráculo.Models
{
    [Table("Comunidades")]
    public class Comunidades

    {
        [Column("ComunidadeId")]
        [Display(Name = "Id")]
        public int ComunidadeId { get; set; }

        [Column("NomeComunidade")]
        [Display(Name = "Nome Comunidade")]
        public string NomeComunidade { get; set; } = string.Empty;


    }
}
