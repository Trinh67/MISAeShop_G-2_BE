using Dapper;
using MISA.Common.Entities;
using MISA.Common.Enumrations;
using MISA.Common.Interfaces;
using MISA.Common.Models;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace MISA.BLL
{
    public class ShopService : BaseService<Shop>, IShopService
    {
        public ShopService(IDbContext<Shop> dbContext) : base(dbContext)
        {

        }
    }
}
