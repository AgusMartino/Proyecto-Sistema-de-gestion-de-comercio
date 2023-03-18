using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Pagos
{
    public sealed class paymentEmployeeManager : IGenericCRUD<payment_employee>
    {
        #region singleton
        private readonly static paymentEmployeeManager _instance = new paymentEmployeeManager();
        public static paymentEmployeeManager Current
        {
            get
            {
                return _instance;
            }
        }
        private paymentEmployeeManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(payment_employee obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.payment_employee.Add(obj);
                db.SaveChanges();
            }
        }

        public List<payment_employee> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.payment_employee.ToList();
            }
        }

        public payment_employee GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.payment_employee.ToList().Where(x => x.payment_employee_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercio())
            {
                db.payment_employee.Attach(obj);
                db.payment_employee.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(payment_employee obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.payment_employee.SingleOrDefault(b => b.payment_employee_id == obj.payment_employee_id);
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