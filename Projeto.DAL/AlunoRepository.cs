using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Projeto.Entities;
using System.Data.SqlClient;
using Dapper;

namespace Projeto.DAL
{
    public class AlunoRepository
    {
        //atributo
        private string connectionString;

        //ctor + 2x[tab]
        public AlunoRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                                ["projeto"].ConnectionString;
        }

        //método para inserir um aluno na base de dados
        public void Insert(Aluno aluno)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "insert into Aluno(Nome, Matricula, Sexo, DataNascimento) "
                             + "values(@Nome, @Matricula, @Sexo, @DataNascimento)";

                //executar o comando sql..
                conn.Execute(query, aluno);
            }
        }

        //método para atualizar um aluno na base de dados
        public void Update(Aluno aluno)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "update Aluno set Nome = @Nome, Matricula = @Matricula, Sexo = @Sexo, "
                             + "DataNascimento = @DataNascimento where IdAluno = @IdAluno";

                //executar o comando sql..
                conn.Execute(query, aluno);
            }
        }

        //método para excluir um aluno na base de dados
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "delete from Aluno where IdAluno = @IdAluno";

                //executar o comando sql..
                conn.Execute(query, new { IdAluno = id });
            }
        }

        //método para listar todos os alunos
        public List<Aluno> SelectAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select * from Aluno";

                return conn.Query<Aluno>(query).ToList();
            }
        }

        //método para obter 1 Aluno pelo id
        public Aluno SelectById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select * from Aluno where IdAluno = @IdAluno";

                return conn.QuerySingleOrDefault<Aluno>(query, new { IdAluno = id });
            }
        }

        //método para verificar se uma matricula já
        //está cadastrada na base de dados
        public bool HasMatricula(string matricula)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select count(Matricula) from Aluno where Matricula = @Matricula";

                return conn.QuerySingleOrDefault<int>(query, new { Matricula = matricula }) > 0;
            }
        }

    }
}
