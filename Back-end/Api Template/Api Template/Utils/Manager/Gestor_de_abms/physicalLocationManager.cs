using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Gestor_de_abms
{
    public sealed class physicalLocationManager : IGenericCRUD<physical_location>
    {
        #region singleton
        private readonly static physicalLocationManager _instance = new physicalLocationManager();
        public static physicalLocationManager Current
        {
            get
            {
                return _instance;
            }
        }
        private physicalLocationManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(physical_location obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.physical_location.Add(obj);
                db.SaveChanges();
            }
        }

        public List<physical_location> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.physical_location.Where(x => x.enable == true).ToList();
            }
        }

        public List<physical_location> GetAllLocationCentral(Guid location)
        {
            using (var db = new sistema_control_comercio())
            {
                return db.physical_location.Where(x => x.physical_location_id_central == location && x.enable == true).ToList();
            }
        }

        public List<physical_location> GetAllLocation()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.physical_location.Where(x => x.physical_location_id_central == null && x.enable == true).ToList();
            }
        }

        public physical_location GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.physical_location.ToList().Where(x => x.physical_location_id == id && x.enable == true).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            obj.enable = false;
            obj.modification_date = DateTime.Now;
            Update(obj);
        }

        public void Update(physical_location obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.physical_location.SingleOrDefault(b => b.physical_location_id == obj.physical_location_id);
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