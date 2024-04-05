using Dapper;
using Domain.Interface;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class Aluno_TurmaRepository : IGeneric<TableAluno_Turma>, IRole<TableAluno_Turma>
    {
        private readonly IDbConnection _connection;

        public Aluno_TurmaRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> Create(TableAluno_Turma entity)
        {
            string sql = "INSERT INTO aluno_turma(aluno_id,turma_id,ativo,data_criacao)values(@Aluno_Id,@Turma_Id,@Ativo,@Data_Criacao)";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<int> Delete(int id)
        {
            string sql = "DELETE FROM aluno_turma WHERE id = @Id";
            return await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<int> Disable(int id)
        {
            string sql = "UPDATE aluno_turma SET ativo=0 WHERE id = @Id";
            return await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<TableAluno_Turma>> GetAll()
        {
            string sql = "SELECT * FROM aluno_turma";
            var result = await _connection.QueryAsync<TableAluno_Turma>(sql);
            return result;
        }

        public async Task<TableAluno_Turma> GetAlunoTurmaByAlunoIdAndTurmaId(int alunoId, int turmaId)
        {
            string sql = "SELECT * FROM aluno_turma WHERE aluno_id = @alunoId AND turma_id = @turmaId";
            return await _connection.QueryFirstOrDefaultAsync<TableAluno_Turma>(sql, new { alunoId, turmaId });
        }

        public async Task<TableAluno_Turma> GetById(int id)
        {
            string sql = "SELECT * FROM aluno_turma WHERE id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<TableAluno_Turma>(sql, new { Id = id });
        }

        public Task<TableAluno_Turma> GetTurmaByName(string nome)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(TableAluno_Turma entity)
        {
            string sql = "UPDATE aluno_turma SET aluno_id = @Aluno_Id, turma_id = @Turma_Id WHERE id = @Id";
            return await _connection.ExecuteAsync(sql, entity);
        }
    }
}
