using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CertifikacijaMVC.Models;

namespace CertifikacijaMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Rezultat> Rezultati { get; set; }
        public DbSet<TipPolaganja> TipPolaganja { get; set; }
        public DbSet<Pitanje> Pitanja { get; set; }
        public DbSet<Odgovor> Odgovori { get; set; }
        public DbSet<Test> Testovi { get; set; }
        public DbSet<OdabirTipa> OdabirTipas { get; set; }
        public DbSet<Certifikat> Certifikati { get; set; }
        public DbSet<OdgNaPitanje> OdgNaPitanjes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Rezultat>().ToTable("Rezultat");
            builder.Entity<TipPolaganja>().ToTable("TipPolaganja");
            builder.Entity<Pitanje>().ToTable("Pitanje");
            builder.Entity<Odgovor>().ToTable("Odgovor");
            builder.Entity<Test>().ToTable("Test");
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<CertifikacijaMVC.Models.OdabirTipa> OdabirTipa { get; set; }
    }
}
