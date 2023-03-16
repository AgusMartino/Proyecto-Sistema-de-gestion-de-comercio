using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public sealed class userPermissionManager : IGenericCRUD<user_permission>
    {
        #region singleton
        private readonly static userPermissionManager _instance = new userPermissionManager();
        public static userPermissionManager Current
        {
            get
            {
                return _instance;
            }
        }
        private userPermissionManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(user_permission obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.user_permission.Add(obj);
                db.SaveChanges();
            }
        }

        public List<user_permission> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.user_permission.ToList();
            }
        }

        public user_permission GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.user_permission.ToList().Where(x => x.user_permission_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercio())
            {
                db.user_permission.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(user_permission obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.user_permission.SingleOrDefault(b => b.user_permission_id == obj.user_permission_id);
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