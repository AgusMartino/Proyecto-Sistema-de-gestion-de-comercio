using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api_control_comercio.Contracts
{
    public interface IGenericRelatrionship<T, U> where T : new() where U : new()
    {
        void Join(T obj1, U obj2);
        List<U> GetFamilia(T obj);
        List<T> GetComponentes(U obj);
        void DeleteJoin(U obj);
    }
}