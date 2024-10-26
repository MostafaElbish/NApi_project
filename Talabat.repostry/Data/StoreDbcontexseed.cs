using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.API.Entities;
using Talabat.repostry.Data.Configration;

namespace Talabat.repostry.Data
{
    public static class StoreDbcontexseed
    {

        public static async Task seeedAcync(StoreDbcontext _context)
        {
            if (_context.ProsatcBrand.Count() == 0)
            {


                //Brand
                //reade from file json 
                var BranData = File.ReadAllText(path: "../Talabat.repostry/Data/DataSeed/brands.json");
                //cover json string to needed Type
                var Brandas = JsonSerializer.Deserialize<List<Product>>(BranData);


                if (Brandas?.Count() > 0)
                {
                    foreach (var Brand in Brandas)
                    {
                        _context.Set<Product>().Add(Brand);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            //=======
            if (_context.ProducrCatugory.Count() == 0)
            {
                //catugory
                //reade from file json 
                var CatugeryData = File.ReadAllText(path: "../Talabat.repostry/Data/DataSeed/categories.json");
                //cover json string to needed Type
                var Catugerys = JsonSerializer.Deserialize<List<Product>>(CatugeryData);


                if (Catugerys?.Count() > 0)
                {
                    foreach (var Catugory in Catugerys)
                    {
                        _context.Set<Product>().Add(Catugory);
                    }
                    await _context.SaveChangesAsync();
                }
            }

            //======
            if (_context.Product.Count() == 0)
            {
                //catugory
                //reade from file json 
                var ProdactData = File.ReadAllText(path: "../Talabat.repostry/Data/DataSeed/products.json");
                //cover json string to needed Type
                var Prodacts = JsonSerializer.Deserialize<List<Product>>(ProdactData);


                if (Prodacts?.Count() > 0)
                {
                    foreach (var product in Prodacts)
                    {
                        _context.Set<Product>().Add(product);
                    }
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
