using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Entities.Exceptions
{
    public class AlreadyExistsMaterialException : Exception
    {
        public AlreadyExistsMaterialException():base("Una materia prima con ese codigo ya existe")
        {
        }
    }
}