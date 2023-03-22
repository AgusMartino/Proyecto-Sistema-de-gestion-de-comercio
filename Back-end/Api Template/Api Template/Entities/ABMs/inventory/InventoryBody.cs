using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.ABMs.inventory
{
    public class inventoryBody
    {
        public Guid Id { get; set; }
        public raw_material rawMaterial { get; set; }
        public Guid physical_location_id { get; set; }
        public int quantity { get; set; }

    }
}