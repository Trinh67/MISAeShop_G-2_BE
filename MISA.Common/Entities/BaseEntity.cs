using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Entities
{
    /// <summary>
    /// Attribute xác định thông tin bắt buộc phải nhập
    /// </summary>
    /// CreatedBy: TXTrinh (20/02/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
        #region Field
        public string propertyName;
        public string errorMsg;
        #endregion

        #region Constructor
        /// <summary>
        /// Kiểm tra bắt buộc nhập
        /// </summary>
        /// <param name="propertyName">Tên thuộc tính cần kiểm tra</param>
        /// <param name="errorMsg">Thông báo lỗi</param>
        public Required(string propertyName, string errorMsg)
        {
            this.propertyName = propertyName;
            this.errorMsg = errorMsg;
        }
        #endregion
    }

    /// <summary>
    /// Attribute xác định thông tin bị trùng
    /// </summary>
    /// CreatedBy: TXTrinh (20/02/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Duplicated : Attribute
    {
        #region Field
        public string propertyName;
        public string errorMsg;
        #endregion

        #region Constructor
        /// <summary>
        /// Kiểm tra trùng
        /// </summary>
        /// <param name="propertyName">Tên thuộc tính cần kiểm tra</param>
        /// <param name="errorMsg">Thông báo lỗi</param>
        public Duplicated(string propertyName, string errorMsg)
        {
            this.propertyName = propertyName;
            this.errorMsg = errorMsg;
        }
        #endregion
    }

    /// <summary>
    /// Attribute kiểm tra độ dài dữ liệu
    /// </summary>
    /// CreatedBy: TXTrinh (20/02/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        #region Field
        public string propertyName;
        public string errorMsg;
        public int Length { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Kiểm tra độ dài tối đa
        /// </summary>
        /// <param name="propertyName">Tên thuộc tính cần kiểm tra</param>
        /// <param name="length">Độ dài tiêu chuẩn</param>
        /// <param name="errorMsg">Nội dung thông báo lỗi</param>
        /// CreatedBy: TXTrinh (20/02/2021)
        public MaxLength(string propertyName, int length, string errorMsg = null)
        {
            this.propertyName = propertyName;
            this.errorMsg = errorMsg;
            Length = length;
        }
        #endregion
    }
}
