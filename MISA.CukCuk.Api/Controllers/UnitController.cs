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
    [Route("api/v1/Units")]
    [ApiController]
    public class UnitController : BaseController<Unit>
    {
        #region Method
        public UnitController(IUnitService _UnitService, IDbContext<Unit> dbconnection) : base(_UnitService, dbconnection)
        {

        }
        #endregion
    }
}
