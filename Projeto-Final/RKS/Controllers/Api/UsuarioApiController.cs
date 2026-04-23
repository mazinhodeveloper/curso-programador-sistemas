using Microsoft.AspNetCore.Mvc;
using API.Data.Models;
using API.Models;
using API.Repositories;
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

namespace API.Controllers.Api
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioApiController : ControllerBase
    {
        private readonly IRepositoryUSUARIO _repository;
        private const string ApiKey = "MangaRosa_Com_Leite_Mata_Todos_kkk@2026";

        public UsuarioApiController(IRepositoryUSUARIO repository)
        {
            _repository = repository;
        }

        private string ComputeSha256Hash(string rawData)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return Convert.ToHexString(bytes).ToLower();
        }

        // POST: api/usuario/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModelUsuario model)
        {
            try
            {
                string passSha = ComputeSha256Hash(model.senha);
                string phoneSha = ComputeSha256Hash(model.numeroTelefone);
                string combined = passSha + ApiKey + phoneSha;
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(combined);

                var novoUsuario = new USUARIO
                {
                    nome = model.nome,
                    CPF = model.CPF,
                    numeroTelefone = model.numeroTelefone,
                    dataNascimento = model.dataNascimento,
                    senha = hashedPassword,
                    idAcl = 3,        // Cliente
                    idStatus = 1,     // Ativo (adjust according to your STATUS table)
                    idPerfil = 2,     // Comum
                    verificacao = "000000"
                };

                await _repository.CreateUsuarioAsync(novoUsuario);

                return Ok(new
                {
                    erro = false,
                    message = "Usuário cadastrado com sucesso!",
                    usuario = new { nome = model.nome, numeroTelefone = model.numeroTelefone }
                });
            }
            catch (Exception ex) when (ex.InnerException?.Message.Contains("duplicate") == true)
            {
                return Conflict(new { erro = true, message = "Telefone ou CPF já está em uso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = true, message = "Erro interno no servidor", detalhe = ex.Message });
            }
        }

        // POST: api/usuario/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModelUsuario model)
        {
            try
            {
                var user = await _repository.GetUsuarioByTelefoneAsync(model.numeroTelefone);

                if (user == null)
                    return Unauthorized(new { erro = true, message = "Telefone ou senha inválidos!" });

                string passSha = ComputeSha256Hash(model.senha);
                string phoneSha = ComputeSha256Hash(model.numeroTelefone);
                string combined = passSha + ApiKey + phoneSha;

                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(combined, user.senha);

                if (!isPasswordValid)
                    return Unauthorized(new { erro = true, message = "Telefone ou senha inválidos!" });

                return Ok(new
                {
                    erro = false,
                    message = "Login realizado com sucesso!",
                    usuario = new { id = user.idUsuario, nome = user.nome, telefone = user.numeroTelefone }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = true, message = ex.Message });
            }
        }

        // PUT: api/usuario/change-password
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestModelUsuario model)
        {
            try
            {
                var user = await _repository.GetUsuarioByTelefoneAsync(model.numeroTelefone);
                if (user == null)
                    return Unauthorized(new { erro = true, message = "Usuário não encontrado!" });

                // Validate current password
                string currentPassSha = ComputeSha256Hash(model.senha);
                string phoneSha = ComputeSha256Hash(model.numeroTelefone);
                string currentCombined = currentPassSha + ApiKey + phoneSha;

                if (!BCrypt.Net.BCrypt.Verify(currentCombined, user.senha))
                    return Unauthorized(new { erro = true, message = "Senha atual incorreta!" });

                // Hash new password
                string newPassSha = ComputeSha256Hash(model.novaSenha);
                string newCombined = newPassSha + ApiKey + phoneSha;
                string newHashedPassword = BCrypt.Net.BCrypt.HashPassword(newCombined);

                bool sucesso = await _repository.UpdateSenhaAsync(model.numeroTelefone, newHashedPassword);

                if (sucesso)
                    return Ok(new { erro = false, message = "Senha alterada com sucesso!" });

                return BadRequest(new { erro = true, message = "Não foi possível atualizar a senha." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = true, message = ex.Message });
            }
        }
    }
}