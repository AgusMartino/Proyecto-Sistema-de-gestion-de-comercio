using Api_control_comercio.Controllers.Gestor_de_abms;
using Api_control_comercio.Entities.ABMs.inventory;
using Api_control_comercio.Entities.ABMs.Pagos;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using Api_control_comercio.Utils.Manager.Gestor_de_abms;
using Api_control_comercio.Utils.Manager.Gestor_de_pago_de_proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_control_comercio.Controllers.Gestor_de_pago_de_proveedores
{
    public class paymentSupplierController : ApiController
    {
        #region Singleton
        private readonly static paymentSupplierController _instance;
        public static paymentSupplierController Current { get { return _instance; } }
        static paymentSupplierController() { _instance = new paymentSupplierController(); }
        private paymentSupplierController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAllLocation([FromUri] Guid Location)
        {
            try
            {
                return Ok(paymentSupplierManager.Current.GetAllLocation(Location));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllSupplier([FromUri] Guid supplier)
        {
            try
            {
                return Ok(paymentSupplierManager.Current.GetAllsupplier(supplier));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetOne([FromBody] Guid id)
        {
            try
            {
                payment_suppliers payment_Suppliers = new payment_suppliers();
                payment_Suppliers = paymentSupplierManager.Current.GetOne(id);
                List<payment_suppliers_order> payment_Suppliers_OrdersGet = new List<payment_suppliers_order>();
                payment_Suppliers_OrdersGet = (List<payment_suppliers_order>)paymentSupplierOrderController.Current.GetAllPaymentSupplier(id);
                return Ok(new saleBody
                {
                    Id = id,
                    supplier_Id = (Guid)payment_Suppliers.supplier_id,
                    pay = (int)payment_Suppliers.payment_suppliers_pay,
                    cost = (int)payment_Suppliers.payment_suppliers_cost,
                    location = (Guid)payment_Suppliers.physical_location_id,
                    payment_Suppliers_Orders = payment_Suppliers_OrdersGet
                });
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] saleBody payment_SuppliersBody)
        {
            try
            {
                payment_SuppliersBody.Id = Guid.NewGuid();
                paymentSupplierManager.Current.Add(new payment_suppliers
                {
                    payment_suppliers_id = payment_SuppliersBody.Id,
                    payment_suppliers_cost = payment_SuppliersBody.cost,
                    payment_suppliers_pay = payment_SuppliersBody.pay,
                    physical_location_id = payment_SuppliersBody.location,
                    creation_date = DateTime.Now,
                    modification_date = DateTime.Now,
                    supplier_id = payment_SuppliersBody.supplier_Id
                });
                foreach (var item in payment_SuppliersBody.payment_Suppliers_Orders)
                {
                    paymentSupplierOrderController.Current.Add(new payment_suppliers_order
                    {
                        payment_suppliers_order_id = Guid.NewGuid(),
                        payment_suppliers_id = payment_SuppliersBody.Id,
                        raw_material_id = item.raw_material_id,
                        payment_suppliers_cost = item.payment_suppliers_cost,
                        quantity = item.quantity,
                        creation_date = DateTime.Now,
                        modification_date = DateTime.Now
                    });
                    inventoryBody inventary = new inventoryBody();
                    inventary = (inventoryBody)inventaryController.Current.GetOneLocationMaterial(payment_SuppliersBody.location, (Guid)item.raw_material_id);
                    if(inventary == null)
                    {
                        inventaryController.Current.Add(new inventoryBody
                        {
                            Id = Guid.NewGuid(),
                            physical_location_id = payment_SuppliersBody.location,
                            rawMaterial = rawMaterialController.Current.GetOneId(item.raw_material_id),
                            quantity = (int)item.quantity
                        });
                    }
                    else
                    {
                        inventary.quantity = (int)item.quantity;
                        inventaryController.Current.AddInventary(inventary);
                    }
                }
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] payment_suppliers payment_Suppliers)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] Guid id)
        {
            try
            {
                saleBody paymentSupplierBody = new saleBody();
                paymentSupplierBody = (saleBody)GetOne(id);
                foreach (var item in paymentSupplierBody.payment_Suppliers_Orders)
                {
                    paymentSupplierOrderController.Current.Remove(item.payment_suppliers_order_id);
                    inventoryBody inventary = new inventoryBody();
                    inventary = (inventoryBody)inventaryController.Current.GetOneLocationMaterial(paymentSupplierBody.location, (Guid)item.raw_material_id);
                    inventary.quantity = (int)item.quantity;
                    inventaryController.Current.RemoveInventary(inventary);
                }
                paymentSupplierManager.Current.Remove(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}