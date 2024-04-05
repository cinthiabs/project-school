using Dapper;
using Domain.Interface;
using Entities.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class AlunoRepository : IGeneric<TableAluno>
    {
        private readonly IDbConnection _connection;

        public AlunoRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public async Task<int> Create(TableAluno entity)
        {
            string sql = "INSERT INTO aluno (nome,usuario,senha,ativo,data_criacao) VALUES (@Nome,@Usuario,@Senha,@Ativo,@Data_Criacao)";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<int> Delete(int id)
        {
            string sql = "DELETE FROM aluno WHERE id = @Id";
            return await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<int> Disable(int id)
        {
            string sql = "UPDATE aluno SET ativo=0 WHERE id = @Id";
            return await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<TableAluno>> GetAll()
        {
            string sql = "SELECT * FROM aluno";
            var result = await _connection.QueryAsync<TableAluno>(sql);
            return result;
        }

        public async Task<TableAluno> GetById(int id)
        {
            string sql = "SELECT * FROM aluno WHERE id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<TableAluno>(sql, new { Id = id });
        }

        public async Task<int> Update(TableAluno entity)
        {
            string sql = "UPDATE aluno SET nome = @Nome, senha = @Senha WHERE id = @Id";
            return await _connection.ExecuteAsync(sql, entity);
        }
    }
}
