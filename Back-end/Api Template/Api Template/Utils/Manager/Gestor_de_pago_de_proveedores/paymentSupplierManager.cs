using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Gestor_de_pago_de_proveedores
{
    public sealed class paymentSupplierManager : IGenericCRUD<payment_suppliers>
    {
        #region singleton
        private readonly static paymentSupplierManager _instance = new paymentSupplierManager();
        public static paymentSupplierManager Current
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
            using (var db = new sistema_control_comercio())
            {
                db.payment_suppliers.Add(obj);
                db.SaveChanges();
            }
        }

        public List<payment_suppliers> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.payment_suppliers.ToList();
            }
        }

        public List<payment_suppliers> GetAllLocation(Guid Location)
        {
            using (var db = new sistema_control_comercio())
            {
                return db.payment_suppliers.Where(x => x.physical_location_id == Location).ToList();
            }
        }

        public List<payment_suppliers> GetAllsupplier(Guid supplier)
        {
            using (var db = new sistema_control_comercio())
            {
                return db.payment_suppliers.Where(x => x.supplier_id == supplier).ToList();
            }
        }

        public payment_suppliers GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.payment_suppliers.ToList().Where(x => x.payment_suppliers_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercio())
            {
                db.payment_suppliers.Attach(obj);
                db.payment_suppliers.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(payment_suppliers obj)
        {
            throw new NotImplementedException();
        }
    }
}