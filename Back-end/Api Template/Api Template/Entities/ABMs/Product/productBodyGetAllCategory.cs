using Api_control_comercio.Entities.ABMs.Product_rawMaterial;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.ABMs.Product
{
    public class productBodyGetAllCategory
    {
        public Guid category_id { get; set; }
        public Guid physical_location_id { get; set; }

    }
}