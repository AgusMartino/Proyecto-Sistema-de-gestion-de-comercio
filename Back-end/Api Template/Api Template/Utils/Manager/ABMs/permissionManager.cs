using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public class permissionManager : IGenericCRUD<permission>
    {
        #region singleton
        private readonly static permissionManager _instance = new permissionManager();

        public static permissionManager Current
        {
            get
            {
                return _instance;
            }
        }

        private permissionManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(permission obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.permission.Add(obj);
                db.SaveChanges();
            }
        }

        public List<permission> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.permission.ToList();
            }
        }

        public permission GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.permission.ToList().Where(x => x.permission_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercio())
            {
                db.permission.Attach(obj);
                db.permission.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(permission obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.permission.SingleOrDefault(b => b.permission_id == obj.permission_id);
                if (obj_db == null) throw new NotFoundException();
                else
                {
                    db.Entry(obj_db).CurrentValues.SetValues(obj);
                    db.SaveChanges();
                }
            }
        }
    }
}