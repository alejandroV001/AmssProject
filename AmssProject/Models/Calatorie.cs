using System.ComponentModel.DataAnnotations.Schema;

namespace AmssProject.Models
{
    public class Calatorie
    {
        public int Id { get; set; }
        public string Destinatie { get; set; }
        public Grup Grup { get; set; }

        [ForeignKey("CalatorieId")]
        public ICollection<CheltuieliCalatorie> CheltuieliCalatorie { get; set; }
    }
}
