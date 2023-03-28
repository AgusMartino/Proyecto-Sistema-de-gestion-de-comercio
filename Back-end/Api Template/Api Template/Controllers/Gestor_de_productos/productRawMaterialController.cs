using Api_control_comercio.Entities.ABMs.Product_rawMaterial;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using Api_control_comercio.Utils.Manager.Gestor_de_productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_control_comercio.Controllers.Gestor_de_productos
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
        public IHttpActionResult Join(product_rawMaterialBody raw_material, product product)
        {
            try
            {
                //Se registra el componente del producto
                productRawMaterialManager.Current.Join(raw_material, product);
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
        public IHttpActionResult GetFamilia(product_rawMaterialBody obj)
        {
            try
            {
                //Se obtiene los la familia del componente
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
                //Se obtiene los componentes del producto
                List<product_rawMaterialBody> raw_materials = productRawMaterialManager.Current.GetComponentes(obj);
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
                //Se eliminan los componentes del producto
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