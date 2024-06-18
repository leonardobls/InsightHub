﻿// <auto-generated />
using System;
using InsightHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InsightHub.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InsightHub.Models.AreaConhecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AreaConhecimento");
                });

            modelBuilder.Entity("InsightHub.Models.Captacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fornecedor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ProjId")
                        .HasColumnType("integer");

                    b.Property<int>("ProjetoKey")
                        .HasColumnType("integer");

                    b.Property<double?>("Valor")
                        .IsRequired()
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ProjId");

                    b.ToTable("Captacao");
                });

            modelBuilder.Entity("InsightHub.Models.Pesquisador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int?>("SubareaId")
                        .HasColumnType("integer");

                    b.Property<int>("SubareaKey")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubareaId");

                    b.ToTable("Pesquisador");
                });

            modelBuilder.Entity("InsightHub.Models.Producao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Producao");
                });

            modelBuilder.Entity("InsightHub.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataFim")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataInicio")
                        .HasColumnType("date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("QualquerCoisaId")
                        .HasColumnType("integer");

                    b.Property<int>("SubareaKey")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("QualquerCoisaId");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("InsightHub.Models.SubareaConhecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AreaKey")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SubareaConhecimento");
                });

            modelBuilder.Entity("InsightHub.Models.Captacao", b =>
                {
                    b.HasOne("InsightHub.Models.Projeto", "Proj")
                        .WithMany()
                        .HasForeignKey("ProjId");

                    b.Navigation("Proj");
                });

            modelBuilder.Entity("InsightHub.Models.Pesquisador", b =>
                {
                    b.HasOne("InsightHub.Models.SubareaConhecimento", "Subarea")
                        .WithMany()
                        .HasForeignKey("SubareaId");

                    b.Navigation("Subarea");
                });

            modelBuilder.Entity("InsightHub.Models.Projeto", b =>
                {
                    b.HasOne("InsightHub.Models.SubareaConhecimento", "QualquerCoisa")
                        .WithMany()
                        .HasForeignKey("QualquerCoisaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QualquerCoisa");
                });
#pragma warning restore 612, 618
        }
    }
}
