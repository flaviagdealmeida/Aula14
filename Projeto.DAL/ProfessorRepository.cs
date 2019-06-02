using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //importando
using System.Configuration; //importando
using Dapper; //importando
using Projeto.Entities; //importando

namespace Projeto.DAL
{
    public class ProfessorRepository
    {
        //atributo
        private string connectionString;

        //ctor + 2x[tab]
        public ProfessorRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                                ["projeto"].ConnectionString;
        }

        //método para inserir um professor na base de dados
        public void Insert(Professor professor)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "insert into Professor(Nome, Email) "
                             + "values(@Nome, @Email)";

                //executar o comando sql..
                conn.Execute(query, professor);
            }
        }

        //método para atualizar um professor na base de dados
        public void Update(Professor professor)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "update Professor set Nome = @Nome, Email = @Email "
                             + "where IdProfessor = @IdProfessor";

                //executar o comando sql..
                conn.Execute(query, professor);
            }
        }

        //método para excluir um professor na base de dados
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "delete from Professor where IdProfessor = @IdProfessor";

                //executar o comando sql..
                conn.Execute(query, new { IdProfessor = id });
            }
        }

        //método para listar todos os professores
        public List<Professor> SelectAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select * from Professor";

                return conn.Query<Professor>(query).ToList();
            }
        }

        //método para obter 1 Professor pelo id
        public Professor SelectById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select * from Professor where IdProfessor = @IdProfessor";

                return conn.QuerySingleOrDefault<Professor>(query, new { IdProfessor = id });
            }
        }

        //método para verificar se um Email já está cadastrado
        public bool HasEmail(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select count(Email) from Professor where Email = @Email";

                return conn.QuerySingleOrDefault<int>(query, new { Email = email }) > 0;
            }
        }

    }
}
