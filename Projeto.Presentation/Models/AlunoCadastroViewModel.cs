using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //validações

namespace Projeto.Presentation.Models
{
    public class AlunoCadastroViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do aluno.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a matrícula do aluno.")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Por favor, informe o sexo do aluno.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do aluno.")]
        public DateTime DataNascimento { get; set; }
    }
}