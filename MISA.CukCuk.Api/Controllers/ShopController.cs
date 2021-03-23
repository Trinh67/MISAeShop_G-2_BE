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

namespace MISA.DEMO.API.Controllers
{
    [Route("api/v1/shops")]
    [ApiController]
    public class ShopController : BaseController<Shop>
    {
        #region Method
        public ShopController(IShopService _shopService, IDbContext<Shop> dbconnection) : base(_shopService, dbconnection)
        {
        }
        /// <summary>
        /// Lọc dữ liệu theo điều kiện
        /// </summary>
        /// <param name="ShopCode">Mã cửa hàng</param>
        /// <param name="ShopName">Tên cửa hàng</param>
        /// <param name="Address">Địa chỉ cửa hàng</param>
        /// <param name="PhoneNumber">Số điện thoại của hàng</param>
        /// <param name="StatusId">Mã trạng thái cửa hàng</param>
        /// <returns>Danh sách bản ghi</returns>
        /// Created By: TXTrinh (20/02/2021)
        [HttpGet]
        [Route("FilterShop")]
        public IEnumerable<Shop> FilterShop(string ShopCode = "", string ShopName = "", string Address = "", string PhoneNumber = "", string StatusId = null)
        {
            //var sqlCommand = "Proc_FilterShop";
            var sqlCommand = $"SELECT * FROM View_Shop vs WHERE(vs.ShopCode LIKE CONCAT('%', @ShopCode, '%') AND vs.ShopName LIKE CONCAT('%', @ShopName, '%') AND vs.Address LIKE CONCAT('%', @Address, '%') AND vs.PhoneNumber LIKE CONCAT('%', @PhoneNumber, '%')) AND((@StatusId IS NOT NULL AND vs.StatusId = @StatusId) OR @StatusId IS NULL) ORDER BY vs.ShopCode ASC";
            //return _db.GetData(sqlCommand, new { ShopCode = ShopCode, ShopName = ShopName, Address = Address, PhoneNumber = PhoneNumber, StatusId = StatusId}, System.Data.CommandType.StoredProcedure);
            return _db.GetData(sqlCommand, new { ShopCode = ShopCode, ShopName = ShopName, Address = Address, PhoneNumber = PhoneNumber, StatusId = StatusId }, System.Data.CommandType.Text);
        }
        #endregion
    }
}
