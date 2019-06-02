using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class TurmaConsultaViewModel
    {
       
        public int IdTurma { get; set; }
        public string Nome { get; set; }
        public string DataInicio { get; set; }
        public int IdProfessor { get; set; }

       
    }
}