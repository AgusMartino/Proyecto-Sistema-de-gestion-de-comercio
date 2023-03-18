using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.ABMs.rawMaterial
{
    public class rawMaterialBodyAdd
    {
        public Guid raw_material_id { get; set; }
        public string raw_material_code { get; set; }
        public string raw_material_name { get; set; }
        public int raw_material_cost { get; set; }
        public Guid unit_of_measurement_id { get; set; }
        public Guid physical_location_id { get; set; }

    }
}