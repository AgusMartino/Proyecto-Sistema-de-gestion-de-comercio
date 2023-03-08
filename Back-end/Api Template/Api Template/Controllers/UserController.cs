using System;
using System.Collections.Generic;
using System.Web.Http;
using Api_Template.Entities;
using Api_Template.Models.Template;
using Api_Template.Utils;
using Api_Template.Entities.Exceptions;
using Api_Template.Contracts;

namespace Api_Template.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    public class UserController : ApiController
    {
        #region Singleton
        private readonly static UserController _instance;
        public static UserController Current { get { return _instance; } }
        static UserController() { _instance = new UserController(); }
        private UserController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Login([FromBody] LoginBody login)
        {
            try //Si retorna null, return NotFound()
            {
                var response = UserManager.Current.Login(login.username, login.password);
                return Ok(response);
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        public IHttpActionResult Logout([FromBody] string username)
        {
            try
            {
                UserManager.Current.Logout(username);
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

        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult SignUp([FromBody] Usuario user)
        {
            try
            {
                UserManager.Current.SignUp(user);
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

        [HttpGet]
        public IHttpActionResult GetOne([FromBody] Guid id)
        {
            try
            {
                return Ok(UserManager.Current.GetOne(id));
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
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(UserManager.Current.GetAll());
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
        public IHttpActionResult Add([FromBody] Usuario user)
        {
            try
            {
                UserManager.Current.Add(user);
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
        public IHttpActionResult Update([FromBody] Usuario user)
        {
            try
            {
                UserManager.Current.Update(user);
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
        public IHttpActionResult Remove([FromBody] Guid id)
        {
            try //update estado 0
            {
                UserManager.Current.Remove(id);
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

        [HttpGet]
        public IHttpActionResult GetPermissions([FromBody] string username)
        {
            try
            {
                return Ok(UserManager.Current.GetPermissions(username));
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
        public IHttpActionResult UpdatePermissions([FromBody] UserPermissionsBody userdata)
        {
            try
            {
                UserManager.Current.UpdatePermissions(userdata.Username, userdata.Permissions);
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