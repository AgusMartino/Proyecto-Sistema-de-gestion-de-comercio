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
    public class productRawMaterialController : ApiController
    {
        #region Singleton
        private readonly static productRawMaterialController _instance;
        public static productRawMaterialController Current { get { return _instance; } }
        static productRawMaterialController() { _instance = new productRawMaterialController(); }
        private productRawMaterialController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(productRawMaterialManager.Current.GetAll());
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
        public IHttpActionResult GetOne([FromBody] Guid id)
        {
            try
            {
                return Ok(productRawMaterialManager.Current.GetOne(id));
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
        public IHttpActionResult Add([FromBody] product_rawmaterial product_Rawmaterial)
        {
            try
            {
                productRawMaterialManager.Current.Add(product_Rawmaterial);
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
        public IHttpActionResult Update([FromBody] product_rawmaterial product_Rawmaterial)
        {
            try
            {
                productRawMaterialManager.Current.Update(product_Rawmaterial);
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
        public IHttpActionResult Remove([FromBody] Guid id)
        {
            try
            {
                productRawMaterialManager.Current.Remove(id);
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