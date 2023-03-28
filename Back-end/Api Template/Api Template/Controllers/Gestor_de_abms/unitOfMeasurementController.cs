﻿using Api_control_comercio.Entities.Exceptions;
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
    public class unitOfMeasurementController : ApiController
    {
        #region Singleton
        private readonly static unitOfMeasurementController _instance;
        public static unitOfMeasurementController Current { get { return _instance; } }
        static unitOfMeasurementController() { _instance = new unitOfMeasurementController(); }
        private unitOfMeasurementController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(unitOfMeasurementManager.Current.GetAll());
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
                return Ok(unitOfMeasurementManager.Current.GetOne(id));
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
        public IHttpActionResult Add([FromBody] unit_of_measurement unit_Of_Measurement)
        {
            try
            {
                unitOfMeasurementManager.Current.Add(unit_Of_Measurement);
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
        public IHttpActionResult Update([FromBody] unit_of_measurement unit_Of_Measurement)
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