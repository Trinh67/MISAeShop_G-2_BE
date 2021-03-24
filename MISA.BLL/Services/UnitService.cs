using MISA.Common.Interfaces;
using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BLL
{
    public class UnitService : BaseService<Unit>, IUnitService
    {
        public UnitService(IDbContext<Unit> dbContext) : base(dbContext)
        {

        }
    }
}
