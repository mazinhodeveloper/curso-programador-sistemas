using Dapper;
using API.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace API.Repositories
{
    public class RepositoryPERFIL : IRepositoryPERFIL
    {
        private readonly string _connectionString;

        public RepositoryPERFIL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<PERFILRequestModel>> GetAllAsync()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<PERFILRequestModel>(
                "SELECT idPerfil, tipo, descricao FROM PERFIL");
        }

        public async Task<PERFILRequestModel?> GetById(int idPerfil)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<PERFILRequestModel>(
                "SELECT idPerfil, tipo, descricao FROM PERFIL WHERE idPerfil = @idPerfil",
                new { idPerfil });
        }

        public async Task<int> Create(PERFILRequestModel model)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                "INSERT INTO PERFIL (tipo, descricao) VALUES (@tipo, @descricao)",
                model);
        }

        public async Task<int> Update(int idPerfil, PERFILRequestModel model)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                @"UPDATE PERFIL
                  SET tipo = @tipo, descricao = @descricao
                  WHERE idPerfil = @idPerfil",
                new { model.tipo, model.descricao, idPerfil });
        }

        public async Task<int> Delete(int idPerfil)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                "DELETE FROM PERFIL WHERE idPerfil = @idPerfil",
                new { idPerfil });
        }
    }
}