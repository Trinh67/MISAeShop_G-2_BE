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
using MISA.Common.Entities;
using MISA.Common.Enumrations;

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
        public IEnumerable<Product> FilterProduct(FilterProduct Filter)
        {
            var sqlCommand = "Proc_FilterProduct";

            if (Filter.txtSKUCode != null && Filter.txtSKUCode.ToString().Trim() != String.Empty) Filter.txtSKUCode = '%' + Filter.txtSKUCode + '%'; else Filter.txtSKUCode = null;
            if (Filter.txtProductName != null && Filter.txtProductName.ToString().Trim() != String.Empty) Filter.txtProductName = '%' + Filter.txtProductName + '%'; else Filter.txtProductName = null;
            if (Filter.txtProductCategory != null && Filter.txtProductCategory.ToString().Trim() != String.Empty) Filter.txtProductCategory = '%' + Filter.txtProductCategory + '%'; else Filter.txtProductCategory = null;
            if (Filter.txtUnit != null && Filter.txtUnit.ToString().Trim() != String.Empty) Filter.txtUnit = '%' + Filter.txtUnit + '%'; else Filter.txtUnit = null;
            if (Filter.txtSalePrice != null && Filter.txtSalePrice.ToString().Trim() == String.Empty) Filter.txtSalePrice = null;
            if (Filter.txtIsShow != null && Filter.txtIsShow.ToString().Trim() == String.Empty) Filter.txtIsShow = null;
            if (Filter.txtStatus != null && Filter.txtStatus.ToString().Trim() == String.Empty) Filter.txtStatus = null;

            return _db.GetData(sqlCommand, new { Code = Filter.txtSKUCode, ProName = Filter.txtProductName, CategoryName = Filter.txtProductCategory, UnitName = Filter.txtUnit, Price = Filter.txtSalePrice, isShow = Filter.txtIsShow, Status = Filter.txtStatus, StartPoint = Filter.startPoint, NumberRecord = Filter.number }, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// Đếm số lượng bản ghi
        /// </summary>
        /// <param name="Filter"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CountProduct")]
        public IEnumerable<Product> CountProduct(FilterProduct Filter)
        {
            var sqlCommand = "Proc_CountProduct";

            if (Filter.txtSKUCode != null && Filter.txtSKUCode.ToString().Trim() != String.Empty) Filter.txtSKUCode = '%' + Filter.txtSKUCode + '%'; else Filter.txtSKUCode = null;
            if (Filter.txtProductName != null && Filter.txtProductName.ToString().Trim() != String.Empty) Filter.txtProductName = '%' + Filter.txtProductName + '%'; else Filter.txtProductName = null;
            if (Filter.txtProductCategory != null && Filter.txtProductCategory.ToString().Trim() != String.Empty) Filter.txtProductCategory = '%' + Filter.txtProductCategory + '%'; else Filter.txtProductCategory = null;
            if (Filter.txtUnit != null && Filter.txtUnit.ToString().Trim() != String.Empty) Filter.txtUnit = '%' + Filter.txtUnit + '%'; else Filter.txtUnit = null;
            if (Filter.txtSalePrice != null && Filter.txtSalePrice.ToString().Trim() == String.Empty) Filter.txtSalePrice = null;
            if (Filter.txtIsShow != null && Filter.txtIsShow.ToString().Trim() == String.Empty) Filter.txtIsShow = null;
            if (Filter.txtStatus != null && Filter.txtStatus.ToString().Trim() == String.Empty) Filter.txtStatus = null;

            return _db.GetData(sqlCommand, new { Code = Filter.txtSKUCode, ProName = Filter.txtProductName, CategoryName = Filter.txtProductCategory, UnitName = Filter.txtUnit, Price = Filter.txtSalePrice, isShow = Filter.txtIsShow, Status = Filter.txtStatus,}, System.Data.CommandType.StoredProcedure);
        }

        [HttpPost]
        [Route("DeleteList")]
        public ServiceResult DeleteList(List<int> ListID)
        {
            var _serviceResult = new ServiceResult();
            var sqlCommand = "DELETE FROM products WHERE ProductID IN (";
            foreach(var id in ListID)
            {
               sqlCommand = sqlCommand + id + ',';
            };
            sqlCommand = sqlCommand.Substring(0, sqlCommand.Length - 1);
            sqlCommand = sqlCommand + ')';
            var rowsAffected = _db.GetData(sqlCommand, System.Data.CommandType.StoredProcedure);
            _serviceResult.Data = rowsAffected;
            _serviceResult.MISACode = (int)MISACode.Success;
            _serviceResult.userMsg.Add(MISA.Common.Properties.Resources.UserMsg_Delete_Success);
            
            return _serviceResult;
        }
        #endregion
    }
}
