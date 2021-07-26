using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public double Price { get; set; }

        [ForeignKey(nameof(Store))]
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
