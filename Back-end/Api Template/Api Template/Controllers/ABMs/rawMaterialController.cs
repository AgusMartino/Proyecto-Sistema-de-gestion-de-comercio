using Api_control_comercio.Entities.ABMs.rawMaterial;
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
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(rawMaterialManager.Current.GetAll());
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
        public IHttpActionResult GetOneId([FromUri] Guid id)
        {
            try
            {
                return Ok(rawMaterialManager.Current.GetOne(id));
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
        public IHttpActionResult GetOneCode([FromUri] string code)
        {
            try
            {
                return Ok(rawMaterialManager.Current.GetOneCode(code));
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
        public IHttpActionResult Add([FromBody] rawMaterialBodyAdd raw_materialBody)
        {
            try
            {
                //Se valida la existencia del codigo nuevo
                if (!rawMaterialManager.Current.ValidationCode(raw_materialBody.raw_material_code))
                {
                    //Se Agrega la materia prima
                    rawMaterialManager.Current.Add(new raw_material
                    {
                        raw_material_id = raw_materialBody.raw_material_id,
                        raw_material_code = raw_materialBody.raw_material_code,
                        raw_material_cost = raw_materialBody.raw_material_cost,
                        raw_material_name = raw_materialBody.raw_material_name
                    });
                    //Se crea el inventario
                    inventaryController.Current.Add(new inventary
                    {
                        inventary_id = Guid.NewGuid(),
                        raw_material_id = raw_materialBody.raw_material_id,
                        quantity = 0,
                        physical_location_id = raw_materialBody.physical_location_id
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
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] raw_material raw_material)
        {
            try
            {
                raw_material.modification_date = DateTime.Now;
                rawMaterialManager.Current.Update(raw_material);
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
                //Se cambia el estado enable a false
                rawMaterialManager.Current.Remove(id);
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

        internal raw_material GetOneId(Guid? raw_material_id)
        {
            throw new NotImplementedException();
        }
    }
}