using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Pagos
{
    public sealed class paymentSupplierManager : IGenericCRUD<payment_suppliers>
    {
        #region singleton
        private readonly static paymentSupplierManager _instance = new paymentSupplierManager();
        public static paymentServiceManager Current
        {
            get
            {
                return _instance;
            }
        }
        private paymentSupplierManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(payment_suppliers obj)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                db.payment_suppliers.Add(obj);
                db.SaveChanges();
            }
        }

        public List<payment_suppliers> GetAll()
        {
            using (var db = new sistema_control_comercioEntities())
            {
                return db.payment_suppliers.ToList();
            }
        }

        public payment_suppliers GetOne(Guid id)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                var obj = db.payment_suppliers.ToList().Where(x => x.payment_suppliers_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercioEntities())
            {
                db.payment_suppliers.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(payment_suppliers obj)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                var obj_db = db.payment_suppliers.SingleOrDefault(b => b.payment_suppliers_id == obj.payment_suppliers_id);
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