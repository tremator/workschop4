using System.Collections.Generic;

namespace WorkShop4.Models
{
    public class Order
    {
        public long id { get; set; }
        public long clientId { get; set; }
        public Client client { get; set; }
        
        public List<Product> products { get; set; }
        public List<long> productsId { get; set; }
    }
}