﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class ProfessorCadastroViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do professor.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do professor.")]
        public string Email { get; set; }
    }
}