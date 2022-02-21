﻿// <auto-generated />
using System;
using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestrutura.Migrations
{
    [DbContext(typeof(MySQLContext))]
    partial class MySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.CategoriaDespesaDominio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("categoria");

                    b.HasKey("Id");

                    b.ToTable("categoria");
                });

            modelBuilder.Entity("Dominio.DespesaDominio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dataCadastro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("descricao");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("valor");

                    b.Property<long>("categoriaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("categoriaId");

                    b.ToTable("despesa");
                });

            modelBuilder.Entity("Dominio.ReceitaDominio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dataCadastro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("descricao");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.ToTable("receita");
                });

            modelBuilder.Entity("Dominio.DespesaDominio", b =>
                {
                    b.HasOne("Dominio.CategoriaDespesaDominio", "CategoriaId")
                        .WithMany()
                        .HasForeignKey("categoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaId");
                });
#pragma warning restore 612, 618
        }
    }
}
