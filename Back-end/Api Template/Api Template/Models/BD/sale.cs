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
    
    public partial class sale
    {
        public System.Guid sale_id { get; set; }
        public Nullable<System.Guid> physical_location_id { get; set; }
        public Nullable<System.Guid> employee_id { get; set; }
        public Nullable<int> sale_price { get; set; }
        public Nullable<System.Guid> payment_method_id { get; set; }
        public Nullable<System.DateTime> creation_date { get; set; }
        public Nullable<System.DateTime> modification_date { get; set; }
    }
}
