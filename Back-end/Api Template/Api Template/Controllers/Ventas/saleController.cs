using Api_control_comercio.Controllers.ABMs;
using Api_control_comercio.Entities.ABMs.inventory;
using Api_control_comercio.Entities.ABMs.Product;
using Api_control_comercio.Entities.ABMs.Ventas;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using Api_control_comercio.Utils.Manager.ABMs;
using Api_control_comercio.Utils.Manager.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_control_comercio.Controllers.Ventas
{
    public class saleController : ApiController
    {
        #region Singleton
        private readonly static saleController _instance;
        public static saleController Current { get { return _instance; } }
        static saleController() { _instance = new saleController(); }
        private saleController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(SaleManager.Current.GetAll());
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
        public IHttpActionResult GetAllLocation([FromUri]Guid location)
        {
            try
            {
                return Ok(SaleManager.Current.GetAllLocation(location));
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
        public IHttpActionResult GetAllLocationEmployee([FromUri] Guid location, Guid employee)
        {
            try
            {
                return Ok(SaleManager.Current.GetAllLocationEmployee(location, employee));
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
                sale saletmp = SaleManager.Current.GetOne(id);
                List<sale_order> sale_Orders = SaleOrderManager.Current.GetOneSale(id);
                return Ok(new saleBody
                {
                    Id = id,
                    employee_id = (Guid)saletmp.employee_id,
                    sale_Orders = sale_Orders,
                    location = (Guid)saletmp.physical_location_id,
                    price = (int)saletmp.sale_price,
                    payment_method = (Guid)saletmp.payment_method_id
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
        public IHttpActionResult Add([FromBody] saleBody sale)
        {
            try
            {
                sale.Id = Guid.NewGuid();
                SaleManager.Current.Add(new sale
                {
                    sale_id = sale.Id,
                    sale_price = sale.price,
                    employee_id = sale.employee_id,
                    payment_method_id = sale.payment_method,
                    physical_location_id = sale.location,
                    creation_date = DateTime.Now,
                    modification_date = DateTime.Now
                });
                foreach (var item in sale.sale_Orders)
                {
                    saleOrderController.Current.Add(new sale_order
                    {
                        sale_id = sale.Id,
                        sale_order_id = Guid.NewGuid(),
                        sale_order_price = item.sale_order_price,
                        quantity = item.quantity,
                        product_id = item.product_id,
                        creation_date= DateTime.Now,
                        modification_date = DateTime.Now
                    });
                    productBodyGetOne productBodyGetOne = new productBodyGetOne();
                    productBodyGetOne = (productBodyGetOne)productController.Current.GetOneId((Guid)item.product_id);
                    foreach (var raw_material in productBodyGetOne.raw_materials)
                    {
                        inventoryBody inventoryBody = new inventoryBody();
                        inventoryBody = (inventoryBody)inventaryController.Current.GetOneLocationMaterial(sale.location, (Guid)raw_material.raw_material.raw_material_id);
                        inventoryBody.quantity = (int)(raw_material.quantity * item.quantity);
                        inventaryController.Current.RemoveInventary(inventoryBody);
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
        public IHttpActionResult Update([FromBody] sale sale)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] Guid id)
        {
            try
            {
                saleBody sale = (saleBody)GetOne(id);
                List<sale_order> sale_Orders = new List<sale_order>();
                sale_Orders = (List<sale_order>)saleOrderController.Current.GetOne(id);
                foreach (var item in sale_Orders)
                {
                    productBodyGetOne productBodyGetOne = new productBodyGetOne();
                    productBodyGetOne = (productBodyGetOne)productController.Current.GetOneId((Guid)item.product_id);
                    foreach (var raw_material in productBodyGetOne.raw_materials)
                    {
                        inventoryBody inventoryBody = new inventoryBody();
                        inventoryBody = (inventoryBody)inventaryController.Current.GetOneLocationMaterial(sale.location, (Guid)raw_material.raw_material.raw_material_id);
                        inventoryBody.quantity = (int)(raw_material.quantity * item.quantity);
                        inventaryController.Current.AddInventary(inventoryBody);
                    }
                    saleOrderController.Current.Remove(item.sale_order_id);
                }
                SaleManager.Current.Remove(id);
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