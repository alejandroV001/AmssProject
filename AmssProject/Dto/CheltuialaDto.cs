namespace AmssProject.Dto;

public class CheltuialaDto
{
        public int Id { get; set; }
        public int TipCheltuialaId { get; set; }
        public int CalatorieId { get; set; }
        public string UtilizatorId { get; set; }
        public string Descriere { get; set; }
        public string Moneda { get; set; }
        public decimal? CostTotal { get; set; }
        public DateTime DataCreare { get; set; }

}