using Api_control_comercio.Controllers.Gestor_de_usuarios;
using Api_control_comercio.Controllers.Logger;
using Api_control_comercio.Entities.ABMs.Category;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using Api_control_comercio.Utils.Manager.Gestor_de_abms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace Api_control_comercio.Controllers.Gestor_de_abms
{
    public class categoryController : ApiController
    {
        #region Singleton
        private readonly static categoryController _instance;
        public static categoryController Current { get { return _instance; } }
        static categoryController() { _instance = new categoryController(); }
        private categoryController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll([FromBody] Guid user_id, Guid physical_location)
        {
            try
            {
                List<category> categoryList = categoryManager.Current.GetAllLocation(physical_location);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_location,
                    user_id = user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la lista de categorias del location con id: {physical_location}"
                });
                return Ok(categoryList);
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
        public IHttpActionResult GetOne([FromBody] Guid category_id, Guid user_id)
        {
            try
            {
                category category = categoryManager.Current.GetOne(category_id);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = category.physical_location_id,
                    user_id = user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la informacion de la categoria con id: {category.category_id}"
                });
                return Ok(category);
            }
            catch (NotFoundException)
            {
                user user = new user();
                user = userController.Current.GetOne(user_id);
                employeeBody employee = new employeeBody();
                employee = (employeeBody)employeeController.Current.GetOne((Guid)user.employee_id);
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = employee.physical_location_id,
                    user_id = user.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                user user = new user();
                user = userController.Current.GetOne(user_id);
                employeeBody employee = new employeeBody();
                employee = (employeeBody)employeeController.Current.GetOne((Guid)user.employee_id);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = employee.physical_location_id,
                    user_id = user.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] categoryBody category)
        {
            try
            {
                category.category.category_id = Guid.NewGuid();
                categoryManager.Current.Add(category.category);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = category.category.physical_location_id,
                    user_id = category.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se Realizo el Alta de la categoria {category.category.category_id}"
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
                    physical_location_id = category.category.physical_location_id,
                    user_id = category.user_id,
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
                    physical_location_id = category.category.physical_location_id,
                    user_id = category.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] categoryBody category)
        {
            try
            {
                category.category.modification_date = DateTime.Now;
                categoryManager.Current.Update(category.category);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = category.category.physical_location_id,
                    user_id = category.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se Realizo la actualizacion de la informacion de la categoria {category.category.category_id}"
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
                    physical_location_id = category.category.physical_location_id,
                    user_id = category.user_id,
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
                    physical_location_id = category.category.physical_location_id,
                    user_id = category.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] categoryBody category)
        {
            try
            {
                categoryManager.Current.Remove(category.category.category_id);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = category.category.physical_location_id,
                    user_id = category.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se cambio el estado enable a false de la categoria {category.category.category_id}"
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
                    physical_location_id = category.category.physical_location_id,
                    user_id = category.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString(),
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = category.category.physical_location_id,
                    user_id = category.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString(),
                });
                return InternalServerError(ex);
            }
        }
    }
}