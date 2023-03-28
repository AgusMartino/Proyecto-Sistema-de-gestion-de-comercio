using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Gestor_de_usuarios
{
    public sealed class userManager : IGenericCRUD<user>
    {
        #region singleton
        private readonly static userManager _instance = new userManager();
        public static userManager Current
        {
            get
            {
                return _instance;
            }
        }

        private userManager()
        {
             //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(user obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.user.Add(obj);
                db.SaveChanges();
            }
        }

        public List<user> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.user.ToList();
            }
        }

        public user GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.user.ToList().Where(x => x.user_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercio())
            {
                db.user.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(user obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.user.SingleOrDefault(b => b.user_id == obj.user_id);
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