using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPersonajesAWS.Models
{
    [Table("PERSONAJES")]
    public class Personaje {
        [Key]
        [Column("IDPERSONAJE")]
        public int idpersonaje { get; set; }
        [Column("PERSONAJE")]
        public string personaje { get; set; }
        [Column("IMAGEN")]
        public string imagen { get; set; }
    }
}
