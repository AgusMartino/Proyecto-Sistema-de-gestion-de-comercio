using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.ABMs.Pagos
{
    public class paymentEmployeeBody
    {
        public Guid Location { get; set; }
        
        public payment_employee payment { get; set; }

    }
}