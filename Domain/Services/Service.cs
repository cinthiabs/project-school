using Domain.Interface;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class Service
    {
        private readonly IGeneric<TableAluno> _alunoRepository;
        private readonly IGeneric<TableTurma> _turmaRepository;
        private readonly IGeneric<TableAluno_Turma> _alunoTurmaRepository;
        private readonly IRole<TableAluno_Turma> _roleAluno_Turma;
        private readonly IRole<TableTurma> _roleTurma;

        public Service(IGeneric<TableAluno> alunoRepository, IGeneric<TableTurma> turmaRepository, IRole<TableTurma> roleTurma,IRole<TableAluno_Turma> roleAluno_Turma, IGeneric<TableAluno_Turma> alunoTurmaRepository )
        {
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;
            _roleAluno_Turma = roleAluno_Turma;
            _roleTurma = roleTurma;
            _alunoTurmaRepository = alunoTurmaRepository;
        }
        public async Task<TableAluno_Turma> GetAlunoTurmaByAlunoIdAndTurmaId(int alunoId, int turmaId)
        {
            return await _roleAluno_Turma.GetAlunoTurmaByAlunoIdAndTurmaId(alunoId, turmaId);
        }
        public async Task<TableTurma> GetTurmaByName(string nome)
        {     
            return await _roleTurma.GetTurmaByName(nome);
        }
        public async Task<IEnumerable<TableAluno>> GetAllAlunos()
        {
            return await _alunoRepository.GetAll();
        }

        public async Task<TableAluno> GetAlunoById(int id)
        {
            return await _alunoRepository.GetById(id);
        }

        public async Task<int> CreateAluno(TableAluno aluno)
        {
            return await _alunoRepository.Create(aluno);
        }

        public async Task<int> UpdateAluno(TableAluno aluno)
        {
            return await _alunoRepository.Update(aluno);
        }

        public async Task<int> DeleteAluno(int id)
        {
            return await _alunoRepository.Delete(id);
        }
        public async Task<int> DisableAluno(int id)
        {
            return await _alunoRepository.Disable(id);
        }

        public async Task<int> DisableTurma(int id)
        {
            return await _turmaRepository.Disable(id);
        }

        public async Task<IEnumerable<TableTurma>> GetAllTurmas()
        {
            return await _turmaRepository.GetAll();
        }

        public async Task<TableTurma> GetTurmaById(int id)
        {
            return await _turmaRepository.GetById(id);
        }

        public async Task<int> CreateTurma(TableTurma turma)
        {
            return await _turmaRepository.Create(turma);
        }

        public async Task<int> UpdateTurma(TableTurma turma)
        {
            return await _turmaRepository.Update(turma);
        }

        public async Task<int> DeleteTurma(int id)
        {
            return await _turmaRepository.Delete(id);
        }


        public async Task<int> DisableAluno_Turma(int id)
        {
            return await _alunoTurmaRepository.Disable(id);
        }

        public async Task<IEnumerable<TableAluno_Turma>> GetAllAluno_Turma()
        {
            return await _alunoTurmaRepository.GetAll();
        }

        public async Task<TableAluno_Turma> GetAluno_TurmaById(int id)
        {
            return await _alunoTurmaRepository.GetById(id);
        }

        public async Task<int> CreateAluno_Turma(TableAluno_Turma turma)
        {
            return await _alunoTurmaRepository.Create(turma);
        }

        public async Task<int> UpdateAluno_Turma(TableAluno_Turma turma)
        {
            return await _alunoTurmaRepository.Update(turma);
        }

        public async Task<int> DeleteAluno_Turma(int id)
        {
            return await _alunoTurmaRepository.Delete(id);
        }


    }
}
