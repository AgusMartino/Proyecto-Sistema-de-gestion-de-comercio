using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.ABMs.inventory;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public class inventoryManager : IGenericCRUD<inventoryBody>
    {
        #region singleton
        private readonly static inventoryManager _instance = new inventoryManager();
        public static inventoryManager Current
        {
            get
            {
                return _instance;
            }
        }
        private inventoryManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(inventoryBody obj)
        {
            using (var db = new sistema_control_comercio())
            {
                inventary inventary = new inventary();
                inventary.quantity = obj.quantity;
                inventary.physical_location_id = obj.physical_location_id;
                inventary.raw_material_id = obj.rawMaterial.raw_material_id;
                inventary.inventary_id = obj.Id;
                db.inventary.Add(inventary);
                db.SaveChanges();
            }
        }

        public List<inventoryBody> GetAll()
        {
            throw new NotImplementedException();
        }
        public List<inventoryBody> GetAllLocation(Guid location)
        {
            using (var db = new sistema_control_comercio())
            {
                var inventary = db.inventary.Where(x => x.physical_location_id == location).ToList();
                List<inventoryBody> list = new List<inventoryBody>();
                foreach (var item in inventary)
                {
                    list.Add(new inventoryBody
                    {
                        Id = item.inventary_id,
                        physical_location_id = (Guid)item.physical_location_id,
                        quantity = (int)item.quantity,
                        rawMaterial = rawMaterialManager.Current.GetOne((Guid)item.raw_material_id)
                    });
                }
                return list;
            }
        }

        public inventoryBody GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.inventary.ToList().Where(x => x.inventary_id == id).FirstOrDefault();
                if (obj == null) throw new NotFoundException();
                else
                {
                    inventoryBody inventoryBody = new inventoryBody();
                    inventoryBody.Id = obj.inventary_id;
                    inventoryBody.physical_location_id = (Guid)obj.physical_location_id;
                    inventoryBody.quantity = (int)obj.quantity;
                    inventoryBody.rawMaterial = rawMaterialManager.Current.GetOne((Guid)obj.raw_material_id);
                    return inventoryBody;
                }
            }
        }
        public inventoryBody GetOneLocationMaterial(Guid location, Guid material)
        {
            using (var db = new sistema_control_comercio())
            {
                inventoryBody inventoryBody = new inventoryBody();
                var obj = db.inventary.ToList().Where(x => x.raw_material_id == material && x.physical_location_id == location).FirstOrDefault();
                if (obj == null) return inventoryBody;
                else
                {
                    inventoryBody.Id = obj.inventary_id;
                    inventoryBody.physical_location_id = (Guid)obj.physical_location_id;
                    inventoryBody.quantity = (int)obj.quantity;
                    inventoryBody.rawMaterial = rawMaterialManager.Current.GetOne((Guid)obj.raw_material_id);
                    return inventoryBody;
                }
            }
        }

        public void Remove(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                inventary inventary = new inventary();
                var obj = GetOne(id);
                inventary.inventary_id = id;
                inventary.physical_location_id = (Guid)obj.physical_location_id;
                inventary.raw_material_id = obj.rawMaterial.raw_material_id;
                inventary.quantity = (int)obj.quantity;
                db.inventary.Attach(inventary);
                db.inventary.Remove(inventary);
                db.SaveChanges();
            }
        }

        public void Update(inventoryBody obj)
        {
            using (var db = new sistema_control_comercio())
            {
                inventary inventary = new inventary();
                inventary.quantity = obj.quantity;
                inventary.physical_location_id = obj.physical_location_id;
                inventary.inventary_id = obj.Id;
                inventary.raw_material_id = obj.rawMaterial.raw_material_id;
                inventary.modification_date = DateTime.Now;

                var obj_db = db.inventary.SingleOrDefault(b => b.inventary_id == obj.Id);
                if (obj_db == null) throw new NotFoundException();
                else
                {
                    inventary.creation_date = obj_db.creation_date;
                    db.Entry(obj_db).CurrentValues.SetValues(inventary);
                    db.SaveChanges();
                }
            }
        }
    }
}