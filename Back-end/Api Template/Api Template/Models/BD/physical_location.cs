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
    
    public partial class physical_location
    {
        public System.Guid physical_location_id { get; set; }
        public Nullable<int> physical_location_cuit { get; set; }
        public string physical_location_name { get; set; }
        public Nullable<int> physical_location_cellphone { get; set; }
        public string physical_location_address { get; set; }
        public Nullable<System.Guid> company_id { get; set; }
        public Nullable<System.DateTime> creation_date { get; set; }
        public Nullable<System.DateTime> modification_date { get; set; }
    }
}
