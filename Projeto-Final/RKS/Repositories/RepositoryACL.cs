using Dapper;
using API.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace API.Repositories
{
    public class RepositoryACL : IRepositoryACL
    {
        private readonly string _connectionString;

        public RepositoryACL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<ACLRequestModel>> GetAllAsync()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<ACLRequestModel>(
                "SELECT idACL, tipo, descricao FROM ACL");
        }

        public async Task<ACLRequestModel?> GetById(int idACL)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ACLRequestModel>(
                "SELECT idACL, tipo, descricao FROM ACL WHERE idACL = @idACL",
                new { idACL });
        }

        public async Task<int> Create(ACLRequestModel model)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                "INSERT INTO ACL (tipo, descricao) VALUES (@tipo, @descricao)",
                model);
        }

        public async Task<int> Update(int idACL, ACLRequestModel model)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                @"UPDATE ACL
                  SET tipo = @tipo, descricao = @descricao
                  WHERE idACL = @idACL",
                new { model.tipo, model.descricao, idACL });
        }

        public async Task<int> Delete(int idACL)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(
                "DELETE FROM ACL WHERE idACL = @idACL",
                new { idACL });
        }
    }
}