using MISA.Common.Entities;
using MISA.Common.Enumrations;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Product
    {
        #region Property
        /// <summary>
        /// Khoá chính
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Mã cửa hàng
        /// </summary>
        [Required("Mã hàng hóa", "Mã hàng hóa không được để trống!")]
        [Duplicated("Mã hàng hóa", "Mã hàng hóa đã tồn tại trên hệ thống!")]
        [MaxLength("Mã hàng hóa", 10, "Mã hàng hóa không dài quá 10 kí tự!")]
        public string SKUCode { get; set; }

        /// <summary>
        /// Tên cửa hàng
        /// </summary>
        [Required("Tên hàng hóa", "Tên hàng hóa không được phép để trống!")]
        [MaxLength("Tên hàng hóa", 40, "Tên hàng hóa không dài quá 40 kí tự!")]
        public string ProductName { get; set; }

        /// <summary>
        /// Mã nhóm hàng hóa
        /// </summary>
        public int ProductCategoryID { get; set; }

        /// <summary>
        /// Tên nhóm hàng hóa
        /// </summary>
        public string ProductCategoryName { get; set; }

        /// <summary>
        /// Mã đơn vị tính
        /// </summary>
        public int UnitID { get; set; }

        /// <summary>
        /// Tên đơn vị tính
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Giá bán
        /// </summary>
        public int SalePrice { get; set; }

        /// <summary>
        /// Giá mua
        /// </summary>
        public int BuyPrice { get; set; }

        /// <summary>
        /// Mã hiển thị
        /// </summary>
        public int ShowInScreen { get; set; }

        /// <summary>
        /// Mã trạng thái
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Miêu tả ngắn
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ảnh hàng hóa
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// Mã vạch
        /// </summary>
        public int BarCode { get; set; }

        /// <summary>
        /// Màu sắc
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Khóa cha
        /// </summary>
        public int ParentID { get; set; }

        #endregion
    }
}
