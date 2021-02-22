﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    [DbContext(typeof(TesteContext))]
    partial class TesteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Data.Entities.Carrinho", b =>
                {
                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("VendaId")
                        .HasColumnType("integer");

                    b.HasKey("ProdutoId", "VendaId");

                    b.HasIndex("VendaId");

                    b.ToTable("Carrinho");
                });

            modelBuilder.Entity("Data.Entities.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("Data.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cor")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("PrecoCusto")
                        .HasColumnType("double precision");

                    b.Property<double>("PrecoVenda")
                        .HasColumnType("double precision");

                    b.Property<string>("Tamanho")
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cor = "Azul",
                            DataEntrada = new DateTime(2021, 2, 22, 16, 12, 49, 565, DateTimeKind.Local).AddTicks(745),
                            PrecoCusto = 50.0,
                            PrecoVenda = 100.0,
                            Tamanho = "M",
                            Tipo = "Calça"
                        },
                        new
                        {
                            Id = 2,
                            Cor = "Preta",
                            DataEntrada = new DateTime(2021, 2, 22, 16, 12, 49, 567, DateTimeKind.Local).AddTicks(150),
                            PrecoCusto = 40.0,
                            PrecoVenda = 70.0,
                            Tamanho = "P",
                            Tipo = "Blusa"
                        },
                        new
                        {
                            Id = 3,
                            Cor = "Branco",
                            DataEntrada = new DateTime(2021, 2, 22, 16, 12, 49, 567, DateTimeKind.Local).AddTicks(191),
                            PrecoCusto = 60.0,
                            PrecoVenda = 130.0,
                            Tamanho = "P",
                            Tipo = "Vestido"
                        });
                });

            modelBuilder.Entity("Data.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "testePaulo@mailinator.com",
                            Nome = "Paulo",
                            Password = "123456",
                            Role = "admin"
                        });
                });

            modelBuilder.Entity("Data.Entities.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Concluida")
                        .HasColumnType("boolean");

                    b.Property<double>("Custo")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Lucro")
                        .HasColumnType("double precision");

                    b.Property<double>("ValorVenda")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("Data.Entities.Carrinho", b =>
                {
                    b.HasOne("Data.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Venda", "Venda")
                        .WithMany()
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("Data.Entities.Estoque", b =>
                {
                    b.HasOne("Data.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.Navigation("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}