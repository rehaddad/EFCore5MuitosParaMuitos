using System.Collections.Generic;

namespace EFCore5MuitosParaMuitos
{
    // exemplo de relações N-N no EF Core 5
    public class Curso
    {
        public int CursoId { get; set; }
        public string Titulo { get; set; }
        public int CargaHoraria { get; set; }
        public ICollection<Aluno> Alunos { get; set; }

    }

    public class Aluno
    {
        public int AlunoId { get; set; }
        public string NomeAluno { get; set; }
        public ICollection<Curso> Cursos { get; set; }
    }
}
