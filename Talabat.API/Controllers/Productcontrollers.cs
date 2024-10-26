using Microsoft.AspNetCore.Mvc;
using Talabat.API.Entities;
using Talabat.API.ProductSpec;
using Talapat.Core.Reposters.Interfaces;
using Talapat.Core.Specifications;

namespace Talabat.API.Controllers
{
    public class Productcontrollers:BaseApiController
    {
        private readonly IGenaricReopistres<Product> _ProductRepo;
        public Productcontrollers(IGenaricReopistres<Product>ProductRepo) { 
        
        _ProductRepo= ProductRepo;
        }
        public async Task<ActionResult<IEnumerable<Product>>> Getproducts()
        {
            var spec = new BaseSpecfication<Product>();
            var products = await _ProductRepo.GetAllWithSpecAdync(spec);
            return Ok(products);

        }
        [HttpGet(template: "{id?}")]
        public async Task<ActionResult<Product>> GetProdactbyid(int id)
        {
            var spec = new ProductWithBrandAndCayugerySpecification(id);
            var product = await _ProductRepo.GetWithSpecAsync(spec);

            if (product == null)
            {
                return NotFound(new { Message = "Not Found", StatusCode = 404 });
            }
            else
            {
                return Ok(product);
            }

        }


    }
}
