using Livraria.Domain.Livros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Infra.Data.Livros.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Titulo)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Autor)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Editora)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Edicao)
                .HasColumnType("int")
                .IsRequired(); 

            builder.Property(c => c.ISBN)
              .HasColumnType("varchar(50)")
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(c => c.Idioma)
             .HasColumnType("varchar(50)")
             .HasMaxLength(50)
             .IsRequired();
        }
    }
}
