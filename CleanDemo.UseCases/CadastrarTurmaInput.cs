using System;

namespace CleanDemo.UseCases
{
    public class CadastrarTurmaInput
    {
        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }

        public int ProfessorId { get; set; }

        public int CursoId { get; set; }

    }
}