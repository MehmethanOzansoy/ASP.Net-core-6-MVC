﻿using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {

             new Product { Id = 1, Name = "Silgi", Price = 100, Stock = 200 },
             new Product { Id = 2, Name = "Kalem", Price = 250, Stock = 400 },
             new Product { Id = 4, Name = "Defter", Price = 4004, Stock = 600 }
        };

        

        public List<Product> GetAll() => _products;
       
        public void Add(Product newProduct) => _products.Add(newProduct);

        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == id);

            if(hasProduct == null)
            {
                throw new Exception($"Bu id({id})' ye sahip ürün bulunmamaktadır");
            }else
            {
                _products.Remove((Product)hasProduct);
            }  
            
        }
        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == updateProduct.Id);

            if(hasProduct == null)
            {
                throw new Exception($"Bu id({updateProduct.Id})' ye sahip ürün bulunmamaktadır");
            }

            else
            {
                hasProduct.Name = updateProduct.Name;
                hasProduct.Price = updateProduct.Price;
                hasProduct.Stock = updateProduct.Stock;

                var index = _products.FindIndex(x => x.Id == updateProduct.Id);

                _products[index] = hasProduct;
            }
        }


    }
}
