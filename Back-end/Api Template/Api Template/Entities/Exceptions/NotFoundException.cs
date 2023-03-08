using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Template.Entities.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException():base("No se pudo encontrar el recurso solicitado")
        {
        }
    }
}