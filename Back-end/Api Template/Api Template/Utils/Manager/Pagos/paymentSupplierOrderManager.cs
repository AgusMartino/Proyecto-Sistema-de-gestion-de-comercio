using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Pagos
{
    public sealed class paymentSupplierOrderManager : IGenericCRUD<payment_suppliers_order>
    {
        #region singleton
        private readonly static paymentSupplierOrderManager _instance = new paymentSupplierOrderManager();
        public static paymentSupplierOrderManager Current
        {
            get
            {
                return _instance;
            }
        }
        private paymentSupplierOrderManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(payment_suppliers_order obj)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                db.payment_suppliers_order.Add(obj);
                db.SaveChanges();
            }
        }

        public List<payment_suppliers_order> GetAll()
        {
            using (var db = new sistema_control_comercioEntities())
            {
                return db.payment_suppliers_order.ToList();
            }
        }

        public payment_suppliers_order GetOne(Guid id)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                var obj = db.payment_suppliers_order.ToList().Where(x => x.payment_suppliers_order_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercioEntities())
            {
                db.payment_suppliers_order.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(payment_suppliers_order obj)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                var obj_db = db.payment_suppliers_order.SingleOrDefault(b => b.payment_suppliers_order_id == obj.payment_suppliers_order_id);
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