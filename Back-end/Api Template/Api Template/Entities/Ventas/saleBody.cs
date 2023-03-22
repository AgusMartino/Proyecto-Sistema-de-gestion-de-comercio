using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.ABMs.Ventas
{
    public class saleBody
    {
        public Guid Id { get; set; }
        public Guid location { get; set; }
        public Guid payment_method { get; set; }
        public Guid employee_id { get; set; }
        public int price { get; set; }
        public List<sale_order> sale_Orders { get; set; }
    }
}