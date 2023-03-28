using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Gestor_de_abms
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
            using (var db = new sistema_control_comercio())
            {
                db.payment_method.Add(obj);
                db.SaveChanges();
            }
        }

        public List<payment_method> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.payment_method.ToList();
            }
        }

        public payment_method GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.payment_method.ToList().Where(x => x.payment_method_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(payment_method obj)
        {
            throw new NotImplementedException();
        }
    }
}