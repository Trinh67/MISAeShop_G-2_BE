using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MISA.Common.Interfaces;
using MISA.CukCuk.Api.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.EShop.API.Controllers
{
    [Route("api/v1/Products")]
    [ApiController]
    public class ProductController : BaseController<Product>
    {
        #region Method
        public ProductController(IProductService _ProductService, IDbContext<Product> dbconnection) : base(_ProductService, dbconnection)
        {
        }
        /// <summary>
        /// Lọc dữ liệu theo điều kiện
        /// </summary>
        /// <param name="ProductCode">Mã cửa hàng</param>
        /// <param name="ProductName">Tên cửa hàng</param>
        /// <param name="Address">Địa chỉ cửa hàng</param>
        /// <param name="PhoneNumber">Số điện thoại của hàng</param>
        /// <param name="StatusId">Mã trạng thái cửa hàng</param>
        /// <returns>Danh sách bản ghi</returns>
        /// Created By: TXTrinh (20/02/2021)
        [HttpPost]
        [Route("FilterProduct")]
        public IEnumerable<Product> FilterProduct(string SKUCode = null, string ProductName = null, string ProductCategoryName = null, string UnitName = null, int Price = 999999999, string isShow = null, string Status = null, int startPoint = 0, int number = 15)
        {
            var sqlCommand = "Proc_FilterProduct";
            //var sqlCommand = $"SELECT * FROM View_Product vs WHERE(vs.ProductCode LIKE CONCAT('%', @ProductCode, '%') AND vs.ProductName LIKE CONCAT('%', @ProductName, '%') AND vs.Address LIKE CONCAT('%', @Address, '%') AND vs.PhoneNumber LIKE CONCAT('%', @PhoneNumber, '%')) AND((@StatusId IS NOT NULL AND vs.StatusId = @StatusId) OR @StatusId IS NULL) ORDER BY vs.ProductCode ASC";
            //return _db.GetData(sqlCommand, new { ProductCode = ProductCode, ProductName = ProductName, Address = Address, PhoneNumber = PhoneNumber, StatusId = StatusId}, System.Data.CommandType.StoredProcedure);
            return _db.GetData(sqlCommand, new { Code = SKUCode, ProName = ProductName, CategoryName = ProductCategoryName, UnitName = UnitName, Price = Price, isShow = isShow, Status = Status, StartPoint = startPoint, NumberRecord = number }, System.Data.CommandType.StoredProcedure);
        }
        #endregion
    }
}
