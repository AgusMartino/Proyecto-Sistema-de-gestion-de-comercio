using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using Api_control_comercio.Utils.Manager.Gestor_de_abms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_control_comercio.Controllers.Gestor_de_abms
{
    public class paymentMethodController : ApiController
    {
        #region Singleton
        private readonly static paymentMethodController _instance;
        public static paymentMethodController Current { get { return _instance; } }
        static paymentMethodController() { _instance = new paymentMethodController(); }
        private paymentMethodController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(paymentMethodManager.Current.GetAll());
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
                return Ok(paymentMethodManager.Current.GetOne(id));
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
        public IHttpActionResult Add([FromBody] payment_method payment_method)
        {
            try
            {
                paymentMethodManager.Current.Add(payment_method);
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
        public IHttpActionResult Update([FromBody] payment_method payment_method)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromUri] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}