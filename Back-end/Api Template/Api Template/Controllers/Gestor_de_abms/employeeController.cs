using Api_control_comercio.Controllers.Logger;
using Api_control_comercio.Entities.ABMs.Employee;
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
    public class employeeController : ApiController
    {
        #region Singleton
        private readonly static employeeController _instance;
        public static employeeController Current { get { return _instance; } }
        static employeeController() { _instance = new employeeController(); }
        private employeeController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll([FromBody] Guid location, Guid user)
        {
            try
            {
                List<employee> employees = employeeManager.Current.GetAllLocation(location);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la lista de empleados del location con id: {location}"
                });
                return Ok(employees);
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
        public IHttpActionResult GetOne([FromBody] Guid employee_id, Guid user, Guid location)
        {
            try
            {
                employee employee = employeeManager.Current.GetOne(employee_id);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = employee.physical_location_id,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo el empleado con id: {employee_id}"
                });
                return Ok(employee);
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

        [HttpPost]
        public IHttpActionResult Add([FromBody] EmployeeBody employee)
        {
            try
            {
                employee.employee.employee_id = Guid.NewGuid();
                employeeManager.Current.Add(employee.employee);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = employee.employee.physical_location_id,
                    user_id = employee.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se dio el alta del empleado con id: {employee.employee.employee_id}"
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
                    physical_location_id = employee.employee.physical_location_id,
                    user_id = employee.user_id,
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
                    physical_location_id = employee.employee.physical_location_id,
                    user_id = employee.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] EmployeeBody employee)
        {
            try
            {
                employee.employee.modification_date = DateTime.Now;
                employeeManager.Current.Update(employee.employee);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = employee.employee.physical_location_id,
                    user_id = employee.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se actualizo la informacion del empleado con id: {employee.employee.employee_id}"
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
                    physical_location_id = employee.employee.physical_location_id,
                    user_id = employee.user_id,
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
                    physical_location_id = employee.employee.physical_location_id,
                    user_id = employee.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] EmployeeBody employee)
        {
            try
            {
                employeeManager.Current.Remove(employee.employee.employee_id);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = employee.employee.physical_location_id,
                    user_id = employee.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se puso el enable en false del empleado con id: {employee.employee.employee_id}"
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
                    physical_location_id = employee.employee.physical_location_id,
                    user_id = employee.user_id,
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
                    physical_location_id = employee.employee.physical_location_id,
                    user_id = employee.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }
    }
}