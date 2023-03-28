using Api_control_comercio.Entities.ABMs.Product_rawMaterial;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.ABMs.Product
{
    public class productBody
    {
        public product product { get; set; }

        public List<product_rawMaterialBody> product_RawMaterials { get; set; }

        public Guid user_id { get; set; }

    }
}