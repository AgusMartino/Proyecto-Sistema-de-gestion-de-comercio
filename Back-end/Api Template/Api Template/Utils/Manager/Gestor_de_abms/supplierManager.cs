using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Gestor_de_abms
{
    public class supplierManager : IGenericCRUD<supplier>
    {
        #region singleton
        private readonly static supplierManager _instance = new supplierManager();

        public static supplierManager Current
        {
            get
            {
                return _instance;
            }
        }

        private supplierManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(supplier obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.supplier.Add(obj);
                db.SaveChanges();
            }
        }

        public List<supplier> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.supplier.ToList();
            }
        }

        public List<supplier> GetAllLocation(Guid location)
        {
            using (var db = new sistema_control_comercio())
            {
                return db.supplier.Where(x => x.physical_location_id == location).ToList();
            }
        }

        public supplier GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.supplier.ToList().Where(x => x.supplier_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(supplier obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.supplier.SingleOrDefault(b => b.supplier_id == obj.supplier_id);
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