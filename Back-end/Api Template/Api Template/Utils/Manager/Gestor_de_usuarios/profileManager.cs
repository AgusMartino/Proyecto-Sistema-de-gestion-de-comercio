using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Gestor_de_usuarios
{
    public class profileManager : IGenericCRUD<profile>
    {
        #region singleton
        private readonly static profileManager _instance = new profileManager();

        public static profileManager Current
        {
            get
            {
                return _instance;
            }
        }

        private profileManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(profile obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.profile.Add(obj);
                db.SaveChanges();
            }
        }

        public List<profile> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.profile.ToList();
            }
        }

        public profile GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.profile.ToList().Where(x => x.profile_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercio())
            {
                db.profile.Attach(obj);
                db.profile.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(profile obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.profile.SingleOrDefault(b => b.profile_id == obj.profile_id);
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