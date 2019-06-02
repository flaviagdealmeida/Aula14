using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.DAL;

namespace Projeto.BLL
{
    public class AlunoBusiness
    {
        //atributo..
        private AlunoRepository repository;

        //ctor + 2x[tab] -> construtor
        public AlunoBusiness()
        {
            repository = new AlunoRepository();
        }

        //método para executar o cadastro do aluno
        public void CadastrarAluno(Aluno aluno)
        {
            //verificando se a matricula ja existe..
            if(repository.HasMatricula(aluno.Matricula))
            {
                throw new Exception($"A Matricula {aluno.Matricula} já foi cadastrada no sistema.");
            }

            repository.Insert(aluno);
        }

        //método para atualizar o aluno
        public void AtualizarAluno(Aluno aluno)
        {
            repository.Update(aluno);
        }

        //método para excluir o aluno
        public void ExcluirAluno(int id)
        {
            repository.Delete(id);
        }

        //método para listar todos os alunos
        public List<Aluno> ConsultarTodos()
        {
            return repository.SelectAll();
        }

        //método para obter 1 aluno pelo id
        public Aluno ConsultarPorId(int id)
        {
            return repository.SelectById(id);
        }
    }
}
