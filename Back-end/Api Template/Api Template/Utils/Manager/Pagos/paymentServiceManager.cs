using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Pagos
{
    public sealed class paymentServiceManager : IGenericCRUD<payment_service>
    {
        #region singleton
        private readonly static paymentServiceManager _instance = new paymentServiceManager();
        public static paymentServiceManager Current
        {
            get
            {
                return _instance;
            }
        }
        private paymentServiceManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(payment_service obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.payment_service.Add(obj);
                db.SaveChanges();
            }
        }

        public List<payment_service> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.payment_service.ToList();
            }
        }

        public List<payment_service> GetAllLocation(Guid Location)
        {
            using (var db = new sistema_control_comercio())
            {
                var query = from x in db.payment_service
                            join y in db.service on x.service_id equals y.service_id
                            where y.physical_location_id == Location
                            select new payment_service
                            {
                                payment_service_id = x.payment_service_id,
                                payment_service_price = x.payment_service_price,
                                creation_date = x.creation_date,
                                modification_date = x.modification_date,
                                service_id = x.service_id
                            };
                List<payment_service> result = query.ToList();
                return result;
            }
        }

        public payment_service GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.payment_service.ToList().Where(x => x.payment_service_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercio())
            {
                db.payment_service.Attach(obj);
                db.payment_service.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(payment_service obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.payment_service.SingleOrDefault(b => b.payment_service_id == obj.payment_service_id);
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