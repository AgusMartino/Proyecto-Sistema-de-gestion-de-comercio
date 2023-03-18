using Api_control_comercio.Entities.ABMs.Product;
using Api_control_comercio.Entities.ABMs.Product_rawMaterial;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using Api_control_comercio.Utils.Manager.ABMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_control_comercio.Controllers.ABMs
{
    public class productController : ApiController
    {
        #region Singleton
        private readonly static productController _instance;
        public static productController Current { get { return _instance; } }
        static productController() { _instance = new productController(); }
        private productController()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetAll(Guid physical_location_id)
        {
            try
            {
                return Ok(productManager.Current.GetAllProductPhysicalLocation(physical_location_id));
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
        public IHttpActionResult GetOneId([FromUri] Guid id)
        {
            try
            {
                productBodyGetOne productBodyGetOne = new productBodyGetOne();
                product product = productManager.Current.GetOne(id);
                productBodyGetOne.raw_materials = (List<product_rawMaterialBody>)productRawMaterialController.Current.GetComponentes(product);
                productBodyGetOne.product_id = product.product_id;
                productBodyGetOne.product_name = product.product_name;
                productBodyGetOne.product_code = product.product_code;
                productBodyGetOne.product_price = (int)product.product_price;
                productBodyGetOne.product_cost = (int)product.product_cost;
                productBodyGetOne.physical_location_id = (Guid)product.physical_location_id;
                productBodyGetOne.category_id = (Guid)product.category_id;
                return Ok(productBodyGetOne);
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

        public IHttpActionResult GetOneCode([FromUri] string code)
        {
            try
            {
                productBodyGetOne productBodyGetOne = new productBodyGetOne();
                product product = productManager.Current.GetOneCode(code);
                productBodyGetOne.raw_materials = (List<product_rawMaterialBody>)productRawMaterialController.Current.GetComponentes(product);
                productBodyGetOne.product_id = product.product_id;
                productBodyGetOne.product_name = product.product_name;
                productBodyGetOne.product_code = product.product_code;
                productBodyGetOne.product_price = (int)product.product_price;
                productBodyGetOne.product_cost = (int)product.product_cost;
                productBodyGetOne.physical_location_id = (Guid)product.physical_location_id;
                productBodyGetOne.category_id = (Guid)product.category_id;
                return Ok(productBodyGetOne);
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
        public IHttpActionResult Add([FromBody] productBodyAdd productBody)
        {
            try
            {
                if (!productManager.Current.ValidationCode(productBody.product_code, productBody.physical_location_id))
                {
                    productBody.product_id = Guid.NewGuid();
                    product product = new product();
                    product.product_id = productBody.product_id;
                    product.product_name = productBody.product_name;
                    product.product_code = productBody.product_code;
                    product.product_price = productBody.product_price;
                    product.product_cost = productBody.product_cost;
                    product.physical_location_id = productBody.physical_location_id;
                    product.category_id = productBody.category_id;
                    foreach (var raw_material in productBody.raw_materials)
                    {
                        raw_material raw_Material = new raw_material();
                        raw_Material.raw_material_id = raw_material.raw_material_id;
                        productRawMaterialController.Current.Join(raw_Material, product, raw_material.quantity);
                    }
                    productManager.Current.Add(product);
                    return Ok();
                }
                else
                {
                    throw new AlreadyExistsProductException();
                }
                
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
        public IHttpActionResult Update([FromBody] productBodyAdd productBody)
        {
            try
            {
                if (!productManager.Current.ValidationCode(productBody.product_code, productBody.physical_location_id))
                {
                    product product = new product
                    {
                        product_id = productBody.product_id,
                        product_name = productBody.product_name,
                        product_code = productBody.product_code,
                        product_price = productBody.product_price,
                        product_cost = productBody.product_cost,
                        physical_location_id = productBody.physical_location_id,
                        category_id = productBody.category_id,
                        modification_date = DateTime.Now,
                    };
                    productRawMaterialController.Current.DeleteJoin(product);
                    foreach (var item in productBody.raw_materials)
                    {
                        raw_material raw_Material = new raw_material();
                        raw_Material.raw_material_id = item.raw_material.raw_material_id;
                        productRawMaterialController.Current.Join(raw_Material, product, item.quantity);
                    }
                    productManager.Current.Update(product);
                    return Ok();
                }
                else
                {
                    throw new AlreadyExistsProductException();
                }
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

        [HttpDelete]
        public IHttpActionResult Remove([FromUri] Guid id)
        {
            try
            {
                //Cambio de estado enable a false
                productManager.Current.Remove(id);
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