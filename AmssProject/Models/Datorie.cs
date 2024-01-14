using System.ComponentModel.DataAnnotations.Schema;

namespace AmssProject.Models
{
    public class Datorie
    {
        public int Id { get; set; }
        public float Suma { get; set; }
        public bool Stare { get; set; } = false;

        public string PentruUtilizatorId { get; set; }
        public string DeLaUtilizatorId { get; set; }

        public int CheltuialaId { get; set; }
        public Cheltuiala Cheltuiala { get; set; }
        [ForeignKey("PentruUtilizatorId")]
        [InverseProperty("DatoriiPentruUtilizator")]
        public ApplicationUser PentruUtilizator { get; set; }

        [ForeignKey("DeLaUtilizatorId")]
        [InverseProperty("DatoriiDeLaUtilizator")]
        public ApplicationUser DeLaUtilizator { get; set; }
    }
}
