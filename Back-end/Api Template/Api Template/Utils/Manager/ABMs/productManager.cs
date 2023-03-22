using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public class productManager : IGenericCRUD<product>
    {
        #region singleton
        private readonly static productManager _instance = new productManager();
        public static productManager Current
        {
            get
            {
                return _instance;
            }
        }
        private productManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(product obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.product.Add(obj);
                db.SaveChanges();
            }
        }
        public List<product> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.product.ToList();
            }
        }
        public List<product> GetAllProductPhysicalLocation(Guid phisical_location_id)
        {
            using (var db = new sistema_control_comercio())
            {
                List<product> products = new List<product>();
                products = db.product.Where(x => x.physical_location_id == phisical_location_id && x.enable == true).ToList();
                return products;
            }
        }
        public List<product> GetAllProductPhysicalLocationCategory(Guid phisical_location_id, Guid category)
        {
            using (var db = new sistema_control_comercio())
            {
                List<product> products = new List<product>();
                products = db.product.Where(x => x.physical_location_id == phisical_location_id &&
                                            x.category_id == category 
                                            && x.enable == true).ToList();
                return products;
            }
        }
        public product GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.product.ToList().Where(x => x.product_id == id && x.enable == true).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }
        public product GetOneCode(string code)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.product.ToList().Where(x => x.product_code == code && x.enable == true).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }
        public void Remove(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = GetOne(id);
                obj.enable = false;
                Update(obj);
            }
        }
        public void Update(product obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.product.SingleOrDefault(b => b.product_id == obj.product_id);
                if (obj_db == null) throw new NotFoundException();
                else
                {
                    db.Entry(obj_db).CurrentValues.SetValues(obj);
                    db.SaveChanges();
                }
            }
        }
        public bool ValidationCode(string code, Guid physical_location)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.product.Where(x => x.product_code == code && x.physical_location_id == physical_location).FirstOrDefault();
                if(obj == null)
                {
                    return false;
                }
                else return true;
            } 
        }
    }
}