using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Common.Interfaces
{
    public interface IDbContext<MISAEntity>
    {   
        /// <summary>
        /// Lấy dữ liệu từ cơ sở dữ liệu
        /// </summary>
        /// <returns>Danh sách các bản ghi</returns>
        /// CreatedBy: TXTrinh (20/02/2021)
        IEnumerable<MISAEntity> GetData(string commandText, object parameters = null, CommandType type = CommandType.Text);

        /// <summary>
        /// Thực thi một câu lệnh sql
        /// </summary>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: TXTrinh (20/02/2021)
        int ExcuteNonQuery(string sqlCommand, object parameters,CommandType commandType);
    }
}
