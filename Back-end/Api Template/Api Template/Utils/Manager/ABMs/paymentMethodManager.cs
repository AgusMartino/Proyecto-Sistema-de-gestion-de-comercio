using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public sealed class paymentMethodManager : IGenericCRUD<payment_method>
    {
        #region singleton
        private readonly static paymentMethodManager _instance = new paymentMethodManager();
        public static paymentMethodManager Current
        {
            get
            {
                return _instance;
            }
        }
        private paymentMethodManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion
        public void Add(payment_method obj)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                db.payment_method.Add(obj);
                db.SaveChanges();
            }
        }

        public List<payment_method> GetAll()
        {
            using (var db = new sistema_control_comercioEntities())
            {
                return db.payment_method.ToList();
            }
        }

        public payment_method GetOne(Guid id)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                var obj = db.payment_method.ToList().Where(x => x.payment_method_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercioEntities())
            {
                db.payment_method.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(payment_method obj)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                var obj_db = db.payment_method.SingleOrDefault(b => b.payment_method_id == obj.payment_method_id);
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