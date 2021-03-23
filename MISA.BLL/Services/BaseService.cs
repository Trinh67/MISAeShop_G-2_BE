using Dapper;
using MISA.Common.Entities;
using MISA.Common.Enumrations;
using MISA.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MISA.BLL
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        #region DECLARE
        protected IDbContext<MISAEntity> dbconnection;
        string _tableName = typeof(MISAEntity).Name;
        ServiceResult _serviceResult;
        #endregion

        #region Constructor
        public BaseService(IDbContext<MISAEntity> dbconnection)
        {
            this.dbconnection = dbconnection;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy danh sách bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created By: TXTrinh (20/02/2021)
        public virtual IEnumerable<MISAEntity> Get()
        {
            var sqlCommand = $"Proc_Get{_tableName}s";
            return dbconnection.GetData(sqlCommand, null, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// Lấy bản ghi theo Id
        /// </summary>
        /// <param name="Id">Id của bản ghi</param>
        /// <returns>Bản ghi cần tìm</returns>
        /// Created By: TXTrinh (20/02/2021)
        public virtual IEnumerable<MISAEntity> GetById(Guid Id)
        {
            var sqlCommand = $"Proc_Get{_tableName}ById";
            return dbconnection.GetData(sqlCommand, parameters: new {Id = Id }, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// Lấy danh sách bản ghi theo khoảng
        /// </summary>
        /// <param name="startPoint">Thứ tự bản ghi đầu tiên</param>
        /// <param name="number">Số lượng bản ghi cần lấy</param>
        /// <returns>Danh sách bả ghi cần lấy</returns>
        /// Created By: TXTrinh (20/02/2021)
        public virtual IEnumerable<MISAEntity> GetWithRange(int startPoint, int number)
        {
            var sqlCommand = $"SELECT * FROM View_{_tableName}  ORDER BY {_tableName}Code ASC LIMIT {startPoint}, {number}";
            return dbconnection.GetData(sqlCommand, null, System.Data.CommandType.Text);
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi mới</param>
        /// <returns>Số lượng bản ghi ảnh hưởng</returns>
        /// Created By: TXTrinh (20/02/2021)
        public virtual ServiceResult Insert(MISAEntity entity)
        {
            Validator(entity, true);
            if (_serviceResult.MISACode == (int)MISACode.BadRequest)
            {
                return _serviceResult;
            }
            var sqlCommand = $"Proc_Insert{_tableName}";
            var rowsAffected = dbconnection.ExcuteNonQuery(sqlCommand, entity, System.Data.CommandType.StoredProcedure);
            if (rowsAffected > 0)
            {
                _serviceResult.Data = rowsAffected;
                _serviceResult.MISACode = (int)MISACode.Created;
                _serviceResult.userMsg.Add(Common.Properties.Resources.UserMsg_Insert_Created);
            }
            else if (rowsAffected == 0)
            {
                _serviceResult.Data = rowsAffected;
                _serviceResult.MISACode = (int)MISACode.Success;
                _serviceResult.userMsg.Add(Common.Properties.Resources.UserMsg_Insert_Success);
            }
            return _serviceResult;
        }

        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi đã sửa</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// Created By: TXTrinh (20/02/2021)
        public virtual ServiceResult Update(MISAEntity entity)
        {
            var sqlCommand = $"Proc_Update{_tableName}";
            var rowsAffected = dbconnection.ExcuteNonQuery(sqlCommand, entity, System.Data.CommandType.StoredProcedure);
            if (rowsAffected > 0)
            {
                _serviceResult.Data = rowsAffected;
                _serviceResult.MISACode = (int)MISACode.Success;
                _serviceResult.userMsg.Add(Common.Properties.Resources.UserMsg_Update_Success);
            }
            else
            {
                _serviceResult.Data = rowsAffected;
                _serviceResult.MISACode = (int)MISACode.BadRequest;
                _serviceResult.userMsg.Add(Common.Properties.Resources.UserMsg_Update_Fail);
            }
            return _serviceResult;
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="Id">Id của bản ghi cần xóa</param>
        /// <returns>Số lượng bản ghi ảnh hưởng</returns>
        /// Created By: TXTrinh (20/02/2021)
        public virtual ServiceResult Delete(Guid Id)
        {
            var sqlCommand = $"Proc_Delete{_tableName}";
            var rowsAffected = dbconnection.ExcuteNonQuery(sqlCommand, parameters: new { Id = Id }, System.Data.CommandType.StoredProcedure);
            if (rowsAffected > 0)
            {
                _serviceResult.Data = rowsAffected;
                _serviceResult.MISACode = (int)MISACode.Success;
                _serviceResult.userMsg.Add(MISA.Common.Properties.Resources.UserMsg_Delete_Success);
            }
            else
            {
                _serviceResult.Data = rowsAffected;
                _serviceResult.MISACode = (int)MISACode.BadRequest;
                _serviceResult.userMsg.Add(MISA.Common.Properties.Resources.UserMsg_Delete_Fail);
            }
            return _serviceResult;
        }

        /// <summary>
        /// Validate dữ liệu trước khi thao tác với CSDL
        /// </summary>
        /// <param name="entity">Bản ghi cần kiểm tra</param>
        /// <param name="isNewGui">Kiểm tra xem là thao tác thêm hay sửa (true - thêm; false - sửa)</param>
        /// Created By: TXTrinh (20/02/2021)
        private void Validator(MISAEntity entity, bool isNewGui)
        {
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);

                if ((property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?)) && propertyName == $"{_tableName}Id" && isNewGui)
                    property.SetValue(entity, Guid.NewGuid());

                //Nếu property có attribute [Required] thì kiểm tra bắt buộc nhập
                if (property.IsDefined(typeof(Required), true)
                    && (propertyValue == null || propertyValue.ToString().Trim() == String.Empty))
                {
                    var requiredAttr = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if (requiredAttr != null)
                    {
                        var errMsg = (requiredAttr as Required).errorMsg;
                        _serviceResult.userMsg.Add($"{errMsg} ");
                        _serviceResult.MISACode = (int)MISACode.BadRequest;
                    }
                }
                //Nếu property có attribute [Duplicated] thì kiểm tra trùng
                if (property.IsDefined(typeof(Duplicated), true))
                {
                    var dupliactedAttr = property.GetCustomAttributes(typeof(Duplicated), true).FirstOrDefault();
                    if (dupliactedAttr != null)
                    {
                        var errMsg = (dupliactedAttr as Duplicated).errorMsg;
                        var sqlCommand = $"SELECT {propertyName} FROM {_tableName} WHERE {propertyName} = '{propertyValue}'";
                        var obj = dbconnection.GetData(sqlCommand, null, System.Data.CommandType.Text).FirstOrDefault();
                        if (obj != null)
                        {
                            _serviceResult.userMsg.Add($"{errMsg} ");
                            _serviceResult.MISACode = (int)MISACode.BadRequest;
                        }
                    }
                }
                //Nếu property có attribute [MaxLength] thì kiểm tra độ dài 
                if (property.IsDefined(typeof(MaxLength), true))
                {
                    var maxLengthAttribute = property.GetCustomAttributes(typeof(MaxLength), true).FirstOrDefault();
                    if (maxLengthAttribute != null && propertyValue != null)
                    {
                        var errMsg = (maxLengthAttribute as MaxLength).errorMsg;
                        var length = (maxLengthAttribute as MaxLength).Length;
                        if (propertyValue.ToString().Trim().Length > length)
                        {
                            _serviceResult.userMsg.Add($"{errMsg} ");
                            _serviceResult.MISACode = (int)MISACode.BadRequest;
                        }
                    }
                }
            }
        }
        #endregion


    }
}
