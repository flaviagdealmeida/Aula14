using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.BLL; //importando
using Projeto.Entities; //importando
using Projeto.Presentation.Models; //importando
using AutoMapper;
using Projeto.Presentation.Utils;

namespace Projeto.Presentation.Controllers
{
    public class TurmaController : Controller
    {
        private TurmaBusiness business;
       
        public TurmaController()
        {
            business = new TurmaBusiness();
        }
        // GET: Turma/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Turma/Consulta
        public ActionResult Consulta()
        {
            return View();
        }

        // GET: Turma/Matricula
        public ActionResult Matricula()
        {
            return View();
        }


        //Método para responder a requisições JavaScript
        public JsonResult CadastrarTurma(TurmaCadastroViewModel model)
        {
            try
            {
                //verificar se a model passou nas regras de validação..
                if (ModelState.IsValid)
                {
                    Turma turma = Mapper.Map<Turma>(model);

                    //varrer aluno selecionados
                    if (model.AlunosSelecionados != null && model.AlunosSelecionados.Length >0)
                    {
                        var alunoBusiness = new AlunoBusiness();
                        turma.Alunos = new List<Aluno>();

                        foreach (string idAluno in model.AlunosSelecionados)
                        {
                            //adicionar lista
                            turma.Alunos.Add(alunoBusiness.ConsultarPorId(int.Parse(idAluno)));
                        }
                    }


                    business.CadastrarTurma(turma);

                    return Json($"Turma '{turma.Nome}', cadastrado com sucesso.");
                }
                else
                {
                    Response.StatusCode = 400; //BAD REQUEST
                    return Json(ValidationUtil.GetErrors(ModelState));
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = 500; //INTERNAL SERVER ERROR
                return Json(e.Message);
            }
        }

        public JsonResult ConsultarTurmas()
        {
            try
            {
                //consultar os alunos
                List<Turma> turmas = business.ConsultarTodos();

                //convertendo para a model
                List<TurmaConsultaViewModel> model
                    = Mapper.Map<List<TurmaConsultaViewModel>>(turmas);

                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = 500; //INTERNAL SERVER ERROR
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //Método para responder a requisições JavaScript
        public JsonResult CadastrarMatricula(MatriculaCadastroViewModel model)
        {
            try
            {
                //verificar se a model passou nas regras de validação..
                if (ModelState.IsValid)
                {
                    business.CadastrarTurmaAluno(model.IdTurma, model.IdAluno) ;
                     return Json("Aluno matroculado com sucesso.");
                }
                else
                {
                    Response.StatusCode = 400; //BAD REQUEST
                    return Json(ValidationUtil.GetErrors(ModelState));
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = 500; //INTERNAL SERVER ERROR
                return Json(e.Message);
            }
        }

    }
}