using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api_control_comercio.Models.BD;

namespace Api_control_comercio.Entities.ABMs.Physical_location
{
    public class physicalLocationBody
    {
        public physical_location physical_Location { get; set; }
        public Guid user_id { get; set; }
    }
}