using System.Collections.Generic;

namespace ArtMangementmvc.Models
{
    public class CustomerType
    {
        public CustomerType()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }


        public virtual ICollection<Sale> Sales { get; set; }
    }
}