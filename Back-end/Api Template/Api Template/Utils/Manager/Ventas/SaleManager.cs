using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Ventas
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
                db.sale.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(sale obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.sale.SingleOrDefault(b => b.sale_id == obj.sale_id);
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