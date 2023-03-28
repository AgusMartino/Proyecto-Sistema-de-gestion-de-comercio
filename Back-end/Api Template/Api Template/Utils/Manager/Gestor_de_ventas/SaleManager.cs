using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Gestor_de_ventas
{
    public sealed class SaleManager : IGenericCRUD<sale>
    {
        #region singleton
        private readonly static SaleManager _instance = new SaleManager();
        public static SaleManager Current
        {
            get
            {
                return _instance;
            }
        }
        private SaleManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(sale obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.sale.Add(obj);
                db.SaveChanges();
            }
        }

        public List<sale> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.sale.ToList();
            }
        }

        public List<sale> GetAllLocation(Guid location)
        {
            using (var db = new sistema_control_comercio())
            {
                return db.sale.Where(x => x.physical_location_id == location).ToList();
            }
        }
        public List<sale> GetAllLocationEmployee(Guid location, Guid employee)
        {
            using (var db = new sistema_control_comercio())
            {
                return db.sale.Where(x => x.physical_location_id == location && x.employee_id == employee).ToList();
            }
        }

        public sale GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.sale.ToList().Where(x => x.sale_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercio())
            {
                db.sale.Attach(obj);
                db.sale.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(sale obj)
        {
            throw new NotImplementedException();
        }
    }
}