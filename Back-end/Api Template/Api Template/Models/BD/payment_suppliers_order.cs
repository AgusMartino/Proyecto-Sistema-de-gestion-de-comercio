//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api_control_comercio.Models.BD
{
    using System;
    using System.Collections.Generic;
    
    public partial class payment_suppliers_order
    {
        public int payment_suppliers_order_id { get; set; }
        public Nullable<int> payment_suppliers_id { get; set; }
        public Nullable<int> raw_material_id { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<int> payment_suppliers_cost { get; set; }
        public Nullable<System.DateTime> creation_date { get; set; }
        public Nullable<System.DateTime> modification_date { get; set; }
    
        public virtual payment_suppliers payment_suppliers { get; set; }
        public virtual raw_material raw_material { get; set; }
    }
}
