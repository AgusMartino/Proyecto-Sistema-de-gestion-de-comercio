using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.Gestor_de_ventas
{
    public sealed class SaleOrderManager : IGenericCRUD<sale_order>
    {
        #region singleton
        private readonly static SaleOrderManager _instance = new SaleOrderManager();
        public static SaleOrderManager Current
        {
            get
            {
                return _instance;
            }
        }
        private SaleOrderManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void Add(sale_order obj)
        {
            using (var db = new sistema_control_comercio())
            {
                db.sale_order.Add(obj);
                db.SaveChanges();
            }
        }

        public List<sale_order> GetAll()
        {
            throw new NotImplementedException();
        }

        public sale_order GetOne(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                var obj = db.sale_order.ToList().Where(x => x.sale_order_id == id).FirstOrDefault();

                if (obj == null) throw new NotFoundException();
                else return obj;
            }
        }

        public List<sale_order> GetOneSale(Guid id)
        {
            using (var db = new sistema_control_comercio())
            {
                List<sale_order> sale_Orders = db.sale_order.ToList().Where(x => x.sale_id == id).ToList();

                if (sale_Orders == null) throw new NotFoundException();
                else return sale_Orders;
            }
        }

        public void Remove(Guid id)
        {
            var obj = GetOne(id);
            using (var db = new sistema_control_comercio())
            {
                db.sale_order.Attach(obj);
                db.sale_order.Remove(obj);
                db.SaveChanges();
            }
        }

        public void Update(sale_order obj)
        {
            throw new NotImplementedException();
        }
    }
}