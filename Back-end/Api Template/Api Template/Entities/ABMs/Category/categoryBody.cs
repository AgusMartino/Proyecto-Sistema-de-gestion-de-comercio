﻿using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.ABMs.Category
{
    public class categoryBody
    {
        public category category { get; set; }
        public Guid user_id { get; set; }
    }
}