using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.ABMs.inventory
{
    public class inventoryBody
    {
        public Guid physical_location_id { get; set; }
        public Guid raw_material_id { get; set; }
        public int quantity { get; set; }

    }
}