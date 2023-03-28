using Api_control_comercio.Controllers.Logger;
using Api_control_comercio.Entities.ABMs.Product;
using Api_control_comercio.Entities.ABMs.Product_rawMaterial;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using Api_control_comercio.Utils.Manager.Gestor_de_productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_control_comercio.Controllers.Gestor_de_productos
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
        public IHttpActionResult GetAll([FromBody] Guid physical_location_id, Guid user)
        {
            try
            {
                //Obtiene todos los productos generados por el location que se pasa en parametro
                List<product> products = productManager.Current.GetAllProductPhysicalLocation(physical_location_id);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_location_id,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la lista de productos del location con id: {physical_location_id}"
                });
                return Ok(products);
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = physical_location_id,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = physical_location_id,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllCategory([FromBody] Guid location, Guid user, Guid category)
        {
            try
            {
                //Obtiene todos los productos generados por el location que se pasa en parametro
                List<product> products = productManager.Current.GetAllProductPhysicalLocationCategory(location, category);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la lista de productos del location con id: {location} filtrado por la categoria con id: {category}"
                });
                return Ok(products);
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetOneId([FromBody] Guid produc_id, Guid location, Guid user)
        {
            try
            {
                //Obtiene un producto en especifico por su ID
                productBody productBodyGetOne = new productBody();
                productBodyGetOne.product = productManager.Current.GetOne(produc_id);
                //Se obtiene los componentes del producto
                productBodyGetOne.product_RawMaterials = (List<product_rawMaterialBody>)productRawMaterialController.Current.GetComponentes(productBodyGetOne.product);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la informacion del producto con id: {produc_id}"
                });
                return Ok(productBodyGetOne);
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetOneCode([FromBody] string code, Guid location, Guid user)
        {
            try
            {
                //Obtiene un producto en especifico por su ID
                productBody productBodyGetOne = new productBody();
                productBodyGetOne.product = productManager.Current.GetOneCode(code);
                //Se obtiene los componentes del producto
                productBodyGetOne.product_RawMaterials = (List<product_rawMaterialBody>)productRawMaterialController.Current.GetComponentes(productBodyGetOne.product);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = $"Se obtuvo la informacion del producto con codigo: {code}"
                });
                return Ok(productBodyGetOne);
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = location,
                    user_id = user,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] productBody productBody)
        {
            try
            {
                //Se valida que el codigo del producto nuevo sea inexistente
                if (!productManager.Current.ValidationCode(productBody.product.product_code, (Guid)productBody.product.physical_location_id))
                {
                    //Se realiza un mapeo de los datos trasmitidos
                    productBody.product.product_id = Guid.NewGuid();
                    //Se realiza el ingreso de los componentes del producto en la BD
                    foreach (var raw_material in productBody.product_RawMaterials)
                    {
                        productRawMaterialController.Current.Join(raw_material, productBody.product);
                    }
                    //Se registra el producto en la BD
                    productManager.Current.Add(productBody.product);
                    LoggerController.Current.Add(new logs
                    {
                        log_id = Guid.NewGuid(),
                        log_type = "Informational",
                        physical_location_id = productBody.product.physical_location_id,
                        user_id = productBody.user_id,
                        creation_date = DateTime.Now,
                        log_detail = $"Se realizo el alta del producto con id: {productBody.product.product_id}"
                    });
                    return Ok();
                }
                else
                {
                    throw new AlreadyExistsProductException();
                }
                
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = productBody.product.physical_location_id,
                    user_id = productBody.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = productBody.product.physical_location_id,
                    user_id = productBody.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] productBody productBody)
        {
            try
            {
                //Se eliminan los componentes del producto
                productRawMaterialController.Current.DeleteJoin(productBody.product);
                //Se registran los nuevos componentes del producto
                foreach (var item in productBody.product_RawMaterials)
                {
                    productRawMaterialController.Current.Join(item, productBody.product);
                }
                //Se actualiza el producto
                productManager.Current.Update(productBody.product);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = productBody.product.physical_location_id,
                    user_id = productBody.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se realizo la actualizacion de la informacion del producto con id: {productBody.product.product_id}"
                });
                return Ok();
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = productBody.product.physical_location_id,
                    user_id = productBody.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = productBody.product.physical_location_id,
                    user_id = productBody.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] productBody productBody)
        {
            try
            {
                //Cambio de estado enable a false
                productManager.Current.Remove(productBody.product.product_id);
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = productBody.product.physical_location_id,
                    user_id = productBody.user_id,
                    creation_date = DateTime.Now,
                    log_detail = $"Se realizo la actualizacion del estado enable a false del producto con id: {productBody.product.product_id}"
                });
                return Ok();
            }
            catch (NotFoundException)
            {
                var ex = NotFound();
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Informational",
                    physical_location_id = productBody.product.physical_location_id,
                    user_id = productBody.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return ex;
            }
            catch (Exception ex)
            {
                LoggerController.Current.Add(new logs
                {
                    log_id = Guid.NewGuid(),
                    log_type = "Error",
                    physical_location_id = productBody.product.physical_location_id,
                    user_id = productBody.user_id,
                    creation_date = DateTime.Now,
                    log_detail = ex.ToString()
                });
                return InternalServerError(ex);
            }
        }
    }
}