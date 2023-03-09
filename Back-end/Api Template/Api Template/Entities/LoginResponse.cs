using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api_control_comercio.Models.Template;

namespace Api_control_comercio.Entities
{
    public class LoginResponse
    {
        public Usuario user { get; set; }
        public Token token { get; set; }
    }
}