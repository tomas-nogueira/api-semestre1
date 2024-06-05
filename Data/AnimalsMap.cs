using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class AnimalsMap : IEntityTypeConfiguration<AnimalsModel>
    {
        public void Configure(EntityTypeBuilder<AnimalsModel> builder)
        {
            builder.HasKey(x => x.AnimalsId);
            builder.Property(x => x.AnimalNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalRaca).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalTipo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalCor).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalSexo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalObservacao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalFoto).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalDtDesaparecimento).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalDtEncontro).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalStatus).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(255);
        }
    }
}
