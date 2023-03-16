using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using Api_control_comercio.Utils.Manager.ABMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace Api_control_comercio.Controllers.ABMs
{
    public class categoryController : ApiController
    {
        #region Singleton
        private readonly static categoryController _instance;
        public static categoryController Current { get { return _instance; } }
        static categoryController() { _instance = new categoryController(); }
        private categoryController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(categoryManager.Current.GetAll());
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
                return Ok(categoryManager.Current.GetOne(id));
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
        public IHttpActionResult Add([FromBody] category category)
        {
            try
            {
                categoryManager.Current.Add(category);
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
        public IHttpActionResult Update([FromBody] category category)
        {
            try
            {
                categoryManager.Current.Update(category);
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
                categoryManager.Current.Remove(id);
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