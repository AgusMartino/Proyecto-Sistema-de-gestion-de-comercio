using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Logger
{
    public sealed class LoggerManagerBD : IGenericCRUD<logs>
    {
        #region singleton
        private readonly static LoggerManagerBD _instance = new LoggerManagerBD();

        public static LoggerManagerBD Current
        {
            get
            {
                return _instance;
            }
        }

        private LoggerManagerBD()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(logs obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.logs.Add(obj);
            }
        }

        public List<logs> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.logs.ToList();
            }
        }

        public List<logs> GetAllLocation(Guid location)
        {
            using (var db = new sistema_control_comercio())
            {
                return db.logs.Where(x => x.physical_location_id == location).ToList();
            }
        }

        public List<logs> GetAllUser(Guid user)
        {
            using (var db = new sistema_control_comercio())
            {
                return db.logs.Where(x => x.user_id == user).ToList();
            }
        }

        public logs GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.logs.ToList().Where(x => x.log_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(logs obj)
        {
            throw new NotImplementedException();
        }
    }
}