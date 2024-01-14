using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmssProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("UtilizatorId")]

        public ICollection<UtilizatorGrup> UtilizatoriGrupuri { get; set; }
        [InverseProperty("PentruUtilizator")]
        public ICollection<Datorie> DatoriiPentruUtilizator { get; set; }

        [InverseProperty("DeLaUtilizator")]
        public ICollection<Datorie> DatoriiDeLaUtilizator { get; set; }
    }
}