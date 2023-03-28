using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using Api_control_comercio.Utils.Manager.Gestor_de_usuarios;
using Api_control_comercio.Utils.Manager.Gestor_de_ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_control_comercio.Controllers.Gestor_de_ventas
{
    public class saleOrderController : ApiController
    {
        #region Singleton
        private readonly static saleOrderController _instance;
        public static saleOrderController Current { get { return _instance; } }
        static saleOrderController() { _instance = new saleOrderController(); }
        private saleOrderController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(SaleOrderManager.Current.GetAll());
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
        public IHttpActionResult GetOne([FromBody] Guid sale)
        {
            try
            {
                List<sale_order> saleOrders = new List<sale_order>();
                saleOrders = SaleOrderManager.Current.GetOneSale(sale);
                return Ok(saleOrders);
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
        public IHttpActionResult Add([FromBody] sale_order sale_Order)
        {
            try
            {
                SaleOrderManager.Current.Add(sale_Order);
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
        public IHttpActionResult Update([FromBody] sale_order sale_Order)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] Guid id)
        {
            try
            {
                SaleOrderManager.Current.Remove(id);
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