using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.DAL;
using Projeto.Util;
using Projeto.Util.Models;
using Projeto.Util.Services;

namespace Projeto.BLL
{
    public class ProfessorBusiness
    {
        //atributo..
        private ProfessorRepository repository;

        //ctor + 2x[tab] -> construtor
        public ProfessorBusiness()
        {
            repository = new ProfessorRepository();
        }

        //método para executar o cadastro do professor
        public void CadastrarProfessor(Professor professor)
        {
            if(repository.HasEmail(professor.Email))
            {
                throw new Exception($"O email {professor.Email} já encontra-se cadastrado no sistema.");
            }

            repository.Insert(professor);
            EnviarEmailDeConfirmacaoDeCadastro(professor);
        }

        //método para atualizar o professor
        public void AtualizarProfessor(Professor professor)
        {
            repository.Update(professor);
        }

        //método para excluir o professor
        public void ExcluirProfessor(int id)
        {
            repository.Delete(id);
        }

        //método para listar todos os professores
        public List<Professor> ConsultarTodos()
        {
            return repository.SelectAll();
        }

        //método para obter 1 professor pelo id
        public Professor ConsultarPorId(int id)
        {
            return repository.SelectById(id);
        }

        public void EnviarEmailDeConfirmacaoDeCadastro(Professor professor)
        {
            EmailModel model = new EmailModel();

            model.To = professor.Email;

            model.Subject = "Cadastro realizado com sucesso!";

            model.Body = $"Olá <strong>{professor.Nome}</strong>"
                       + "<br/><br/>"
                       + "Sua conta de professor foi criada com sucesso!"
                       + "<br/><br/>"
                       + "Atenciosamente,<br/>"
                       + "Sistema de Controle de Turmas";

            model.IsHtml = true;

            //enviando o email
            EmailService.Send(model);
        }
    }
}
