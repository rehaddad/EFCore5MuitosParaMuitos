﻿// <auto-generated />
using EFCore5MuitosParaMuitos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore5MuitosParaMuitos.Migrations
{
    [DbContext(typeof(BancoContexto))]
    partial class BancoContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlunoCurso", b =>
                {
                    b.Property<int>("AlunosAlunoId")
                        .HasColumnType("int");

                    b.Property<int>("CursosCursoId")
                        .HasColumnType("int");

                    b.HasKey("AlunosAlunoId", "CursosCursoId");

                    b.HasIndex("CursosCursoId");

                    b.ToTable("AlunoCurso");

                    b.HasData(
                        new
                        {
                            AlunosAlunoId = 1,
                            CursosCursoId = 1
                        });
                });

            modelBuilder.Entity("EFCore5MuitosParaMuitos.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeAluno")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlunoId");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            AlunoId = 1,
                            NomeAluno = "Milrak"
                        });
                });

            modelBuilder.Entity("EFCore5MuitosParaMuitos.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CursoId");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            CursoId = 1,
                            CargaHoraria = 0,
                            Titulo = "EF Core"
                        });
                });

            modelBuilder.Entity("AlunoCurso", b =>
                {
                    b.HasOne("EFCore5MuitosParaMuitos.Aluno", null)
                        .WithMany()
                        .HasForeignKey("AlunosAlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore5MuitosParaMuitos.Curso", null)
                        .WithMany()
                        .HasForeignKey("CursosCursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}