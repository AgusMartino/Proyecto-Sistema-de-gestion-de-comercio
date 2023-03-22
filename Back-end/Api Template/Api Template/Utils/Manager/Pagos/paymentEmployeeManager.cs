using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.ABMs.Pagos;
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

        public List<payment_employee> GetAllLocation(Guid location)
        {
            using (var db = new sistema_control_comercio())
            {
                var query = from x in db.payment_employee
                            join y in db.employee on x.employee_id equals y.employee_id
                            where y.physical_location_id == location
                            select new payment_employee
                            {
                                payment_employee_id = x.payment_employee_id,
                                employee_id = x.employee_id,
                                payment_employee_price = x.payment_employee_price,
                                creation_date = x.creation_date,
                                modification_date = x.modification_date
                            };
                List<payment_employee> result = query.ToList();
                return result;
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
            throw new NotImplementedException();
        }
    }
}