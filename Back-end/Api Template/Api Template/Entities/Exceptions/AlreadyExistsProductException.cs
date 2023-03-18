using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.Exceptions
{
    public class AlreadyExistsProductException : Exception
    {
        public AlreadyExistsProductException():base("Un producto con ese codigo ya existe")
        {
        }
    }
}