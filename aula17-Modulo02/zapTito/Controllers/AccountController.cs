/* -- Controllers/AccountController.cs */
using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
//using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

// Elementos para criptografia 
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

// Usar o banco de dados com DBUsuario e os atributos da classe usuario 
using BdUsuario = zapTito.Data.Models.Usuario;
using Microsoft.AspNetCore.Identity.Data;

using zapTito.Data.Models;
using zapTito.Repositories;
using zapTito.Models;

namespace zapTito.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AccountController : ControllerBase
    {
        private readonly RepositoryUsuario _repositoryUsuario;

        public AccountController(RepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        /*** MÉTODO DE REGISTRO DE NOVO USUÁRIO ***/
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModelUsuario model)
        {
            try
            {
                // Criptografia 

                // Chave mestre 
                string ApiKey = "MangaRosa_Com_Leite_Mata_Todos_kkk@2026"; // Texto mestre 

                // 1. Aplicando SHA256 para Telefone e senha 
                string PassSHA256 = ComputerSha256Hash(model.senha);
                string PhoneSHA256 = ComputerSha256Hash(model.numeroTelefone);

                // 2. Aplicando o BCript 
                // 3. Criando a string para criptografia (Salt) 
                string PassCrip = PassSHA256 + ApiKey + PhoneSHA256;
                // 4. Criptografando 
                string PassBCript = BCrypt.Net.BCrypt.HashPassword(PassCrip);

                // 5. Criando Objeto para gravar no banco de dados 
                var novoUsuario = new BdUsuario
                {
                    nome = model.nome,
                    numeroTelefone = model.numeroTelefone,
                    senha = PassBCript,
                    dataNascimento = model.dataNascimento,
                    idACL = 3, // ACL de cliente
                    idStatus = 2, // Ativo 
                    idPerfil = 3, // de Uso comum 
                    verificacao = "000000"
                };

                await _repositoryUsuario.CreateUsuarioAsync(novoUsuario);

                return Ok(new
                {
                    erro = false,
                    message = "Usuário do zapTito cadastrado com sucesso!",
                    usuario = new
                    {
                        model.nome,
                        model.numeroTelefone,
                        PassBCript
                    }
                });
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                return Conflict(new
                {
                    erro = true,
                    message = "Este telefone já está em uso!"
                });
            } 
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    erro = true,
                    message = "Erro no servidor ",
                    detalhe = ex.Message
                });
            }
        }

        /*** MÉTODO DE LOGIN DE USUÁRIO ***/
        [HttpPost("login")]
        //[HttpGet("login")]
        // OU método GET porem ele deve ser passado algo que seja de valor único no banco de dados 
        public async Task<IActionResult> Login([FromBody] LoginRequestModelUsuario model)
        {
            try
            {
                // 1. Busca o usuário no banco de dados pelo telefone 
                var user = await _repositoryUsuario.GetUsuarioByTelefoneAsync(model.numeroTelefone);
                // Se não encontrar o usuário 
                if (user == null)
                {
                    return Unauthorized(new
                    {
                        erro = true, 
                        message = "Telefone ou senha inválidos!" 
                    }); 
                }

                // 2. Recria a lógica de Hash da senha para comparar 
                // Usamos a mesma 'chave mestre' que foi usado para criar o 'registro' 
                string ApiKey = "MangaRosa_Com_Leite_Mata_Todos_kkk@2026"; // Texto mestre 
                string PassSHA256 = ComputerSha256Hash(model.senha);
                string PhoneSHA256 = ComputerSha256Hash(model.numeroTelefone);

                // Esta é a string que o BCrypt vai validar 
                string PassCrip = PassSHA256 + ApiKey + PhoneSHA256;

                // 3. Verifica se a senha digitada bate com Hash guardado no banco (user.senha) 
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(PassCrip, user.senha);

                if (!isPasswordValid) 
                {
                    return Unauthorized(new 
                    {
                        erro = true,
                        message = "Telefone ou senha inválido! -- Cript"
                    });
                }

                // 4. Sucesso de login 
                return Ok(new
                {
                    erro = false,
                    message = "Login realizado com sucesso!",
                    usuario = new
                    {
                        id = user.idUsuario, 
                        nome = user.nome
                    }
                });
            } 
            catch (Exception ex) 
            {
                return StatusCode(500, new
                {
                    erro = true,
                    message = "Erro ao processar login ",
                    detalhe = ex.Message
                }); 
            }
        }

        // Função para SHA256 
        private string ComputerSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
