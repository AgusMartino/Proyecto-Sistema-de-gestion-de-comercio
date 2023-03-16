using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public sealed class userProfileManager : IGenericCRUD<user_profile>
    {
        #region singleton
        private readonly static userProfileManager _instance = new userProfileManager();
        public static userProfileManager Current
        {
            get
            {
                return _instance;
            }
        }
        private userProfileManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(user_profile obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.user_profile.Add(obj);
                db.SaveChanges();
            }
        }

        public List<user_profile> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.user_profile.ToList();
            }
        }

        public user_profile GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.user_profile.ToList().Where(x => x.user_profile_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercio())
            {
                db.user_profile.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(user_profile obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.user_profile.SingleOrDefault(b => b.user_profile_id == obj.user_profile_id);
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