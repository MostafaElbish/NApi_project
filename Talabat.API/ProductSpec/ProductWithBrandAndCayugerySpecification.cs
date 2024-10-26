using Talabat.API.Entities;
using Talapat.Core.Specifications;

namespace Talabat.API.ProductSpec
{
    public class ProductWithBrandAndCayugerySpecification :BaseSpecfication<Product>
    {
        public ProductWithBrandAndCayugerySpecification() : base()
        {

            Include.Add(p=>p.Brand);
            Include.Add(p => p.Category);

        }

        public ProductWithBrandAndCayugerySpecification(int id) : base(p=>p.Id==id)
        {


            Include.Add(p => p.Brand);
            Include.Add(p => p.Category);


        }

    }
}
