using Domain.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace project_school.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Aluno_TurmaController : ControllerBase
    {
        private readonly Service _service;
        public Aluno_TurmaController(Service escolaService)
        {
            _service = escolaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAluno_Turma()
        {
            var turmas = await _service.GetAllAluno_Turma();
            return Ok(turmas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAluno_TurmaById(int id)
        {
            var turma = await _service.GetAluno_TurmaById(id);
            if (turma == null)
                return NotFound($"Turma com ID {id} não encontrado.");

            return Ok(turma);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAluno_Turma(TableAluno_Turma turma)
        {

            var existingRelation = await _service.GetAlunoTurmaByAlunoIdAndTurmaId(turma.Aluno_Id, turma.Turma_Id);
            if (existingRelation != null)
            {
                return BadRequest($"O aluno com ID '{turma.Aluno_Id}' já está associado à turma com ID '{turma.Turma_Id}'.");
            }


            await _service.CreateAluno_Turma(turma);
            return CreatedAtAction(nameof(GetAluno_TurmaById), new { id = turma.Turma_Id }, turma);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAluno_Turma(int id, TableAluno_Turma turma)
        {
            var existe = await _service.GetAluno_TurmaById(id);
            if (existe == null)
                return NotFound($" ID {id} não encontrado.");

            turma.Id = id;
            await _service.UpdateAluno_Turma(turma);
            return Ok("Registro Atualizado!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno_Turma(int id)
        {
            var existe = await _service.GetAluno_TurmaById(id);
            if (existe == null)
                return NotFound($"Turma com ID {id} não encontrado.");

            await _service.DeleteAluno_Turma(id);
            return Ok("Registro Excluido!");
        }
        [HttpPut("Disable/{id}")]
        public async Task<IActionResult> Disable(int id)
        {
            var aluno = await _service.GetAluno_TurmaById(id);
            if (aluno == null)
                return NotFound($"Turma com ID {id} não encontrado.");

            await _service.DisableAluno_Turma(id);
            return Ok($"Turma com ID {id} desabilitado com sucesso.");
        }

    }
}
