using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Aluno
    {
        //propriedades..
        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }

        //Relacionamento
        public List<Turma> Turmas { get; set; }

        //ctor + 2x[tab] -> construtor
        public Aluno()
        {
            //vazio (default)
        }

        //sobrecarga de construtores
        public Aluno(int idAluno, string nome, string matricula, string sexo, DateTime dataNascimento)
        {
            IdAluno = idAluno;
            Nome = nome;
            Matricula = matricula;
            Sexo = sexo;
            DataNascimento = dataNascimento;
        }

        //sobrescrita do método ToString()
        public override string ToString()
        {
            return $"Id: {IdAluno}, Nome: {Nome}, Matricula: {Matricula}, Sexo: {Sexo}, Data Nasc: {DataNascimento}";
        }
    }
}
