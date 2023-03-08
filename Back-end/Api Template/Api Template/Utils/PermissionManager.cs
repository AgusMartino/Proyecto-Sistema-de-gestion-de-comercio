using System.Collections.Generic;
using Api_Template.Models.Template;
using Api_Template.Entities;
using Api_Template.Contracts;
using System;
using Api_Template.Entities.Exceptions;
using System.Linq;

namespace Api_Template.Utils
{
    public class PermissionManager : IGenericCRUD<Permiso>
    {
        #region Singleton
        private readonly static PermissionManager _instance;
        public static PermissionManager Current { get { return _instance; } }
        static PermissionManager() { _instance = new PermissionManager(); }
        private PermissionManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Permiso GetOne(Guid id)
        {
            using (var db = new TemplateEntities())
            {
                var obj = db.Permiso.ToList().Where(x => x.Id_permiso == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }
        public List<Permiso> GetAll()
        {
            using (var db = new TemplateEntities())
            {
                return db.Permiso.ToList();
            }
        }
        public void Add(Permiso obj)
        {
            using (var db = new TemplateEntities())
            {
                db.Permiso.Add(obj);
                db.SaveChanges();
            }
        }
        public void Update(Permiso obj)
        {
            using (var db = new TemplateEntities())
            {
                var db_obj = db.Permiso.SingleOrDefault(b => b.Id_permiso == obj.Id_permiso);

                if (db_obj != null)
                {
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

            //Elimino relacion de usuario_permiso
            using (var db = new TemplateEntities())
            {
                var db_relaciones = db.Usuario_Permiso.Where(b => b.Id_permiso == id).ToList();

                db_relaciones.ForEach(x=> db.Usuario_Permiso.Remove(x));

                db.SaveChanges();
            }
        }
    }
}