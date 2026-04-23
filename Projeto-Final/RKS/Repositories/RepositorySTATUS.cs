using Dapper;
using API.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace API.Repositories
{
    public class RepositorySTATUS : IRepositorySTATUS
    {
        private readonly string _connectionString;

        public RepositorySTATUS(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<STATUSRequestModel>> GetAllAsync()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<STATUSRequestModel>(
                "SELECT idStatus, tipo, descricao FROM STATUS");
        }

        public async Task<STATUSRequestModel?> GetById(int idStatus)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<STATUSRequestModel>(
                "SELECT idStatus, tipo, descricao FROM STATUS WHERE idStatus = @idStatus",
                new { idStatus });
        }

        public async Task<int> Create(STATUSRequestModel model)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                "INSERT INTO STATUS (tipo, descricao) VALUES (@tipo, @descricao)",
                model);
        }

        public async Task<int> Update(int idStatus, STATUSRequestModel model)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                @"UPDATE STATUS
                  SET tipo = @tipo, descricao = @descricao
                  WHERE idStatus = @idStatus",
                new { model.tipo, model.descricao, idStatus });
        }

        public async Task<int> Delete(int idStatus)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                "DELETE FROM STATUS WHERE idStatus = @idStatus",
                new { idStatus });
        }
    }
}