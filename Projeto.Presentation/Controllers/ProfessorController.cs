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
    public class ProfessorController : Controller
    {
        //atributo
        private ProfessorBusiness business;

        //construtor -> ctor + 2x[tab]
        public ProfessorController()
        {
            business = new ProfessorBusiness();
        }

        // GET: Professor/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Professor/Consulta
        public ActionResult Consulta()
        {
            return View();
        }

        //Método para responder a requisições JavaScript
        public JsonResult CadastrarProfessor(ProfessorCadastroViewModel model)
        {
            try
            {
                //verificar se a model passou nas regras de validação..
                if (ModelState.IsValid)
                {
                    Professor professor = Mapper.Map<Professor>(model);
                    business.CadastrarProfessor(professor);

                    return Json($"Professor '{professor.Nome}', cadastrado com sucesso.");
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

        public JsonResult ConsultarProfessores()
        {
            try
            {
                //consultar os professores
                List<Professor> professores = business.ConsultarTodos();

                //convertendo para a model
                List<ProfessorConsultaViewModel> model
                    = Mapper.Map<List<ProfessorConsultaViewModel>>(professores);

                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = 500; //INTERNAL SERVER ERROR
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}