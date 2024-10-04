using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oraculo.Models
{
    [Table("Evento")]
    public class Evento
    {
        [Column("EventoId")]
        [Display(Name = "Código do Evento")]
        public int EventoId { get; set; }

        [Column("EventoFoto")]
        [Display(Name = "Foto do Evento")]
        public string EventoFoto { get; set; } = string.Empty;

        [Column("EventoTexto")]
        [Display(Name = "Texto da Evento")]
        public string EventoTexto { get; set; } = string.Empty;
    }
}
