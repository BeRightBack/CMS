using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public double Price { get; set; }


        public int StoreId { get; set; }        
    }

    public class UpdateProductDTO : CreateProductDTO
    {
        
    }

    public class ProductDTO : CreateProductDTO
    {
        public int Id { get; set; }       
        public StoreDTO Store { get; set; }
    }
}
