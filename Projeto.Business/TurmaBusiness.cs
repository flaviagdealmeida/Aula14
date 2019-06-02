using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.DAL;

namespace Projeto.BLL
{
    public class TurmaBusiness
    {
        //atributo
        private TurmaRepository repository;

        //construtor -> ctor + 2x[tab]
        public TurmaBusiness()
        {
            repository = new TurmaRepository();
        }

        public void CadastrarTurma(Turma turma)
        {
            repository.Insert(turma);
        }

        public void CadastrarTurmaAluno(int idTurma, int idAluno)
        {
            if (repository.HasTurmaAluno(idTurma,idAluno))
            {
                throw new Exception("Erro. O aluno já está matriculado na turma");
            }

            repository.Insert(idTurma, idAluno);
        }

        public void AtualizarTurma(Turma turma)
        {
            repository.Update(turma);
        }

        public void ExcluirTurma(int id)
        {
            repository.Delete(id);
        }

        public void ExcluirTurmaAluno(int idTurma, int idAluno)
        {
            repository.Delete(idTurma, idAluno);
        }

        public List<Turma> ConsultarTodos()
        {
            return repository.SelectAll();
        }

        public Turma ConsultarPorId(int id)
        {
            return repository.SelectById(id);
        }
    }
}
