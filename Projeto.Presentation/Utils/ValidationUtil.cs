using System;
using System.Collections; //importando
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; //importando

namespace Projeto.Presentation.Utils
{
    public class ValidationUtil
    {
        //método para retornar as mensagens de erro
        //de validação da classe ModelState
        public static Hashtable GetErrors(ModelStateDictionary modelState)
        {
            Hashtable erros = new Hashtable();

            //varrer o ModelState
            foreach(var state in modelState)
            {
                //verificar se a propriedade lida do ModelState
                //contem erros de validação
                if(state.Value.Errors.Count > 0)
                {
                    //adicionar no hashtable as mensagens de erro
                    erros[state.Key] = state.Value.Errors
                        .Select(e => e.ErrorMessage).ToList();
                }
            }

            return erros;
        }
    }
}