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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public raw_material()
        {
            this.inventary = new HashSet<inventary>();
            this.payment_suppliers_order = new HashSet<payment_suppliers_order>();
            this.product_rawmaterial = new HashSet<product_rawmaterial>();
        }
    
        public int raw_material_id { get; set; }
        public string raw_material_code { get; set; }
        public string raw_material_name { get; set; }
        public Nullable<int> raw_material_cost { get; set; }
        public Nullable<int> company_id { get; set; }
        public Nullable<int> unit_of_measurement_id { get; set; }
        public Nullable<System.DateTime> creation_date { get; set; }
        public Nullable<System.DateTime> modification_date { get; set; }
    
        public virtual company company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inventary> inventary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<payment_suppliers_order> payment_suppliers_order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product_rawmaterial> product_rawmaterial { get; set; }
        public virtual unit_of_measurement unit_of_measurement { get; set; }
    }
}
