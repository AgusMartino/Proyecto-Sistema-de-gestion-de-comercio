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
    
    public partial class sale_order
    {
        public System.Guid sale_order_id { get; set; }
        public Nullable<System.Guid> sale_id { get; set; }
        public Nullable<System.Guid> product_id { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<int> sale_order_price { get; set; }
        public Nullable<System.DateTime> creation_date { get; set; }
        public Nullable<System.DateTime> modification_date { get; set; }
    
        public virtual product product { get; set; }
        public virtual sale sale { get; set; }
    }
}