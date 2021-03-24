using MISA.Common.Interfaces;
using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BLL
{
    public class ProductCategoryService : BaseService<ProductCategory>, IProductCategoryService
    {
        public ProductCategoryService(IDbContext<ProductCategory> dbContext) : base(dbContext)
        {

        }
    }
}
