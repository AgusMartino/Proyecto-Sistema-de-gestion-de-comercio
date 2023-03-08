using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api_Template.Contracts
{
    public interface IGenericCRUD<T> where T : new()
    {
        T GetOne(Guid id);

        List<T> GetAll();

        void Add(T obj);

        void Update(T obj);

        void Remove(Guid id);
    }
}