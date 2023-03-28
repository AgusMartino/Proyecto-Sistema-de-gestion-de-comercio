using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.ABMs.rawMaterial
{
    public class rawMaterialBody
    {
        public raw_material raw_Material { get; set; }
        public Guid user_id { get; set; }
        public Guid location { get; set; }
    }
}