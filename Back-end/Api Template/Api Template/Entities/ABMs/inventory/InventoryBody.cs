using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.ABMs.inventory
{
    public class inventoryBody
    {
        public inventary inventary { get; set; }
        public raw_material rawMaterial { get; set; }
        public Guid user_id { get; set; }

    }
}