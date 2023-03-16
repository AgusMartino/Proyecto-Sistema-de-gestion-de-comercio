using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Ventas
{
    public sealed class SaleOrderManager : IGenericCRUD<sale_order>
    {
        #region singleton
        private readonly static SaleOrderManager _instance = new SaleOrderManager();
        public static SaleOrderManager Current
        {
            get
            {
                return _instance;
            }
        }
        private SaleOrderManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(sale_order obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.sale_order.Add(obj);
                db.SaveChanges();
            }
        }

        public List<sale_order> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.sale_order.ToList();
            }
        }

        public sale_order GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.sale_order.ToList().Where(x => x.sale_order_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercio())
            {
                db.sale_order.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(sale_order obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.sale_order.SingleOrDefault(b => b.sale_order_id == obj.sale_order_id);
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