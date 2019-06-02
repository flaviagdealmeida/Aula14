using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class AlunoConsultaViewModel
    {
        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Sexo { get; set; }
        public string DataNascimento { get; set; }
    }
}