using Api_control_comercio.Controllers.Logger;
using Api_control_comercio.Entities.ABMs.Supplier;
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
    public class supplierController : ApiController
    {
        #region Singleton
        private readonly static supplierController _instance;
        public static supplierController Current { get { return _instance; } }
        static supplierController() { _instance = new supplierController(); }
        private supplierController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll([FromBody] Guid location, Guid user)
        {
            try
            {
                List<supplier> suppliers = new List<supplier>();
                suppliers = supplierManager.Current.GetAll();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la lista de proveedores"
                });
                return Ok(suppliers);
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
                return NotFound();
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
        public IHttpActionResult GetAllLocation([FromBody] Guid location, Guid user)
        {
            try
            {
                List<supplier> suppliers = new List<supplier>();
                suppliers = supplierManager.Current.GetAllLocation(location);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la lista de proveedores del location con id: {location}"
                });
                return Ok(suppliers);
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
                return NotFound();
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
        public IHttpActionResult GetOne([FromBody] Guid location, Guid user, Guid supplier_id)
        {
            try
            {
                supplier supplier = supplierManager.Current.GetOne(supplier_id);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo el proveedor con id: {supplier_id}"
                });
                return Ok(supplier);
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
                    log_detail = $"Se obtuvo el proveedor con id: {supplier_id}"
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
                    log_detail = $"Se obtuvo el proveedor con id: {supplier_id}"
                });
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] supplierBody supplier)
        {
            try
            {
                supplier.Supplier.supplier_id = Guid.NewGuid(); 
                supplierManager.Current.Add(supplier.Supplier);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = supplier.Supplier.physical_location_id,
                    user_id = supplier.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se realizo el alta del proveedor con id: {supplier.Supplier.physical_location_id}"
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
                    physical_location_id = supplier.Supplier.physical_location_id,
                    user_id = supplier.user_id,
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
                    physical_location_id = supplier.Supplier.physical_location_id,
                    user_id = supplier.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] supplierBody supplier)
        {
            try
            {
                supplierManager.Current.Update(supplier.Supplier);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = supplier.Supplier.physical_location_id,
                    user_id = supplier.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se actualizo la informacion del proveedor con id: {supplier.Supplier.physical_location_id}"
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
                    physical_location_id = supplier.Supplier.physical_location_id,
                    user_id = supplier.user_id,
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
                    physical_location_id = supplier.Supplier.physical_location_id,
                    user_id = supplier.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromUri] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}