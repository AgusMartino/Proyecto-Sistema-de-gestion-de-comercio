﻿using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.ABMs.Service
{
    public class serviceBody
    {
        public service Service { get; set; }
        public Guid user_id { get; set; }
    }
}