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
    
    public partial class product
    {
        public System.Guid product_id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public Nullable<int> product_cost { get; set; }
        public Nullable<int> product_price { get; set; }
        public Nullable<System.Guid> category_id { get; set; }
        public Nullable<System.Guid> physical_location_id { get; set; }
        public Nullable<System.DateTime> creation_date { get; set; }
        public Nullable<System.DateTime> modification_date { get; set; }
    }
}
