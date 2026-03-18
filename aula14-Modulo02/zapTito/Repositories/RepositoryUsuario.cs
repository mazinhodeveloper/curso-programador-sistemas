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
    }
}
