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
    
    public partial class raw_material
    {
        public System.Guid raw_material_id { get; set; }
        public string raw_material_code { get; set; }
        public string raw_material_name { get; set; }
        public Nullable<decimal> raw_material_cost { get; set; }
        public Nullable<bool> enable { get; set; }
        public Nullable<decimal> raw_material_unit { get; set; }
        public Nullable<decimal> raw_material_equivalence { get; set; }
        public Nullable<System.Guid> unit_of_measurement_id { get; set; }
        public Nullable<System.DateTime> creation_date { get; set; }
        public Nullable<System.DateTime> modification_date { get; set; }
    }
}
