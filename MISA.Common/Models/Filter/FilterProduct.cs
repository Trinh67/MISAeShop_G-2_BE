using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class FilterProduct
    {
        /// <summary>
        /// SKU Code
        /// </summary>
        public string txtSKUCode { get; set; } = null;
        /// <summary>
        /// Tên hàng hóa
        /// </summary>
        public string txtProductName { get; set; } = null;
        /// <summary>
        /// Tên nhóm hàng hóa
        /// </summary>
        public string txtProductCategory { get; set; } = null;
        /// <summary>
        /// Tên đơn vị tính
        /// </summary>
        public string txtUnit { get; set; } = null;
        /// <summary>
        /// Giá bán
        /// </summary>
        public string txtSalePrice { get; set; } = null;
        /// <summary>
        /// Hiển thị trên màn hình
        /// </summary>
        public string txtIsShow { get; set; } = null;
        /// <summary>
        /// Trạng thái
        /// </summary>
        public string txtStatus { get; set; } = null;
        /// <summary>
        /// Điểm bắt đầu
        /// </summary>
        public int startPoint { get; set; } = 0;
        /// <summary>
        /// Số lượng bản ghi
        /// </summary>
        public int number { get; set; } = 15;     
    }
}
