using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Entities;
using Projeto.Presentation.Models;
using AutoMapper;

namespace Projeto.Presentation.Mappings
{
    public class ViewModelToEntityMap : Profile
    {
        //construtor
        public ViewModelToEntityMap()
        {
            CreateMap<AlunoCadastroViewModel, Aluno>();
            CreateMap<ProfessorCadastroViewModel, Professor>();
            CreateMap<TurmaCadastroViewModel, Turma>();
        }
    }
}