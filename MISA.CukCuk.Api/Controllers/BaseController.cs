using Microsoft.AspNetCore.Mvc;
using MISA.Common.Entities;
using MISA.Common.Enumrations;
using MISA.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<MISAEnity> : ControllerBase
    {
        #region DECLARE
        IBaseService<MISAEnity> _baseService;
        protected IDbContext<MISAEnity> _db;
        #endregion

        #region Constructor
        public BaseController(IBaseService<MISAEnity> baseService, IDbContext<MISAEnity> dbconnection)
        {
            _baseService = baseService;
            this._db = dbconnection;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy danh sách bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// CreatedBy: TXTrinh (20/02/2021)
        [HttpGet]
        public virtual IEnumerable<MISAEnity> Get()
        {
            return _baseService.Get();
        }

        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        /// <returns>Bản ghi cần lấy</returns>
        /// CreatedBy: TXTrinh (20/02/2021)
        [HttpGet]
        [Route("{id}")]
        public virtual IEnumerable<MISAEnity> GetById(Guid id)
        {
            return _baseService.GetById(id);
        }

        /// <summary>
        /// Lấy số lượng bản ghi theo khoảng
        /// </summary>
        /// <param name="startPoint">Bản ghi bắt đầu</param>
        /// <param name="number">Số lượng bản ghi cần lấy</param>
        /// <returns>List các bản ghi</returns>
        /// CreatedBy: TXTrinh (20/02/2021)
        [HttpGet]
        [Route("GetWithRange")]
        public virtual IEnumerable<MISAEnity> GetWithRange(int startPoint, int number)
        {
            return _baseService.GetWithRange(startPoint, number);

        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="enity">Bản ghi mới</param>
        /// <returns>Kết quả thêm mới</returns>
        /// CreatedBy: TXTrinh (20/02/2021)
        [HttpPost]
        public virtual IActionResult Insert(MISAEnity enity)
        {
            var serviceResult = _baseService.Insert(enity);
            return StatusCode(serviceResult.MISACode, serviceResult);
        }

        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <param name="enity">Bản ghi đã sửa</param>
        /// <returns>Kết quả sửa</returns>
        /// CreatedBy: TXTrinh (20/02/2021)
        [HttpPut]
        public virtual IActionResult Update(MISAEnity enity)
        {
            var serviceResult = _baseService.Update(enity);
            return StatusCode(serviceResult.MISACode, serviceResult);

        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi càn xóa</param>
        /// <returns>Kết quả sau khi xóa</returns>
        /// CreatedBy: TXTrinh (20/02/2021)
        [HttpDelete]
        public virtual IActionResult Delete(Guid id)
        {
            var serviceResult = _baseService.Delete(id);
            return StatusCode(serviceResult.MISACode, serviceResult);
        }
        #endregion
    }
}
