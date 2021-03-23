using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Entities
{
    /// <summary>
    /// Kết quả service trả về
    /// </summary>
    /// CreatedBy: TXTrinh (20/02/2021)
    public class ServiceResult
    {
        #region Property
        /// <summary>
        /// Thông báo cho lập trình viên
        /// </summary>
        public string devMsg { get; set; }

        /// <summary>
        /// Thông báo cho khách hàng
        /// </summary>
        public List<string> userMsg { get; set; } = new List<string>();


        /// <summary>
        /// Mã trả về
        /// </summary>
        public int MISACode { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Thông tin chi tiết
        /// </summary>
        public string moreInfo { get; set; }
        #endregion
    }
}
