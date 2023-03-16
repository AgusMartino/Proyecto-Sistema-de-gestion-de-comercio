using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public sealed class profileProfileManager : IGenericCRUD<profile_profile>
    {
        #region singleton
        private readonly static profileProfileManager _instance = new profileProfileManager();
        public static profileProfileManager Current
        {
            get
            {
                return _instance;
            }
        }
        private profileProfileManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(profile_profile obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.profile_profile.Add(obj);
                db.SaveChanges();
            }
        }

        public List<profile_profile> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.profile_profile.ToList();
            }
        }

        public profile_profile GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.profile_profile.ToList().Where(x => x.profile_profile_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercio())
            {
                db.profile_profile.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(profile_profile obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.profile_profile.SingleOrDefault(b => b.profile_profile_id == obj.profile_profile_id);
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