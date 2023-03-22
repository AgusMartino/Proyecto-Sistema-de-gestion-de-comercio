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
        public IHttpActionResult GetAll([FromUri]Guid physical_location_id)
        {
            try
            {
                //Obtiene todos los productos generados por el location que se pasa en parametro
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
        public IHttpActionResult GetAllCategory([FromBody] productBodyGetAllCategory productBodyGetAllCategory)
        {
            try
            {
                //Obtiene todos los productos generados por el location que se pasa en parametro
                return Ok(productManager.Current.GetAllProductPhysicalLocationCategory(productBodyGetAllCategory.physical_location_id, productBodyGetAllCategory.category_id));
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
                //Obtiene un producto en especifico por su ID
                productBodyGetOne productBodyGetOne = new productBodyGetOne();
                product product = productManager.Current.GetOne(id);
                //Se obtiene los componentes del producto
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

        [HttpGet]
        public IHttpActionResult GetOneCode([FromUri] string code)
        {
            try
            {
                //Obtiene un producto en especifico por su codigo
                productBodyGetOne productBodyGetOne = new productBodyGetOne();
                product product = productManager.Current.GetOneCode(code);
                //Se obtiene los componentes del producto
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
                //Se valida que el codigo del producto nuevo sea inexistente
                if (!productManager.Current.ValidationCode(productBody.product_code, productBody.physical_location_id))
                {
                    //Se realiza un mapeo de los datos trasmitidos
                    productBody.product_id = Guid.NewGuid();
                    product product = new product();
                    product.product_id = productBody.product_id;
                    product.product_name = productBody.product_name;
                    product.product_code = productBody.product_code;
                    product.product_price = productBody.product_price;
                    product.product_cost = productBody.product_cost;
                    product.physical_location_id = productBody.physical_location_id;
                    product.category_id = productBody.category_id;
                    //Se realiza el ingreso de los componentes del producto en la BD
                    foreach (var raw_material in productBody.raw_materials)
                    {
                        productRawMaterialController.Current.Join(raw_material, product);
                    }
                    //Se registra el producto en la BD
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
                //Se mapea el producto
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
                //Se eliminan los componentes del producto
                productRawMaterialController.Current.DeleteJoin(product);
                //Se registran los nuevos componentes del producto
                foreach (var item in productBody.raw_materials)
                {
                    productRawMaterialController.Current.Join(item, product);
                }
                //Se actualiza el producto
                productManager.Current.Update(product);
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