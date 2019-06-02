using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class TurmaCadastroViewModel
    {

        [Required(ErrorMessage ="Por favor, informe o nome da turma.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de inicio da turma.")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Por favor, informe o professor da turma.")]
        public int IdProfessor { get; set; }

        public string[] AlunosSelecionados { get; set; }


    }
}