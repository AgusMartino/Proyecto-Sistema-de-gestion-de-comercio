using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Gestor_de_abms
{
    public sealed class unitOfMeasurementManager : IGenericCRUD<unit_of_measurement>
    {
        #region singleton
        private readonly static unitOfMeasurementManager _instance = new unitOfMeasurementManager();
        public static unitOfMeasurementManager Current
        {
            get
            {
                return _instance;
            }
        }

        private unitOfMeasurementManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(unit_of_measurement obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.unit_of_measurement.Add(obj);
                db.SaveChanges();
            }
        }

        public List<unit_of_measurement> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.unit_of_measurement.ToList();
            }
        }

        public unit_of_measurement GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.unit_of_measurement.ToList().Where(x => x.unit_of_measurement_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(unit_of_measurement obj)
        {
            throw new NotImplementedException();
        }
    }
}