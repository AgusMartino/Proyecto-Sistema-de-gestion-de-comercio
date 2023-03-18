using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public class rawMaterialManager : IGenericCRUD<raw_material>
    {
        #region singleton
        private readonly static rawMaterialManager _instance = new rawMaterialManager();
        public static rawMaterialManager Current
        {
            get
            {
                return _instance;
            }
        }
        private rawMaterialManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(raw_material obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.raw_material.Add(obj);
                db.SaveChanges();
            }
        }
        public List<raw_material> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                List<raw_material> raw_Materials = new List<raw_material>();
                raw_Materials = db.raw_material.Where(x => x.enable == true).ToList();
                return raw_Materials;
            }
        }
        public raw_material GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.raw_material.ToList().Where(x => x.raw_material_id == id && x.enable == true).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }
        public raw_material GetOneCode(string code)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.raw_material.ToList().Where(x => x.raw_material_code == code && x.enable == true).FirstOrDefault();

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
        public void Update(raw_material obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.raw_material.SingleOrDefault(b => b.raw_material_id == obj.raw_material_id);
                if (obj_db == null) throw new NotFoundException();
                else
                {
                    db.Entry(obj_db).CurrentValues.SetValues(obj);
                    db.SaveChanges();
                }
            }
        }
        public bool ValidationCode(string code)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.raw_material.Where(x => x.raw_material_code == code).FirstOrDefault();
                if (obj == null)
                {
                    return false;
                }
                else return true;
            }
        }
    }
}