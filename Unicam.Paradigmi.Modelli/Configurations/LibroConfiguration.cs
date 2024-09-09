using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Modelli.Entities;

namespace Unicam.Paradigmi.Modelli.Configurations
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libri");
            builder.HasKey(l => l.ISBN);
            builder.Property(l => l.Nome).HasMaxLength(50);
            builder.Property(l => l.Autore).HasMaxLength(50);
            builder.Property(l => l.Editore).HasMaxLength(50);
            builder.HasOne(l => l.Categoria).WithMany(l => l.Libri).HasForeignKey(l => l.Nome);
        }
    }
}
