using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using Api_control_comercio.Utils.Manager.ABMs;
using Api_control_comercio.Utils.Manager.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_control_comercio.Controllers.Pagos
{
    public class paymentSupplierOrderController : ApiController
    {
        #region Singleton
        private readonly static paymentSupplierOrderController _instance;
        public static paymentSupplierOrderController Current { get { return _instance; } }
        static paymentSupplierOrderController() { _instance = new paymentSupplierOrderController(); }
        private paymentSupplierOrderController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(paymentSupplierOrderManager.Current.GetAll());
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
                return Ok(paymentSupplierOrderManager.Current.GetOne(id));
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
        public IHttpActionResult Add([FromBody] payment_suppliers_order payment_Suppliers_Order)
        {
            try
            {
                paymentSupplierOrderManager.Current.Add(payment_Suppliers_Order);
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
        public IHttpActionResult Update([FromBody] payment_suppliers_order payment_Suppliers_Order)
        {
            try
            {
                paymentSupplierOrderManager.Current.Update(payment_Suppliers_Order);
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
                paymentSupplierOrderManager.Current.Remove(id);
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