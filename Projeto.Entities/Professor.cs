using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Professor
    {
        public int IdProfessor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        //Relacionamento
        public List<Turma> Turmas { get; set; }

        public Professor()
        {

        }

        //sobrecarga de construtores (overloading)
        public Professor(int idProfessor, string nome, string email)
        {
            IdProfessor = idProfessor;
            Nome = nome;
            Email = email;
        }

        //sobrescrita do método ToString()
        public override string ToString()
        {
            return $"Id: {IdProfessor}, Nome: {Nome}, Email: {Email}";
        }
    }
}
