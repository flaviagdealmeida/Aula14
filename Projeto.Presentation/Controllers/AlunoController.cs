using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Presentation.Models; //importando
using Projeto.Entities; //importando
using Projeto.BLL; //importando
using AutoMapper;
using Projeto.Presentation.Utils; //importando

namespace Projeto.Presentation.Controllers
{
    public class AlunoController : Controller
    {
        //atributo
        private AlunoBusiness business;

        //ctor + 2x[tab] -> construtor
        public AlunoController()
        {
            business = new AlunoBusiness();
        }

        // GET: Aluno/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Aluno/Consulta
        public ActionResult Consulta()
        {
            return View();
        }

        //Método para responder a requisições JavaScript
        public JsonResult CadastrarAluno(AlunoCadastroViewModel model)
        {
            try
            {
                //verificar se a model passou nas regras de validação..
                if(ModelState.IsValid)
                {
                    Aluno aluno = Mapper.Map<Aluno>(model);
                    business.CadastrarAluno(aluno);

                    return Json($"Aluno '{aluno.Nome}', cadastrado com sucesso.");
                }
                else
                {
                    Response.StatusCode = 400; //BAD REQUEST
                    return Json(ValidationUtil.GetErrors(ModelState));
                }
            }
            catch(Exception e)
            {
                Response.StatusCode = 500; //INTERNAL SERVER ERROR
                return Json(e.Message);
            }
        }

        public JsonResult ConsultarAlunos()
        {
            try
            {
                //consultar os alunos
                List<Aluno> alunos = business.ConsultarTodos();

                //convertendo para a model
                List<AlunoConsultaViewModel> model
                    = Mapper.Map<List<AlunoConsultaViewModel>>(alunos);

                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                Response.StatusCode = 500; //INTERNAL SERVER ERROR
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

    }
}