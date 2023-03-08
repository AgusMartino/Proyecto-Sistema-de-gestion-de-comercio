using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Template.Entities.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException():base("Un usuario con ese nombre ya existe en la base de datos")
        {
        }
    }
}