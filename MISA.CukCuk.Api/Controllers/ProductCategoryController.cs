using Microsoft.AspNetCore.Mvc;
using MISA.Common.Interfaces;
using MISA.Common.Models;
using MISA.CukCuk.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.EShop.Api.Controllers
{
    [Route("api/v1/ProductCategorys")]
    [ApiController]
    public class ProductCategoryController : BaseController<ProductCategory>
    {
        #region Method
        public ProductCategoryController(IProductCategoryService _ProductCategoryService, IDbContext<ProductCategory> dbconnection) : base(_ProductCategoryService, dbconnection)
        {                  

        }
        #endregion
    }
}
