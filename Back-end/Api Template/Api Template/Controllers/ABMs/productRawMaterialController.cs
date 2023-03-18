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

        [HttpPost]
        public IHttpActionResult Join(raw_material raw_material, product product, int quantity)
        {
            try
            {
                productRawMaterialManager.Current.Join(raw_material, product, quantity);
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

        [HttpGet]
        public IHttpActionResult GetFamilia(raw_material obj)
        {
            try
            {
                productRawMaterialManager.Current.GetFamilia(obj);
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

        [HttpGet]
        public IHttpActionResult GetComponentes(product obj)
        {
            try
            {
                List<raw_material> raw_materials = productRawMaterialManager.Current.GetComponentes(obj);
                return Ok(raw_materials);
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
        public IHttpActionResult DeleteJoin(product obj)
        {
            try
            {
                productRawMaterialManager.Current.DeleteJoin(obj);
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