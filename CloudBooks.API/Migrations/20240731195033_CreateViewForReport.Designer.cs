﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CloudBooks.API.Migrations
{
    [DbContext(typeof(ConnectionContext))]
    [Migration("20240731195033_CreateViewForReport")]
    partial class CreateViewForReport
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assunto", b =>
                {
                    b.Property<int>("CodAs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodAs"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodAs");

                    b.ToTable("Assuntos");
                });

            modelBuilder.Entity("Autor", b =>
                {
                    b.Property<int>("CodAu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodAu"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodAu");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Livro", b =>
                {
                    b.Property<int>("Codl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codl"));

                    b.Property<string>("AnoPublicacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edicao")
                        .HasColumnType("int");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codl");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("Livro_Assunto", b =>
                {
                    b.Property<int>("Livro_Codl")
                        .HasColumnType("int");

                    b.Property<int>("Assunto_CodAs")
                        .HasColumnType("int");

                    b.HasKey("Livro_Codl", "Assunto_CodAs");

                    b.HasIndex("Assunto_CodAs");

                    b.ToTable("Livro_Assuntos");
                });

            modelBuilder.Entity("Livro_Autor", b =>
                {
                    b.Property<int>("Livro_Codl")
                        .HasColumnType("int");

                    b.Property<int>("Autor_CodAu")
                        .HasColumnType("int");

                    b.HasKey("Livro_Codl", "Autor_CodAu");

                    b.HasIndex("Autor_CodAu");

                    b.ToTable("Livro_Autores");
                });

            modelBuilder.Entity("Livro_Assunto", b =>
                {
                    b.HasOne("Assunto", "Assunto")
                        .WithMany("Livro_Assuntos")
                        .HasForeignKey("Assunto_CodAs")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Livro", "Livro")
                        .WithMany("Livro_Assuntos")
                        .HasForeignKey("Livro_Codl")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assunto");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Livro_Autor", b =>
                {
                    b.HasOne("Autor", "Autor")
                        .WithMany("Livro_Autores")
                        .HasForeignKey("Autor_CodAu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Livro", "Livro")
                        .WithMany("Livro_Autores")
                        .HasForeignKey("Livro_Codl")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Assunto", b =>
                {
                    b.Navigation("Livro_Assuntos");
                });

            modelBuilder.Entity("Autor", b =>
                {
                    b.Navigation("Livro_Autores");
                });

            modelBuilder.Entity("Livro", b =>
                {
                    b.Navigation("Livro_Assuntos");

                    b.Navigation("Livro_Autores");
                });
#pragma warning restore 612, 618
        }
    }
}
