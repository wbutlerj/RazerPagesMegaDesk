using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazerPagesMegaDesk.Model
{
    public class Shipping
    {
        //need to add 0 3 5 7 day rows to shippingname column
        //need to add coressponding prices based on square inches and number of days


        //properties
        public int ShippingId { get; set; }
        public string ShippingName { get; set; }
       /* public decimal Cost { get; set; }*/

        public decimal PricUnder1000 { get; set; }
        public decimal PriceBetween1000and2000 { get; set; }
        public decimal PriceOver2000 { get; set; }

    }
}
