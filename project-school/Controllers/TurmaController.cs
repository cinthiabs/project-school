using Domain.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace project_school.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly Service _service;

        public TurmaController(Service escolaService)
        {
            _service = escolaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTurmas()
        {
            var turmas = await _service.GetAllTurmas();
            return Ok(turmas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTurmaById(int id)
        {
            var turma = await _service.GetTurmaById(id);
            if (turma == null)
                return NotFound($"Turma com ID {id} não encontrado.");

            return Ok(turma);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTurma(TableTurma turma)
        {
            if (turma.Data_Criacao < DateTime.Now)
                return BadRequest("A data de criação da turma não pode ser anterior à data atual.");
            
            var existingTurma = await _service.GetTurmaByName(turma.Turma);
            
            if (existingTurma != null)
                return BadRequest($"Já existe uma turma com o nome '{turma.Turma}'.");

            await _service.CreateTurma(turma);
            return CreatedAtAction(nameof(GetTurmaById), new { id = turma.Id }, turma);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTurma(int id, TableTurma turma)
        {
            var existe = await _service.GetTurmaById(id);
            if (existe == null)
                return NotFound($"Turma com ID {id} não encontrado.");
            
            turma.Id = id;
            await _service.UpdateTurma(turma);
            return Ok("Registro Atualizado!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            var existe = await _service.GetTurmaById(id);
            if (existe == null)
                return NotFound($"Turma com ID {id} não encontrado.");

            await _service.DeleteTurma(id);
            return Ok("Registro Excluido!");
        }
        [HttpPut("Disable/{id}")]
        public async Task<IActionResult> Disable(int id)
        {
            var aluno = await _service.GetTurmaById(id);
            if (aluno == null)
                return NotFound($"Turma com ID {id} não encontrado.");

            await _service.DisableTurma(id);
            return Ok($"Turma com ID {id} desabilitado com sucesso.");
        }

    }
}
