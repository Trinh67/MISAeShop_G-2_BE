using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class ProductCategory
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int ProductCategoryID { get; set; }

        /// <summary>
        /// Tên nhóm hàng hóa
        /// </summary>
        public string ProductCategoryName { get; set; }
    }
}
