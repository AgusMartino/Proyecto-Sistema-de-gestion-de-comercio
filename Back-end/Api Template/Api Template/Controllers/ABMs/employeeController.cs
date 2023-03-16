using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using Api_control_comercio.Utils.Manager.ABMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_control_comercio.Controllers.ABMs
{
    public class employeeController : ApiController
    {
        #region Singleton
        private readonly static employeeController _instance;
        public static employeeController Current { get { return _instance; } }
        static employeeController() { _instance = new employeeController(); }
        private employeeController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(employeeManager.Current.GetAll());
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetOne([FromUri] Guid id)
        {
            try
            {
                return Ok(employeeManager.Current.GetOne(id));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] employee employee)
        {
            try
            {
                employeeManager.Current.Add(employee);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] employee employee)
        {
            try
            {
                employeeManager.Current.Update(employee);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromUri] Guid id)
        {
            try
            {
                employeeManager.Current.Remove(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}