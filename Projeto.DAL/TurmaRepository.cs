using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using Projeto.Entities;

namespace Projeto.DAL
{
    public class TurmaRepository
    {
        //atributo
        private string connectionString;

        //construtor -> ctor + 2x[tab]
        public TurmaRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings
                                ["projeto"].ConnectionString;
        }

        //método para inserir uma nova turma
        public void Insert(Turma turma)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                //abrindo uma transação com a base de dados
                SqlTransaction transaction = conn.BeginTransaction();

                string query = string.Empty;

                try
                {
                    query = "insert into Turma(Nome, DataInicio, IdProfessor) "
                          + "values(@Nome, @DataInicio, @IdProfessor) "
                          + "select scope_identity()";

                    //executando e retornando o id da turma
                    turma.IdTurma = conn.QuerySingleOrDefault<int>(query, turma, transaction);

                    //verificar se turma contem alunos
                    if(turma.Alunos != null && turma.Alunos.Count > 0)
                    {
                        query = "insert into TurmaAluno(IdTurma, IdAluno) "
                              + "values(@IdTurma, @IdAluno)";

                        foreach(Aluno aluno in turma.Alunos)
                        {
                            conn.Execute(query, new { turma.IdTurma, aluno.IdAluno },
                                            transaction);
                        }
                    }

                    transaction.Commit();
                }
                catch(Exception e)
                {
                    transaction.Rollback();
                    throw new Exception(e.Message);
                }
            }
        }

        //método para gravar na tabela associativa
        public void Insert(int idTurma, int idAluno)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "insert into TurmaAluno(IdTurma, IdAluno) "
                             + "values(@IdTurma, @IdAluno)";

                conn.Execute(query, new { IdTurma = idTurma, IdAluno = idAluno });
            }
        }

        //método para atualizar os dados da turma
        public void Update(Turma turma)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "update Turma set Nome = @Nome, DataInicio = @DataInicio, "
                             + "IdProfessor = @IdProfessor where IdTurma = @IdTurma";

                conn.Execute(query, turma);
            }
        }

        //método para excluir Turma
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "delete from Turma where IdTurma = @IdTurma";

                conn.Execute(query, new { IdTurma = id });
            }
        }

        //método para excluir um registro na tabela associativa
        public void Delete(int idTurma, int idAluno)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "delete from TurmaAluno "
                             + "where IdTurma = @IdTurma and IdAluno = @IdAluno";

                conn.Execute(query, new { IdTurma = idTurma, IdAluno = idAluno });
            }
        }

        //método para listar todas as turmas
        public List<Turma> SelectAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select * from Turma t inner join Professor p "
                             + "on p.IdProfessor = t.IdProfessor";

                return conn.Query(query,
                        (Turma t, Professor p) =>
                        {
                            t.Professor = p; //relacionamento
                            return t;
                        },
                        splitOn: "IdProfessor" //chave estrangeira
                    ).ToList();
            }
        }

        //método para retornar 1 turma pelo id
        public Turma SelectById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select * from Turma t inner join Professor p "
                             + "on p.IdProfessor = t.IdProfessor "
                             + "where IdTurma = @IdTurma";

                return conn.Query(query,                        
                        (Turma t, Professor p) =>
                        {
                            t.Professor = p; //relacionamento
                            return t;
                        },
                        new { IdTurma = id },
                        splitOn: "IdProfessor" //chave estrangeira                        
                    ).SingleOrDefault();
            }
        }

        //metodo verificar se uma turma ja possui um aluno matriculado
        public bool HasTurmaAluno(int idTurma, int idAluno)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select count(*) from TurmaAluno where IdTurma = @IdTurma and IdAluno = @IdAluno";
                return conn.QuerySingleOrDefault<int>(query, new { IdTurma = idTurma, IdAluno = idAluno }) > 0;
            }

        }
    }
}
