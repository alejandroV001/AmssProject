using AmssProject.Models;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AmssProject.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<TipCheltuiala> TipCheltuiala { get; set; }
        public DbSet<Grup> Grup { get; set; }

        public DbSet<UtilizatorGrup> UtilizatoriGrupuri { get; set; }
        public DbSet<Calatorie> Calatorie { get; set; }
        public DbSet<Cheltuiala> Cheltuiala { get; set; }
        public DbSet<Datorie> Datorie { get; set; }
        public DbSet<Notificare> Notificare { get; set; }
        public DbSet<CheltuieliCalatorie> CheltuieliCalatorie { get; set; }

        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UtilizatorGrup>()
                .HasKey(ug => new { ug.UtilizatorId, ug.GrupId });

            modelBuilder.Entity<UtilizatorGrup>()
                .HasOne(ug => ug.Utilizator)
                .WithMany(u => u.UtilizatoriGrupuri)
                .HasForeignKey(ug => ug.UtilizatorId);

            modelBuilder.Entity<UtilizatorGrup>()
                .HasOne(ug => ug.Grup)
                .WithMany(g => g.UtilizatoriGrupuri)
                .HasForeignKey(ug => ug.GrupId);

            modelBuilder.Entity<CheltuieliCalatorie>()
                .HasKey(ug => new { ug.CheltuialaId, ug.CalatorieId });

            modelBuilder.Entity<CheltuieliCalatorie>()
                .HasOne(ug => ug.Cheltuiala)
                .WithMany(u => u.CheltuieliCalatorie)
                .HasForeignKey(ug => ug.CheltuialaId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CheltuieliCalatorie>()
                .HasOne(ug => ug.Calatorie)
                .WithMany(g => g.CheltuieliCalatorie)
                .HasForeignKey(ug => ug.CalatorieId)
                .OnDelete(DeleteBehavior.NoAction); 

            // Alte configurări...

            // Iată configurarea adițională pentru ApplicationUser
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.UtilizatoriGrupuri)
                .WithOne(ug => ug.Utilizator)
                .HasForeignKey(ug => ug.UtilizatorId);


            modelBuilder.Entity<Datorie>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Datorie>()
                .HasOne(d => d.PentruUtilizator)
                .WithMany(u => u.DatoriiPentruUtilizator)
                .HasForeignKey(d => d.PentruUtilizatorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Datorie>()
                .HasOne(d => d.DeLaUtilizator)
                .WithMany(u => u.DatoriiDeLaUtilizator)
                .HasForeignKey(d => d.DeLaUtilizatorId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}