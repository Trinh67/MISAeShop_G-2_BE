using MISA.Common.Entities;
using MISA.Common.Enumrations;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Shop
    {
        #region Property
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid ShopId { get; set; }

        /// <summary>
        /// Mã cửa hàng
        /// </summary>
        [Required("Mã cửa hàng", "Mã cửa hàng không được để trống!")]
        [Duplicated("Mã cửa hàng", "Mã cửa hàng đã tồn tại trên hệ thống!")]
        [MaxLength("Mã cửa hàng", 6, "Mã cửa hàng không dài quá 6 kí tự!")]
        public string ShopCode { get; set; }

        /// <summary>
        /// Tên cửa hàng
        /// </summary>
        [Required("Tên cửa hàng", "Tên cửa hàng không được phép để trống!")]
        [Duplicated("Tên cửa hàng", "Tên cửa hàng đã tồn tại trên hệ thống!")]
        [MaxLength("Tên cửa hàng", 40, "Tên cửa hàng không dài quá 40 kí tự!")]
        public string ShopName { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Duplicated("Số điện thoại", "Số điện thoại đã tồn tại trên hệ thống!")]
        [MaxLength("Số điện thoại", 15, "Số điện thoại không dài quá 12 số!")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        [MaxLength("Mã số thuế", 10, "Mã số thuế không dài quá 10 kí tự!")]
        public string ShopTaxCode { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        [Required("Địa chỉ", "Địa chỉ cửa hàng không được phép để trống!")]
        public string Address { get; set; }

        /// <summary>
        /// Mã trạng thái
        /// </summary>
        public Guid? StatusId { get; set; }

        /// <summary>
        /// Trạng thái cửa hàng
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifyBy { get; set; }
        #endregion
    }
}
