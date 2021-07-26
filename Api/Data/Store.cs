using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public virtual IList<Product> Products { get; set; }

    }
}
