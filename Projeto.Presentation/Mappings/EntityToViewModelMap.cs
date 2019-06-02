using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Entities;
using Projeto.Presentation.Models;
using AutoMapper;

namespace Projeto.Presentation.Mappings
{
    public class EntityToViewModelMap : Profile
    {
        public EntityToViewModelMap()
        {
            CreateMap<Aluno, AlunoConsultaViewModel>()
                .AfterMap((src, dest)
                => {
                    dest.DataNascimento = src.DataNascimento.ToString("dd/MM/yyyy");
                })
                .AfterMap((src, dest)
                => {
                    dest.Sexo = src.Sexo.Equals("F") ? "Feminino"
                              : src.Sexo.Equals("M") ? "Masculino"
                              : string.Empty;
                });

            CreateMap<Professor, ProfessorConsultaViewModel>();

            CreateMap<Turma, TurmaConsultaViewModel>()
               .AfterMap((src, dest)
               => {
                   dest.DataInicio = src.DataInicio.ToString("dd/MM/yyyy");
               });


        }
    }
}