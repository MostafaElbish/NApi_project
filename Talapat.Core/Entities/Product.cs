namespace Talabat.API.Entities
{
    public class Product : BaseEntety
    {
 
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set;}
        public int BrandId { get; set; }
        public ProductBrand Brand { get; set; }
        public int CategoryId { get; set; }
        public ProductCatugory Category { get; set; }


    }
}
