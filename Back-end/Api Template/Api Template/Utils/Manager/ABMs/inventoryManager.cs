using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public class inventoryManager : IGenericCRUD<inventary>
    {
        #region singleton
        private readonly static inventoryManager _instance = new inventoryManager();
        public static inventoryManager Current
        {
            get
            {
                return _instance;
            }
        }
        private inventoryManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(inventary obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.inventary.Add(obj);
                db.SaveChanges();
            }
        }

        public List<inventary> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.inventary.ToList();
            }
        }

        public inventary GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.inventary.ToList().Where(x => x.inventary_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercio())
            {
                db.inventary.Attach(obj);
                db.inventary.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(inventary obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.inventary.SingleOrDefault(b => b.inventary_id == obj.inventary_id);
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