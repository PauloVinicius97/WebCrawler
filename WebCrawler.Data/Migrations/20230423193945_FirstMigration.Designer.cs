﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebCrawler.Data;

#nullable disable

namespace WebCrawler.Data.Migrations
{
    [DbContext(typeof(WebCrawlerContext))]
    [Migration("20230423193945_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("WebCrawler.Domain.Entities.Movimentacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Detalhes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroProcessoFK")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NumeroProcessoFK");

                    b.ToTable("Movimentacao");
                });

            modelBuilder.Entity("WebCrawler.Domain.Entities.Processo", b =>
                {
                    b.Property<string>("NumeroProcesso")
                        .HasColumnType("TEXT");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Assunto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Classe")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Distribuicao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Relator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("NumeroProcesso");

                    b.ToTable("Processo");
                });

            modelBuilder.Entity("WebCrawler.Domain.Entities.Movimentacao", b =>
                {
                    b.HasOne("WebCrawler.Domain.Entities.Processo", null)
                        .WithMany("Movimentacoes")
                        .HasForeignKey("NumeroProcessoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebCrawler.Domain.Entities.Processo", b =>
                {
                    b.Navigation("Movimentacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
