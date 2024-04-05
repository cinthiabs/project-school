using Domain.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace project_school.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly Service _service;

        public AlunoController(Service escolaService)
        {
            _service = escolaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlunos()
        {
            var alunos = await _service.GetAllAlunos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlunoById(int id)
        {
            var aluno = await _service.GetAlunoById(id);

            if (aluno == null)
            {
                return NotFound($"Aluno com ID {id} não encontrado.");
            }
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAluno(TableAluno aluno)
        {
            if (!IsStrongPassword(aluno.Senha))
            {
                return BadRequest("A senha deve ter pelo menos 8 caracteres, uma letra minúscula, uma letra maiúscula e um caractere especial.");
            }

            string hashedPassword = Hash(aluno.Senha);
            aluno.Senha = hashedPassword;

            await _service.CreateAluno(aluno);

            return CreatedAtAction(nameof(GetAlunoById), new { id = aluno.Id }, aluno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAluno(int id, TableAluno aluno)
        {
            var existe = await _service.GetAlunoById(id);
            if (existe == null)
                return NotFound($"Aluno com ID {id} não encontrado.");

            aluno.Id = id;
            await _service.UpdateAluno(aluno);
            return Ok("Registro Atualizado!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _service.GetAlunoById(id);
            if (aluno == null)
                return NotFound($"Aluno com ID {id} não encontrado.");

            await _service.DeleteAluno(id);
            return Ok($"Aluno com ID {id} excluido com sucesso.");
        }

        [HttpPut("Disable/{id}")]
        public async Task<IActionResult> Disable(int id)
        {
            var aluno = await _service.GetAlunoById(id);
            if (aluno == null)
                return NotFound($"Aluno com ID {id} não encontrado.");

            await _service.DisableAluno(id);
            return Ok($"Aluno com ID {id} desabilitado com sucesso.");
        }
        private string Hash(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(senha);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
        private bool IsStrongPassword(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                return false;

            int requiredLength = 8;
            bool requireDigit = true;
            bool requireLowercase = true;
            bool requireUppercase = true;
            bool requireNonAlphanumeric = true;

            if (senha.Length < requiredLength)
                return false;

            if (requireDigit && !senha.Any(char.IsDigit))
                return false;

            if (requireLowercase && !senha.Any(char.IsLower))
                return false;

            if (requireUppercase && !senha.Any(char.IsUpper))
                return false;

            if (requireNonAlphanumeric && senha.All(char.IsLetterOrDigit))
                return false;

            return true;
        }
        public static string Decrypt(string encryptedText)
        {
            byte[] bytes = Convert.FromBase64String(encryptedText);

            string originalSenha = Encoding.UTF8.GetString(bytes);

            return originalSenha;
        }

    }
}
