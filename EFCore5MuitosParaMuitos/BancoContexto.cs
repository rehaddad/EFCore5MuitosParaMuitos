using Microsoft.EntityFrameworkCore;
using System;

namespace EFCore5MuitosParaMuitos
{
    public class BancoContexto : DbContext
    {
        public BancoContexto() { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=EARTH;Initial Catalog=ArtigoEFCoreRelacaoNN;Integrated Security=True");

            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuração de tipo de entidade de junção
            modelBuilder
                .Entity<Aluno>()
                .HasMany(a => a.Cursos)
                .WithMany(a => a.Alunos)
                .UsingEntity(j => j.ToTable("AlunoCurso"));

            // add curso e aluno
            modelBuilder.Entity<Curso>()
                .HasData(new Curso { CursoId = 1, Titulo = "EF Core" });

            modelBuilder.Entity<Aluno>()
                .HasData(new Aluno { AlunoId = 1, NomeAluno = "Milrak" });

            modelBuilder.Entity<Curso>()
                .HasMany(a => a.Alunos)
                .WithMany(a => a.Cursos)
                .UsingEntity(j => j.HasData(new { CursosCursoId = 1, AlunosAlunoId = 1 }));
        }
    }
}