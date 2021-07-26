using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{

    public class CreateStoreDTO
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class UpdateStoreDTO : CreateStoreDTO
    {
        public virtual IList<CreateProductDTO> Products { get; set; }
    }
    public class StoreDTO : CreateStoreDTO
    {
        public int Id { get; set; }        
        public virtual IList<ProductDTO> Products { get; set; }
    }
}
