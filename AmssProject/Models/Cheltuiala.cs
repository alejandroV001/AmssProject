using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmssProject.Models
{
    public class Cheltuiala
    {
        [Key]
        public int Id { get; set; }

        public TipCheltuiala TipCheltuiala { get; set; }

        public Calatorie Calatorie { get; set; }
        public ApplicationUser Initiator { get; set; }

        public string Descriere { get; set; }
        public string Moneda { get; set; }
        public DateTime DataCreare { get; set; }

        [ForeignKey("CheltuialaId")]
        public ICollection<CheltuieliCalatorie> CheltuieliCalatorie { get; set; }
    }
}
