namespace AmssProject.Dto
{
    public class DatorieDto
    {
        public int Id { get; set; }
        public float Suma { get; set; }
        public bool Stare { get; set; } = false;

        public string PentruUtilizatorId { get; set; }
        public string DeLaUtilizatorId { get; set; }

        public int CheltuialaId { get; set; }
    }
}
