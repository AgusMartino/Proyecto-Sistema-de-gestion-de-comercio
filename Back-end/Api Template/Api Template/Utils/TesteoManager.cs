﻿using System.Collections.Generic;
using Api_control_comercio.Entities;
using Api_control_comercio.Contracts;
using System;
using System.Linq;
using Api_control_comercio.Models.Template;

namespace Api_control_comercio.Utils
{ }
/*
    public class TesteoManager
    {
        #region Singleton
        private readonly static TesteoManager _instance;
        public static TesteoManager Current { get { return _instance; } }
        static TesteoManager() { _instance = new TesteoManager(); }
        private TesteoManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public List<Usuario> GetFromDB()
        {
            using (var db = new TemplateEntities())
            {
                var regs = (from v in db.Permiso.ToList()
                            where v.Estado == true && v.Permiso1 != null
                            select v
                            ).ToList();

                regs[2].Permiso1 = null;

                db.SaveChanges();

                return null;
            }
        }
    }
}
*/