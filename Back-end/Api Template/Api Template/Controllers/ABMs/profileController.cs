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
    public class profileController : ApiController
    {
        #region Singleton
        private readonly static profileController _instance;
        public static profileController Current { get { return _instance; } }
        static profileController() { _instance = new profileController(); }
        private profileController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(profileManager.Current.GetAll());
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
                return Ok(profileManager.Current.GetOne(id));
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
        public IHttpActionResult Add([FromBody] profile profile)
        {
            try
            {
                profileManager.Current.Add(profile);
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
        public IHttpActionResult Update([FromBody] profile profile)
        {
            try
            {
                profileManager.Current.Update(profile);
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
                profileManager.Current.Remove(id);
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