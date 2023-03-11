using Api_control_comercio.Contracts;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public class employeeManager : IGenericCRUD<employee>
    {
        public void Add(employee obj)
        {
            throw new NotImplementedException();
        }

        public List<employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public employee GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(employee obj)
        {
            throw new NotImplementedException();
        }
    }
}