using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api_control_comercio.Utils;

namespace Api_control_comercio.Models.BD
{
    public partial class company
    {
        public company()
        {
            if (company_id == Guid.Empty) company_id = Guid.NewGuid();
        }
    }
    public partial class category
    {
        public category()
        {
            if (category_id == Guid.Empty) category_id = Guid.NewGuid();
        }
    }
    public partial class unit_of_measurement
    {
        public unit_of_measurement()
        {
            if (unit_of_measurement_id == Guid.Empty) unit_of_measurement_id = Guid.NewGuid();
        }
    }
    public partial class payment_method
    {
        public payment_method()
        {
            if (payment_method_id == Guid.Empty) payment_method_id = Guid.NewGuid();
        }
    }
    public partial class employee
    {
        public employee()
        {
            if (employee_id == Guid.Empty) employee_id = Guid.NewGuid();
        }
    }
    public partial class user
    {
        public user()
        {
            if (user_id == Guid.Empty) user_id = Guid.NewGuid();
        }
    }
    public partial class user_profile
    {
        public user_profile()
        {
            if (user_profile_id == Guid.Empty) user_profile_id = Guid.NewGuid();
        }
    }
    public partial class user_permission
    {
        public user_permission()
        {
            if (user_permission_id == Guid.Empty) user_permission_id = Guid.NewGuid();
        }
    }
    public partial class physical_location
    {
        public physical_location()
        {
            if (physical_location_id == Guid.Empty) physical_location_id = Guid.NewGuid();
        }
    }
    public partial class product
    {
        public product()
        {
            if (product_id == Guid.Empty) product_id = Guid.NewGuid();
        }
    }
    public partial class raw_material
    {
        public raw_material()
        {
            if (raw_material_id == Guid.Empty) raw_material_id = Guid.NewGuid();
        }
    }
    public partial class product_rawmaterial
    {
        public product_rawmaterial()
        {
            if (product_rawmaterial_id == Guid.Empty) product_rawmaterial_id = Guid.NewGuid();
        }
    }
    public partial class sale
    {
        public sale()
        {
            if (sale_id == Guid.Empty) sale_id = Guid.NewGuid();
        }
    }
    public partial class sale_order
    {
        public sale_order()
        {
            if (sale_order_id == Guid.Empty) sale_order_id = Guid.NewGuid();
        }
    }
    public partial class payment_service
    {
        public payment_service()
        {
            if (payment_service_id == Guid.Empty) payment_service_id = Guid.NewGuid();
        }
    }
    public partial class payment_suppliers
    {
        public payment_suppliers()
        {
            if (payment_suppliers_id == Guid.Empty) payment_suppliers_id = Guid.NewGuid();
        }
    }
    public partial class payment_suppliers_order
    {
        public payment_suppliers_order()
        {
            if (payment_suppliers_order_id == Guid.Empty) payment_suppliers_order_id = Guid.NewGuid();
        }
    }
    public partial class inventary
    {
        public inventary()
        {
            if (inventary_id == Guid.Empty) inventary_id = Guid.NewGuid();
        }
    }
    public partial class profile
    {
        public profile()
        {
            if (profile_id == Guid.Empty) profile_id = Guid.NewGuid();
        }
    }
    public partial class profile_profile
    {
        public profile_profile()
        {
            if (profile_profile_id == Guid.Empty) profile_profile_id = Guid.NewGuid();
        }
    }
    public partial class profile_permission
    {
        public profile_permission()
        {
            if (profile_permission_id == Guid.Empty) profile_permission_id = Guid.NewGuid();
        }
    }
    public partial class permission
    {
        public permission()
        {
            if (permission_id == Guid.Empty) permission_id = Guid.NewGuid();
        }
    }
    public partial class service
    {
        public service()
        {
            if (service_id == Guid.Empty) service_id = Guid.NewGuid();
        }
    }
    public partial class supplier
    {
        public supplier()
        {
            if (supplier_id == Guid.Empty) supplier_id = Guid.NewGuid();
        }
    }

}