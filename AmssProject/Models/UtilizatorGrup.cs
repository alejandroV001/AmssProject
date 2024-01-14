namespace AmssProject.Models
{
    public class UtilizatorGrup
    {
        public string UtilizatorId { get; set; }
        public ApplicationUser Utilizator { get; set; }

        public int GrupId { get; set; }
        public Grup Grup { get; set; }
    }
}
