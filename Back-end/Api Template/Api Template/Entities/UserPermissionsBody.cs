using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api_Template.Models.Template;

namespace Api_Template.Entities
{
    public class UserPermissionsBody
    {
        public string Username { get; set; }
        public List<Guid> Permissions { get; set; }
    }
}