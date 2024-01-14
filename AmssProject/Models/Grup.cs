using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmssProject.Models
{
    public class Grup
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; }
        public int Capacitate { get; set; }

        [ForeignKey("GrupId")]
        public ICollection<UtilizatorGrup> UtilizatoriGrupuri { get; set; }

    }
}
