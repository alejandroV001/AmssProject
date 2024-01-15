namespace AmssProject.Dto
{
    public class CalatorieGrupDto
    {
        public int Id { get; set; }
        public string Destinatie { get; set; }
        //public int GrupId { get; set; }
        public GrupDto Grup { get; set; }
        public List<CheltuialaDto> Cheltuieli { get; set; }
    }
}
