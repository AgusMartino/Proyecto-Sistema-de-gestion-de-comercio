using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using Api_control_comercio.Utils.Manager.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api_control_comercio.Controllers.Logger
{
    public sealed class LoggerController : ApiController
    {
        #region singleton
        private readonly static LoggerController _instance = new LoggerController();

        public static LoggerController Current
        {
            get
            {
                return _instance;
            }
        }

        private LoggerController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(LoggerManagerBD.Current.GetAll());
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
        public IHttpActionResult GetAllLocation([FromUri] Guid location)
        {
            try
            {
                return Ok(LoggerManagerBD.Current.GetAllLocation(location));
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
        public IHttpActionResult GetAllUser([FromUri] Guid user)
        {
            try
            {
                return Ok(LoggerManagerBD.Current.GetAllUser(user));
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
        public IHttpActionResult Add([FromBody] logs log)
        {
            try
            {
                LoggerManagerBD.Current.Add(log);
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