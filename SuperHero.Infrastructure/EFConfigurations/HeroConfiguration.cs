using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperHero.Dominio.Models;

namespace SuperHero.Infrastructure.EFConfigurations
{
    internal class HeroConfiguration : IEntityTypeConfiguration<Hero>
    {
        public void Configure(EntityTypeBuilder<Hero> builder)
        {
            ConfigureHeroTable(builder);
        }

        private void ConfigureHeroTable(EntityTypeBuilder<Hero> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(300);

            builder.Property(x => x.FirstName)
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .HasMaxLength(150);

            builder.HasOne(x => x.City)
                .WithMany(x=> x.Heros)
                .HasForeignKey(x => x.CityId);

        }
    }
}
