using Api_control_comercio.Entities.ABMs.Product_rawMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.ABMs.Product
{
    public class productBodyAdd
    {
        public Guid product_id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public int product_cost { get; set; }
        public int product_price { get; set; }
        public Guid category_id { get; set; }
        public Guid physical_location_id { get; set; }
        public List<product_rawMaterialBody> raw_materials { get; set; }

    }
}