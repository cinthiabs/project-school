using Dapper;
using Domain.Interface;
using Entities.Entities;
using System.Collections.Generic;
using System.Data;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class TurmaRepository : IGeneric<TableTurma>, IRole<TableTurma>
    {
        private readonly IDbConnection _connection;

        public TurmaRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Create(TableTurma entity)
        {
            string sql = "INSERT INTO turma (curso_id, turma, ano, ativo, data_criacao) VALUES (@Curso_Id, @Turma, @Ativo, @Ano, @Data_Criacao)";

            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<int> Delete(int id)
        {
            string sql = "DELETE FROM turma WHERE id = @Id";
            return await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<int> Disable(int id)
        {
            string sql = $"UPDATE turma SET ativo=0 WHERE id = @Id";
            return await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<TableTurma>> GetAll()
        {
            string sql = "SELECT * FROM turma";
            var result = await _connection.QueryAsync<TableTurma>(sql);
            return result; 
        }

        public async Task<TableTurma> GetById(int id)
        {
            string sql = "SELECT * FROM turma WHERE id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<TableTurma>(sql, new { Id = id });
        }
        public async Task<TableTurma> GetTurmaByName(string nome)
        {
            string sql = "SELECT * FROM turma WHERE turma = @nome";
            return await _connection.QueryFirstOrDefaultAsync<TableTurma>(sql, new { nome });
        }
        public async Task<int> Update(TableTurma entity)
        {
            string sql = "UPDATE turma SET curso_id = @Curso_Id, turma = @Turma, ano = @Ano WHERE id = @Id";
            return await _connection.ExecuteAsync(sql, entity);
        }

        Task<TableTurma> IRole<TableTurma>.GetAlunoTurmaByAlunoIdAndTurmaId(int alunoId, int turmaId)
        {
            throw new NotImplementedException();
        }
    }
}