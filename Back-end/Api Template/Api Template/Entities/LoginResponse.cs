using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api_Template.Models.Template;

namespace Api_Template.Entities
{
    public class LoginResponse
    {
        public Usuario user { get; set; }
        public Token token { get; set; }
    }
}