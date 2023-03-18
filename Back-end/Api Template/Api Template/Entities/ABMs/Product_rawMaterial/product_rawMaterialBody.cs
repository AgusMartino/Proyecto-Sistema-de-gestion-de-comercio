using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.ABMs.Product_rawMaterial
{
    public class product_rawMaterialBody
    {
        public raw_material raw_material { get; set; }
        public int quantity { get; set; }
    }
}