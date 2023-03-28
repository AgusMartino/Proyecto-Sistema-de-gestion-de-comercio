using Api_control_comercio.Controllers.Logger;
using Api_control_comercio.Entities.ABMs.Physical_location;
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
    public class physicalLocationController : ApiController
    {
        #region Singleton
        private readonly static physicalLocationController _instance;
        public static physicalLocationController Current { get { return _instance; } }
        static physicalLocationController() { _instance = new physicalLocationController(); }
        private physicalLocationController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll([FromBody] Guid user, Guid location)
        {
            try
            {
                List<physical_location> physical_Locations = physicalLocationManager.Current.GetAll();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la lista de todos los location"
                });
                return Ok(physical_Locations);
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllLocation([FromBody] Guid user, Guid location)
        {
            try
            {
                List<physical_location> physical_Locations = physicalLocationManager.Current.GetAllLocation();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la lista de todos los location menos los centrales"
                });
                return Ok(physical_Locations);
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllLocationCentral([FromBody] Guid user, Guid location)
        {
            try
            {
                List<physical_location> physical_Locations = physicalLocationManager.Current.GetAllLocationCentral(location);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la lista de todos los location de la central con id: {location}"
                });
                return Ok(physical_Locations);
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetOne([FromBody] Guid user, Guid location)
        {
            try
            {
                physical_location physical_Location = physicalLocationManager.Current.GetOne(location);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la informacion del location con id: {location}"
                });
                return Ok(physical_Location);
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] physicalLocationBody physical_Location)
        {
            try
            {
                physical_Location.physical_Location.physical_location_id = Guid.NewGuid();
                physicalLocationManager.Current.Add(physical_Location.physical_Location);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_Location.physical_Location.physical_location_id,
                    user_id = physical_Location.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la informacion del location con id: {physical_Location.physical_Location.physical_location_id}"
                });
                return Ok();
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_Location.physical_Location.physical_location_id,
                    user_id = physical_Location.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = physical_Location.physical_Location.physical_location_id,
                    user_id = physical_Location.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] physicalLocationBody physical_Location)
        {
            try
            {
                physicalLocationManager.Current.Update(physical_Location.physical_Location);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_Location.physical_Location.physical_location_id,
                    user_id = physical_Location.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se realizo el alta del location con id: {physical_Location.physical_Location.physical_location_id}"
                });
                return Ok();
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_Location.physical_Location.physical_location_id,
                    user_id = physical_Location.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = physical_Location.physical_Location.physical_location_id,
                    user_id = physical_Location.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] physicalLocationBody physical_Location)
        {
            try
            {
                physicalLocationManager.Current.Remove(physical_Location.physical_Location.physical_location_id);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_Location.physical_Location.physical_location_id,
                    user_id = physical_Location.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se actualiza el estado enable a false location con id: {physical_Location.physical_Location.physical_location_id}"
                });
                return Ok();
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_Location.physical_Location.physical_location_id,
                    user_id = physical_Location.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = physical_Location.physical_Location.physical_location_id,
                    user_id = physical_Location.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }
    }
}