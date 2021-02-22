using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public partial class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> modelBuilder)
        {
            modelBuilder.HasKey(x => x.Id);
            modelBuilder.HasData(new Usuario() { Id = 1, Nome = "Paulo", Password = "123456", Email = "testePaulo@mailinator.com", Role = "admin" });
        }
    }
}
