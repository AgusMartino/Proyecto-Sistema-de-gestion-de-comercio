using Api_control_comercio.Controllers.Logger;
using Api_control_comercio.Entities.ABMs.inventory;
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
        public IHttpActionResult GetAll([FromBody] Guid location, Guid user)
        {
            try
            {
                List<inventoryBody> inventories = inventoryManager.Current.GetAllLocation(location);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la lista de inventarios del location con id: {location}"
                });
                return Ok(inventories);
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
        public IHttpActionResult GetOne([FromBody] Guid location, Guid user, Guid inventary_id)
        {
            try
            {
                inventoryBody inventoryBody = inventoryManager.Current.GetOne(inventary_id); 
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo el inventario con id {inventary_id}"
                });
                return Ok(inventoryBody);
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

        public IHttpActionResult GetOneLocationMaterial([FromBody] Guid location, Guid material, Guid user)
        {
            try
            {
                inventoryBody inventoryBody = inventoryManager.Current.GetOneLocationMaterial(location, material);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo el inveentario del location con id: {location} y materia prima con id: {material}"
                });
                return Ok(inventoryBody);
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
        public IHttpActionResult Add([FromBody]inventoryBody inventary)
        {
            try
            {
                inventoryManager.Current.Add(inventary);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se agrego un nuevo inventario de la materia prima con id: {inventary.rawMaterial.raw_material_id} y del location con id: {inventary.inventary.physical_location_id}"
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
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
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
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] inventoryBody inventary)
        {
            try
            {
                inventoryManager.Current.Update(inventary);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se actualizo el inventario de la materia prima con id: {inventary.rawMaterial.raw_material_id} y del location con id: {inventary.inventary.physical_location_id}"
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
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
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
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] inventoryBody inventary)
        {
            try
            {
                inventoryManager.Current.Remove(inventary.inventary.inventary_id);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se elimino el inventario de la materia prima con id: {inventary.rawMaterial.raw_material_id} y del location con id: {inventary.inventary.physical_location_id}"
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
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
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
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult AddInventary([FromBody] inventoryBody inventary)
        {
            try
            {
                inventoryBody inventoryOld = new inventoryBody();
                inventoryOld = (inventoryBody)GetOne((Guid)inventary.inventary.physical_location_id,inventary.user_id,inventary.inventary.inventary_id);

                inventary.inventary.quantity = inventoryOld.inventary.quantity + inventary.inventary.quantity;

                Update(inventary);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se Agrego cantidad al inventario de la materia prima con id: {inventary.rawMaterial.raw_material_id} y del location con id: {inventary.inventary.physical_location_id}"
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
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
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
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult RemoveInventary([FromBody] inventoryBody inventary)
        {
            try
            {
                inventoryBody inventoryOld = new inventoryBody();
                inventoryOld = (inventoryBody)GetOne((Guid)inventary.inventary.physical_location_id, inventary.user_id, inventary.inventary.inventary_id);

                inventary.inventary.quantity = inventoryOld.inventary.quantity - inventary.inventary.quantity;

                Update(inventary);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se Quito cantidad al inventario de la materia prima con id: {inventary.rawMaterial.raw_material_id} y del location con id: {inventary.inventary.physical_location_id}"
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
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
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
                    physical_location_id = inventary.inventary.physical_location_id,
                    user_id = inventary.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }
    }
}