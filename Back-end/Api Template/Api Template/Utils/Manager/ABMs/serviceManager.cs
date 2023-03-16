using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public sealed class serviceManager : IGenericCRUD<service>
    {
        #region singleton
        private readonly static serviceManager _instance = new serviceManager();

        public static serviceManager Current
        {
            get
            {
                return _instance;
            }
        }

        private serviceManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(service obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.service.Add(obj);
                db.SaveChanges();
            }
        }

        public List<service> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.service.ToList();
            }
        }

        public service GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.service.ToList().Where(x => x.service_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercio())
            {
                db.service.Attach(obj);
                db.service.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(service obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.service.SingleOrDefault(b => b.service_id == obj.service_id);
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