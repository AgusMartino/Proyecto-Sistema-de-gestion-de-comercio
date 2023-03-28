using Api_control_comercio.Controllers.Logger;
using Api_control_comercio.Entities.ABMs.inventory;
using Api_control_comercio.Entities.ABMs.rawMaterial;
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
    public class rawMaterialController : ApiController
    {
        #region Singleton
        private readonly static rawMaterialController _instance;
        public static rawMaterialController Current { get { return _instance; } }
        static rawMaterialController() { _instance = new rawMaterialController(); }
        private rawMaterialController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll([FromBody] Guid user_id, Guid physical_location)
        {
            try
            {
                List<raw_material> raw_Materials = rawMaterialManager.Current.GetAll();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_location,
                    user_id = user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la lista de materias primas"
                });
                return Ok(raw_Materials);
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_location,
                    user_id = user_id,
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
                    physical_location_id = physical_location,
                    user_id = user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetOneId([FromBody] Guid id, Guid user_id, Guid physical_location)
        {
            try
            {
                raw_material raw_Material = rawMaterialManager.Current.GetOne(id);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_location,
                    user_id = user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la materia prima con id: {id}"
                });
                return Ok(raw_Material);
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_location,
                    user_id = user_id,
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
                    physical_location_id = physical_location,
                    user_id = user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetOneCode([FromBody] string code, Guid user_id, Guid physical_location)
        {
            try
            {
                raw_material raw_Material = rawMaterialManager.Current.GetOneCode(code);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_location,
                    user_id = user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la materia prima con codigo: {code}"
                });
                return Ok(raw_Material);
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_location,
                    user_id = user_id,
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
                    physical_location_id = physical_location,
                    user_id = user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] rawMaterialBody raw_materialBody)
        {
            try
            {
                //Se valida la existencia del codigo nuevo
                if (!rawMaterialManager.Current.ValidationCode(raw_materialBody.raw_Material.raw_material_code))
                {
                    //Se Agrega la materia prima
                    raw_materialBody.raw_Material.raw_material_id = Guid.NewGuid();
                    rawMaterialManager.Current.Add(raw_materialBody.raw_Material);
                    //Se crea el inventario
                    inventaryController.Current.Add(new inventoryBody
                    {
                        Id = Guid.NewGuid(),
                        rawMaterial = raw_materialBody.raw_Material,
                        quantity = 0,
                        physical_location_id = raw_materialBody.location
                    });
                    LoggerController.Current.Add(new logs
                    {
                        log_id = Guid.NewGuid(),
                        log_type = "Informational",
                        physical_location_id = raw_materialBody.location,
                        user_id = raw_materialBody.user_id,
                        creation_date = DateTime.Now,
                        log_detail = $"Se realizo el alta de la materia prima con id : {raw_materialBody.raw_Material.raw_material_id}"
                    });
                    return Ok();
                }
                else
                {
                    throw new AlreadyExistsMaterialException();
                }
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = raw_materialBody.location,
                    user_id = raw_materialBody.user_id,
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
                    physical_location_id = raw_materialBody.location,
                    user_id = raw_materialBody.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] rawMaterialBody raw_materialBody)
        {
            try
            {
                raw_materialBody.raw_Material.modification_date = DateTime.Now;
                rawMaterialManager.Current.Update(raw_materialBody.raw_Material);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = raw_materialBody.location,
                    user_id = raw_materialBody.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se realizo la actualizacion de informacion de la materia prima con id : {raw_materialBody.raw_Material.raw_material_id}"
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
                    physical_location_id = raw_materialBody.location,
                    user_id = raw_materialBody.user_id,
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
                    physical_location_id = raw_materialBody.location,
                    user_id = raw_materialBody.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] rawMaterialBody raw_materialBody)
        {
            try
            {
                //Se cambia el estado enable a false
                rawMaterialManager.Current.Remove(raw_materialBody.raw_Material.raw_material_id);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = raw_materialBody.location,
                    user_id = raw_materialBody.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se realizo la actualizacion del estado enable a false de la materia prima con id : {raw_materialBody.raw_Material.raw_material_id}"
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
                    physical_location_id = raw_materialBody.location,
                    user_id = raw_materialBody.user_id,
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
                    physical_location_id = raw_materialBody.location,
                    user_id = raw_materialBody.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }
    }
}