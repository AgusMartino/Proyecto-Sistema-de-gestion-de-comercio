using Api_control_comercio.Entities.ABMs.inventory;
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
    public class inventaryController : ApiController
    {
        #region Singleton
        private readonly static inventaryController _instance;
        public static inventaryController Current { get { return _instance; } }
        static inventaryController() { _instance = new inventaryController(); }
        private inventaryController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll([FromUri] Guid location)
        {
            try
            {
                return Ok(inventoryManager.Current.GetAllLocation(location));
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
                return Ok(inventoryManager.Current.GetOne(id));
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

        public IHttpActionResult GetOneLocationMaterial([FromUri] Guid location, Guid material)
        {
            try
            {
                return Ok(inventoryManager.Current.GetOneLocationMaterial(location, material));
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
        public IHttpActionResult Add([FromBody]inventoryBody inventary)
        {
            try
            {
                inventoryManager.Current.Add(inventary);
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
        public IHttpActionResult Update([FromBody] inventoryBody inventary)
        {
            try
            {
                inventoryManager.Current.Update(inventary);
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
                inventoryManager.Current.Remove(id);
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
        public IHttpActionResult AddInventary([FromBody] inventoryBody inventary)
        {
            try
            {
                inventoryBody inventoryOld = new inventoryBody();
                inventoryOld = (inventoryBody)GetOne(inventary.Id);

                inventary.quantity = inventoryOld.quantity + inventary.quantity;

                Update(inventary);
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

        public IHttpActionResult RemoveInventary([FromBody] inventoryBody inventary)
        {
            try
            {
                inventoryBody inventoryOld = new inventoryBody();
                inventoryOld = (inventoryBody)GetOne(inventary.Id);

                inventary.quantity = inventoryOld.quantity - inventary.quantity;

                Update(inventary);
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