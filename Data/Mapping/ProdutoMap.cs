using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public partial class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> modelBuilder)
        {
            modelBuilder.HasKey(x => x.Id);
            modelBuilder.HasData(new List<Produto>()
            {
                new Produto(1, "Calça", 50, 100, "M", "Azul", DateTime.Now),
                new Produto(2, "Blusa", 40, 70, "P", "Preta", DateTime.Now),
                new Produto(3, "Vestido", 60, 130, "P", "Branco", DateTime.Now)
            });
        }

    }
}
