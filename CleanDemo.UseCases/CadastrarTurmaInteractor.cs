using System.Linq;
using CleanDemo.Core;
using CleanDemo.Entities;

namespace CleanDemo.UseCases
{
    public class CadastrarTurmaInteractor : IInteraction<CadastrarTurmaInput, CadastrarTurmaOutput>
    {
        private readonly IRepository<Turma> _turmaRepository;
        private readonly IRepository<Professor> _professorRepository;
        private readonly IRepository<Curso> _cursoRepository;

        public CadastrarTurmaInteractor(IRepository<Turma> turmaRepository, IRepository<Professor> professorRepository, IRepository<Curso> cursoRepository)
        {
            _turmaRepository = turmaRepository;
            _professorRepository = professorRepository;
            _cursoRepository = cursoRepository;
        }

        public CadastrarTurmaOutput Handle(CadastrarTurmaInput input)
        {
            //0 - Foi fornecido parâmetro?
            if (input == null)
                return new CadastrarTurmaOutput {Status = -1, Mensagem = $"O parâmetro {nameof(input)} não pode ser nulo"};

            //1 - Curso existe?
            Curso curso = _cursoRepository.Get(input.CursoId);
            if(curso == null)
                return new CadastrarTurmaOutput { Status = -2, Mensagem = $"Não há curso com o Id {input.CursoId}" };

            //2 - Professor Existe?
            Professor professor = _professorRepository.Get(input.ProfessorId);
            if (professor == null)
                return new CadastrarTurmaOutput { Status = -3, Mensagem = $"Não há professor com o Id {input.ProfessorId}" };

            //3 - Existe outra turma nesta data?
            if (_turmaRepository.All.Any(t => t.DataInicio == input.DataInicio))
                return new CadastrarTurmaOutput { Status = -4, Mensagem = $"Há outra turma iniciando em {input.DataInicio}" };

            //4 - Nome foi preenchido?
            if (input.Nome == null)
                return new CadastrarTurmaOutput { Status = -5, Mensagem = $"O parâmetro {nameof(input.Nome)} não pode ser nulo" };

            // Cria uma nova turma
            int turmaId = _turmaRepository.Save(new Turma
            {
                CursoId = input.CursoId,
                ProfessorId = input.ProfessorId,
                Nome = input.Nome,
                DataInicio = input.DataInicio
            });

            //Retorna o resultado
            return new CadastrarTurmaOutput { Sucesso = true, TurmaId = turmaId};
        }
    }
}
