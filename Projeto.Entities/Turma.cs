using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Turma
    {
        public int IdTurma { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }

        public int IdProfessor { get; set; } //Foreign Key

        //Relacionamentos 
        public Professor Professor { get; set; }
        public List<Aluno> Alunos { get; set; }

        public Turma()
        {

        }

        public Turma(int idTurma, string nome, DateTime dataInicio)
        {
            IdTurma = idTurma;
            Nome = nome;
            DataInicio = dataInicio;
        }

        public override string ToString()
        {
            return $"Id: {IdTurma}, Nome: {Nome}, Data de Início: {DataInicio}";
        }
    }
}
