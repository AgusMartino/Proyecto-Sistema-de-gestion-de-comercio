using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public sealed class categoryManager : IGenericCRUD<category>
    {
        #region singleton
        private readonly static categoryManager _instance = new categoryManager();
        public static categoryManager Current
        {
            get
            {
                return _instance;
            }
        }
        private categoryManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(category obj)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                db.category.Add(obj);
                db.SaveChanges();
            }
        }

        public List<category> GetAll()
        {
            using (var db = new sistema_control_comercioEntities())
            {
                return db.category.ToList();
            }
        }

        public category GetOne(Guid id)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                var obj = db.category.ToList().Where(x => x.category_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercioEntities())
            {
                db.category.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(category obj)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                var obj_db = db.category.SingleOrDefault(b => b.category_id == obj.category_id);
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