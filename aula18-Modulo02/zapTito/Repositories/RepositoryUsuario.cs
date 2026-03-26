/* -- RepositoryUsuario.cs */
using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using zapTito.Data.Models;  

namespace zapTito.Repositories
{
    public class RepositoryUsuario
    {
        private readonly string _connectionString = string.Empty;

        public RepositoryUsuario(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException("String de conexão 'DefaultConnection' não encontrada.");
        }

        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var commandText = @"
                    INSERT INTO dbo.ztUSUARIO 
                        (idACL, idStatus, idPerfil, nome, dataNascimento, numeroTelefone, senha) 
                    VALUES 
                        (@idACL, @idStatus, @idPerfil, @nome, @dataNascimento, @numeroTelefone, @senha)
                "; 

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@idACL", usuario.idACL);
                    command.Parameters.AddWithValue("@idStatus", usuario.idStatus);
                    command.Parameters.AddWithValue("@idPerfil", usuario.idPerfil);
                    command.Parameters.AddWithValue("@nome", usuario.nome);
                    command.Parameters.AddWithValue("@dataNascimento", usuario.dataNascimento);
                    command.Parameters.AddWithValue("@numeroTelefone", usuario.numeroTelefone);
                    command.Parameters.AddWithValue("@senha", usuario.senha);

                    await command.ExecuteNonQueryAsync(); 
                }

            }
        } 

        // URL Example: https://localhost:XXXX/swagger
        public async Task<Usuario?> GetUsuarioByTelefoneAsync(string telefone)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Buscar o usuário pelo número do telefone 
                // SELECT numeroTelefone, nome, senha OU * FROM 
                /*var query = @"
                    SELECT * FROM dbo.ztUSUARIO WHERE numeroTelefone = @numeroTelefone 
                "; */ 
                var query = @"
                    SELECT * FROM dbo.ztUSUARIO 
                    WHERE numeroTelefone = @numeroTelefone
                ";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numeroTelefone", telefone); 

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        /* mm 
                        var numeroTelefone = reader["numeroTelefone"].ToString() ?? string.Empty;

                        return numeroTelefone; 
                        */
                        /*
                         * return new Usuario
                        {
                            idUsuario = (int)reader["idUsuario"],
                            numeroTelefone = reader["numeroTelefone"].ToString() ?? string.Empty
                        }; 
                        */ 
                        // Carrega pelo menos 1 item valido 
                        if (await reader.ReadAsync())
                        {
                            return new Usuario
                            {
                                idUsuario = (int)reader["idUsuario"],
                                nome = reader["nome"].ToString() ?? string.Empty, 
                                numeroTelefone = reader["numeroTelefone"].ToString() ?? string.Empty, 
                                // Falta trazer a senha 
                                senha = reader["senha"].ToString() ?? string.Empty
                            };
                        }
                    }
                }
            }
            // Se não encontrar ninguém 
            return null;
        } 

        // Model update senha 
        public async Task<bool> UpdateSenhaAsync(string telefone, string novaSenhaBCript) 
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); 

                var query = @"
                    UPDATE dbo.ztUSUARIO SET senha = @novaSenhaBCript WHERE numeroTelefone = @telefone
                "; 

                using (var command = new SqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@novaSenhaBCript", novaSenhaBCript);
                    command.Parameters.AddWithValue("@telefone", telefone);

                    int linhaAtualizada = await command.ExecuteNonQueryAsync();
                    return linhaAtualizada > 0; // Retorna true se atualizou a senha do usuário 
                }
            }
        }
    }
}
