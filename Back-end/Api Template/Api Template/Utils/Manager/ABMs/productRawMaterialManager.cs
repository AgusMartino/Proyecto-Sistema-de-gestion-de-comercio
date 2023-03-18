using Api_control_comercio.Contracts;
using Api_control_comercio.Entities.ABMs.Product_rawMaterial;
using Api_control_comercio.Entities.Exceptions;
using Api_control_comercio.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_control_comercio.Utils.Manager.ABMs
{
    public sealed class productRawMaterialManager : IGenericRelatrionship<product_rawMaterialBody, product>
    {
        #region singleton
        private readonly static productRawMaterialManager _instance = new productRawMaterialManager();
        public static productRawMaterialManager Current
        {
            get
            {
                return _instance;
            }
        }
        private productRawMaterialManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion
        public void Join(product_rawMaterialBody product_rawMaterialBody, product product)
        {
            product_rawmaterial product_Rawmaterial = new product_rawmaterial();
            product_Rawmaterial.raw_material_id = product_rawMaterialBody.raw_material.raw_material_id;
            product_Rawmaterial.product_id = product.product_id;
            product_Rawmaterial.product_rawmaterial_id = Guid.NewGuid();
            product_Rawmaterial.creation_date = DateTime.Now;
            product_Rawmaterial.modification_date = DateTime.Now;
            product_Rawmaterial.quantity = product_rawMaterialBody.quantity;

            using (var db = new sistema_control_comercio())
            {
                db.product_rawmaterial.Add(product_Rawmaterial);
                db.SaveChanges();
            }
        }

        public List<product> GetFamilia(product_rawMaterialBody obj)
        {
            throw new NotImplementedException();
        }

        public List<product_rawMaterialBody> GetComponentes(product product)
        {
            List<product_rawMaterialBody> raw_Materials = new List<product_rawMaterialBody>();
            using(var db = new sistema_control_comercio())
            {
                List<product_rawmaterial> product_rawmaterial = db.product_rawmaterial.Where(x => x.product_id == product.product_id).ToList();
                foreach (var item in product_rawmaterial)
                {
                    product_rawMaterialBody product_RawMaterialBody = new product_rawMaterialBody();
                    product_RawMaterialBody.raw_material = rawMaterialManager.Current.GetOne((Guid)item.raw_material_id);
                    product_RawMaterialBody.quantity = (int)item.quantity;
                    raw_Materials.Add(product_RawMaterialBody);
                }
                return raw_Materials;
            }
        }

        public void DeleteJoin(product product)
        {
            using (var db = new sistema_control_comercio())
            {
                List<product_rawmaterial> product_rawmaterial = db.product_rawmaterial.Where(x => x.product_id == product.product_id).ToList();
                foreach (var item in product_rawmaterial)
                {
                    db.product_rawmaterial.Attach(item);
                    db.product_rawmaterial.Remove(item);
                    db.SaveChanges();
                }
            }
        }
        


    }
}