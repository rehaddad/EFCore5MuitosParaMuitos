using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace EFCore5MuitosParaMuitos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello EF Core 5 Muitos para Muitos!");
            //AddCursosAlunos();
            ListarCursosAlunos();

            ReadLine();
        }

        private static void ListarCursosAlunos()
        {
            WriteLine("------------ cursos e alunos");
            using (var ctx = new BancoContexto())
            {
                foreach (var curso in ctx.Cursos.Include(a => a.Alunos))
                {
                    WriteLine($"\n{curso.CursoId} - {curso.Titulo} - #{curso.Alunos.Count()}");
                    foreach (var aluno in curso.Alunos.OrderBy(n => n.NomeAluno))
                    {
                        WriteLine($"{aluno.AlunoId} {aluno.NomeAluno}");
                    }
                }
            }
        }

        private static void AddCursosAlunos()
        {
            // INSERT nas tabelas alunos e cursos
            using (var ctx = new BancoContexto())
            {
                var curso1 = new Curso { Titulo = "Blazor", CargaHoraria = 32 };
                var curso2 = new Curso { Titulo = "Power BI", CargaHoraria = 24 };
                var curso3 = new Curso { Titulo = "EF Core 5", CargaHoraria = 24 };

                ctx.AddRange(
        new Aluno { NomeAluno = "Livia", Cursos = new List<Curso> { curso1 } },
        new Aluno { NomeAluno = "Eduardo", Cursos = new List<Curso> { curso1, curso2 } },
        new Aluno { NomeAluno = "Paulo", Cursos = new List<Curso> { curso3 } }
                    );

                ctx.SaveChanges();
            }
        }
    }
}
