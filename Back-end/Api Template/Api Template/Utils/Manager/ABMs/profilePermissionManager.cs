using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public sealed class profilePermissionManager : IGenericCRUD<profile_permission>
    {
        #region singleton
        private readonly static profilePermissionManager _instance = new profilePermissionManager();
        public static profilePermissionManager Current
        {
            get
            {
                return _instance;
            }
        }
        private profilePermissionManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(profile_permission obj)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                db.profile_permission.Add(obj);
                db.SaveChanges();
            }
        }

        public List<profile_permission> GetAll()
        {
            using (var db = new sistema_control_comercioEntities())
            {
                return db.profile_permission.ToList();
            }
        }

        public profile_permission GetOne(Guid id)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                var obj = db.profile_permission.ToList().Where(x => x.profile_permission_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercioEntities())
            {
                db.profile_permission.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(profile_permission obj)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                var obj_db = db.profile_permission.SingleOrDefault(b => b.profile_permission_id == obj.profile_permission_id);
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