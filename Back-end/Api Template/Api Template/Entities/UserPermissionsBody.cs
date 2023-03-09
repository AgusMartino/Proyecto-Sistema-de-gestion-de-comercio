using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api_control_comercio.Models.Template;

namespace Api_control_comercio.Entities
{
    public class UserPermissionsBody
    {
        public string Username { get; set; }
        public List<Guid> Permissions { get; set; }
    }
}