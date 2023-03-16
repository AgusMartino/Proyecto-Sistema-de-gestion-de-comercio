using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public sealed class companyManager : IGenericCRUD<company>
    {
        #region singleton
        private readonly static companyManager _instance = new companyManager();
        public static companyManager Current
        {
            get
            {
                return _instance;
            }
        }
        private companyManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(company obj)
        {
            using(var db = new sistema_control_comercio())
            {
                db.company.Add(obj);
                db.SaveChanges();
            }
        }

        public List<company> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.company.ToList();
            }
        }

        public company GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.company.ToList().Where(x => x.company_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using(var db = new sistema_control_comercio())
            {
                db.company.Attach(obj);
                db.company.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(company obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.company.SingleOrDefault(b => b.company_id == obj.company_id);
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