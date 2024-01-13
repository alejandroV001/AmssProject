using System.ComponentModel.DataAnnotations;

namespace AmssProject.Models
{
    public class Notificare
    {
        [Key]
        public int Id { get; set; }
        public int CheltuialaId { get; set; }
        public Cheltuiala Cheltuiala { get; set; }
        public string UtilizatorId { get; set; }
        public ApplicationUser Utilizator { get; set; }

        public string Mesaj { get; set; }
    }
}
