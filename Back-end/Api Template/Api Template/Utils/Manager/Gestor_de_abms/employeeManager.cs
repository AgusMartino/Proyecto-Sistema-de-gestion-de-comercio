﻿using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Gestor_de_abms
{
    public sealed class employeeManager : IGenericCRUD<employee>
    {
        #region singleton
        private readonly static employeeManager _instance = new employeeManager();
        public static employeeManager Current
        {
            get
            {
                return _instance;
            }
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  

        private employeeManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(employee obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.employee.Add(obj);
                db.SaveChanges();
            }
        }

        public List<employee> GetAll()
        {
            using (var db = new sistema_control_comercio())
            {
                return db.employee.Where(x => x.enable == true).ToList();
            }
        }

        public List<employee> GetAllLocation(Guid location)
        {
            using (var db = new sistema_control_comercio())
            {
                return db.employee.Where(x => x.physical_location_id == location && x.enable == true).ToList();
            }
        }

        public employee GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.employee.ToList().Where(x => x.employee_id == id && x.enable == true).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public void Remove(Guid id)
        {
            employeeBody obj = GetOne(id);
            obj.enable = false;
            obj.modification_date = DateTime.Now;
            Update(obj);
        }

        public void Update(employee obj)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj_db = db.employee.SingleOrDefault(b => b.employee_id == obj.employee_id);
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