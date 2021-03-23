using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MISA.Common.Interfaces;

namespace MISA.DAL
{
    public class DbContext<MISAEntity> : IDbContext<MISAEntity>
    {
        #region Declare
        IConfiguration _configuration;
        IDbConnection _dbConnection;
        string _connectionString;
        #endregion

        #region Constructor
        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("EShopConnection");
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy danh sách bản ghi theo tiêu chí khác nhau
        /// </summary>
        /// <typeparam name="TEntity">Kiểu object</typeparam>
        /// <param name="commandText">Câu lệnh Sql/ Tên store</param>
        /// <param name="parameters">Tham số của store</param>
        /// <param name="type">Loại commandType (mặc định là Text)</param>
        /// <returns>Danh sách bản ghi</returns>
        /// Created By: TXTrinh (18/02/2021)
        public IEnumerable<MISAEntity> GetData(string commandText, object parameters = null, CommandType type = CommandType.Text)
        {
            var data = _dbConnection.Query<MISAEntity>(commandText, param: parameters, commandType: type);
            return data;
        }

        /// <summary>
        /// Số lượng bản ghi ảnh hưởng
        /// </summary>
        /// <param name="sqlCommand">Câu lệnh Sql/ Tên store</param>
        /// <param name="parameters">Tham số của store (mặc định là null)</param>
        /// <param name="type">Loại commandType (mặc định là Text)</param>
        /// <returns>Số lượng bản ghi ảnh hưởng</returns>
        /// CreatedBy: TXTrinh (19/02/2021)
        public int ExcuteNonQuery(string sqlCommand, object parameters = null, CommandType type = CommandType.Text)
        {
            return _dbConnection.Execute(sqlCommand, parameters, commandType: type);
        }
        #endregion
    }
}
