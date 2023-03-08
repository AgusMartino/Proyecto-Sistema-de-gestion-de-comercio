using System;
using System.Collections.Generic;
using System.Linq;
using Api_Template.Contracts;
using Api_Template.Entities;
using Api_Template.Entities.Exceptions;
using Api_Template.Models.Template;

namespace Api_Template.Utils
{
    public class UserManager : IGenericCRUD<Usuario>
    {
        #region Singleton
        private readonly static UserManager _instance;
        public static UserManager Current { get { return _instance; } }
        static UserManager() { _instance = new UserManager(); }
        private UserManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public LoginResponse Login(string username, string password)
        {
            using(var db = new TemplateEntities())
            {
                var usuario = db.Usuario.Where(x =>
                    x.Nombre_Usuario == username &&
                    x.Contraseña == password).ToList().FirstOrDefault();

                if (usuario == null) throw new NotFoundException();

                var token = TokenManager.Current.RefreshToken(usuario.Id_usuario);

                return new LoginResponse() { 
                    user = usuario, 
                    token = token };
            }
        }
        public void Logout(string username)
        {
            var usuario = GetAll().Where(x => 
                x.Nombre_Usuario == username).ToList().FirstOrDefault();

            if (usuario == null) throw new NotFoundException();

            var token = TokenManager.Current.GetAll().Where(x =>
                x.Id_usuario == usuario.Id_usuario).FirstOrDefault();

            if (token == null) throw new NotFoundException();

            TokenManager.Current.Remove(token.Id_token);
        }
        public void SignUp(Usuario user)
        {
            Add(user);
        }
        public Usuario GetOne(Guid id)
        {
            using (var db = new TemplateEntities())
            {
                var obj = db.Usuario.ToList().Where(x => x.Id_usuario == id).FirstOrDefault();

                if(obj == null) throw new NotFoundException();
                else return obj;
            }
        }
        public List<Usuario> GetAll()
        {
            using (var db = new TemplateEntities())
            {
                return db.Usuario.ToList();
            }
        }
        public void Add(Usuario obj)
        {
            using (var db = new TemplateEntities())
            {
                var coincidencias = GetAll().Where(x => x.Nombre_Usuario == obj.Nombre_Usuario);

                if(coincidencias.Count() == 0)
                {
                    db.Usuario.Add(obj);
                    db.SaveChanges();
                }
                else throw new AlreadyExistsException();
            }
        }
        public void Update(Usuario obj)
        {
            using (var db = new TemplateEntities())
            {
                var db_obj = db.Usuario.SingleOrDefault(b => b.Id_usuario == obj.Id_usuario);

                if (db_obj != null)
                {
                    if(db_obj.Nombre_Usuario != obj.Nombre_Usuario)
                    {
                        var coincidencias = GetAll().Where(x => x.Nombre_Usuario == obj.Nombre_Usuario);

                        if (coincidencias.Count() > 0) throw new AlreadyExistsException();
                    }

                    db.Entry(db_obj).CurrentValues.SetValues(obj);
                    db.SaveChanges();
                }
                else throw new NotFoundException();
            }
        }
        public void Remove(Guid id)
        {
            var obj_db = GetOne(id);
            obj_db.Estado = false;
            Update(obj_db);
        }
        public List<Permiso> GetPermissions(string username)
        {
            var user = GetAll().Where(x=>x.Nombre_Usuario == username).FirstOrDefault();

            if (user == null) throw new NotFoundException();

            using (var db = new TemplateEntities())
            {
                var userPermissions = db.Usuario_Permiso.Where(x=>x.Id_usuario == user.Id_usuario).ToList();
                var ids = userPermissions.Select(x => x.Id_permiso);

                var permissions = PermissionManager.Current.GetAll()
                    .Where(x=>ids.Contains(x.Id_permiso)).ToList();

                return permissions;
            }
        }
        public void UpdatePermissions(string username, List<Guid> permissions)
        {
            var user = GetAll().Where(x => x.Nombre_Usuario == username).FirstOrDefault();

            if (user == null) throw new NotFoundException();

            var db_permissions = GetPermissions(username);

            using (var db = new TemplateEntities())
            {
                db_permissions.ForEach(x => 
                {
                    var obj_db = db.Usuario_Permiso.Where(y=> y.Id_permiso == x.Id_permiso).First();
                    db.Usuario_Permiso.Remove(obj_db);
                });

                permissions.ForEach(x => 
                { 
                    db.Usuario_Permiso.Add(
                        new Usuario_Permiso() 
                        { 
                            Id_usuario = user.Id_usuario, 
                            Id_permiso = x
                        });
                });

                db.SaveChanges();
            }
        }
    }
}