using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public sealed class productRawMaterialManager : IGenericCRUD<product_rawmaterial>
    {
        #region singleton
        private readonly static productRawMaterialManager _instance = new productRawMaterialManager();
        public static productRawMaterialManager Current
        {
            get
            {
                return _instance;
            }
        }
        private productRawMaterialManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(product_rawmaterial obj)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                db.product_rawmaterial.Add(obj);
                db.SaveChanges();
            }
        }

        public List<product_rawmaterial> GetAll()
        {
            using (var db = new sistema_control_comercioEntities())
            {
                return db.product_rawmaterial.ToList();
            }
        }

        public product_rawmaterial GetOne(Guid id)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                var obj = db.product_rawmaterial.ToList().Where(x => x.product_rawmaterial_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercioEntities())
            {
                db.product_rawmaterial.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(product_rawmaterial obj)
        {
            using (var db = new sistema_control_comercioEntities())
            {
                var obj_db = db.product_rawmaterial.SingleOrDefault(b => b.product_rawmaterial_id == obj.product_rawmaterial_id);
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