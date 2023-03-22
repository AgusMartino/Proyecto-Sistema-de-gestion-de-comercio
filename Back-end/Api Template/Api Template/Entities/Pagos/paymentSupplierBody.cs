using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.ABMs.Pagos
{
    public class paymentSupplierBody
    {
        public Guid Id { get; set; }
        public Guid supplier_Id { get; set; }
        public Guid location { get; set; }
        public int cost { get; set; }
        public int pay { get; set; }
        public List<payment_suppliers_order> payment_Suppliers_Orders { get; set; }
    }
}