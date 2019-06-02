using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class MatriculaCadastroViewModel
    {
        [Required(ErrorMessage ="Por Favor, informe a turma.")]
        public int IdTurma { get; set; }

        [Required(ErrorMessage = "Por Favor, informe o aluno.")]
        public int IdAluno { get; set; }
    }
}