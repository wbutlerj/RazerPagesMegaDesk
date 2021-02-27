using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using RazerPagesMegaDesk.Data;

namespace RazerPagesMegaDesk.Model
{

    /*  public enum Shipping
      {
          NoRush,
          Rush3Day, 
          Rush5Day, 
          Rush7Day
      }*/

    public class DeskQuote
    {

        //Constants
        private const decimal BASE_DESK_PRICE = 200.00m;
        private const decimal SURFACE_AREA_COST = 1.00m;
        private const decimal DRAWER_COST = 50.00m;

        //properties
        public int DeskQuoteId { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Quote Date")]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Quote Price")]
        [DisplayFormat(DataFormatString ="{0:C}")]
        public decimal QuotePrice { get; set; }

        public int DeskId { get; set; }
        [Display(Name = "Shipping Type")]
        public int ShippingId { get; set; }

        //Navigation properties
        public Desk Desk { get; set; } 

        public Shipping Shipping { get; set; }


    public decimal GetQuotePrice(RazerPagesMegaDeskContext context)
        {
            // return value
            decimal quoteTotal = BASE_DESK_PRICE;


            // surface area
            decimal area = this.Desk.Width * this.Desk.Depth;

            //surface price
            decimal surfacePrice = 0.00M;

            if (area > 1000)
            {
           
                surfacePrice = (area - 1000) * SURFACE_AREA_COST;
                /*var extra = area - 1000;*/
                /*quoteTotal = quoteTotal + extra;*/
            }


            // drawers

            decimal drawerPrice = this.Desk.NumberOfDrawers * DRAWER_COST;


            // 4 add shipping costs
            decimal shippingPrice = 0.00M;
            if (area < 1000) {
                var under1000 = context.Shipping
                    .Where(d => d.ShippingId == this.ShippingId).FirstOrDefault();
                shippingPrice = under1000.PricUnder1000;
            }
            else if (area < 2000) {
                var under2000 = context.Shipping
                        .Where(d => d.ShippingId == this.ShippingId).FirstOrDefault();
                shippingPrice = under2000.PriceBetween1000and2000;
            }
            else {
                var over2000 = context.Shipping
                            .Where(d => d.ShippingId == this.ShippingId).FirstOrDefault();
                shippingPrice = over2000.PriceOver2000;
            } 

                //5 add surface material cost
                decimal surfaceMaterialPrice = 0.00M;
            var surfaceMaterialPrices = context.SurfaceMaterial
                .Where(d => d.SurfaceMaterialId == this.Desk.SurfaceMaterialId).FirstOrDefault();

            surfaceMaterialPrice = surfaceMaterialPrices.Cost;

            quoteTotal = quoteTotal + surfacePrice + drawerPrice + shippingPrice + surfaceMaterialPrice;

            return quoteTotal;


            /*   //read in
               decimal[,] rushOrderPrices;

               rushOrderPrices = GetRushOrder();*/



            /* decimal rushCost = (decimal)Shipping;
             if (area < 1000)
             {
                 switch (rushCost)
                 {
                     case 0:
                         break;
                     case 1:
                         quoteTotal = quoteTotal + rushOrderPrices[0, 0];
                         break;
                     case 2:
                         quoteTotal = quoteTotal + rushOrderPrices[2, 1];
                         break;
                     case 3:
                         quoteTotal = quoteTotal + rushOrderPrices[3, 1];
                         break;
                 }
             }
             else if (area < 2000)
             {
                 switch (rushCost)
                 {
                     case 0:
                         break;
                     case 1:
                         quoteTotal = quoteTotal + rushOrderPrices[0, 1];
                         break;
                     case 2:
                         quoteTotal = quoteTotal + rushOrderPrices[1, 1];
                         break;
                     case 3:
                         quoteTotal = quoteTotal + rushOrderPrices[2, 1];
                         break;
                 }
             }
             else
             {
                 switch (rushCost)
                 {
                     case 0:
                         break;
                     case 1:
                         quoteTotal = quoteTotal + rushOrderPrices[0, 2];
                         break;
                     case 2:
                         quoteTotal = quoteTotal + rushOrderPrices[1, 2];
                         break;
                     case 3:
                         quoteTotal = quoteTotal + rushOrderPrices[2, 2];
                         break;
                 }
             }*/

            //5 add surface material cost


            //if (this.Desk.SurfaceMaterial == SurfaceMaterial.Oak) 
            //{
            //    quoteTotal = quoteTotal + 200;
            //}

            //else if (this.Desk.SurfaceMaterial == SurfaceMaterial.Laminate)
            //{
            //    quoteTotal = quoteTotal + 100;
            //}

            //else if (this.Desk.SurfaceMaterial == SurfaceMaterial.Pine)
            //{
            //    quoteTotal = quoteTotal + 50;
            //}

            //else if (this.Desk.SurfaceMaterial == SurfaceMaterial.Rosewood)
            //{
            //    quoteTotal = quoteTotal + 300;
            //}

            //else if (this.Desk.SurfaceMaterial == SurfaceMaterial.Veneer)
            //{
            //    quoteTotal = quoteTotal + 125;
            //}




        }

        /*public static decimal[,] GetRushOrder()
        {
            decimal[,] rushOrderPrices = new decimal[3, 3];

            string file = @"rushOrderPrices.txt";

            string[] lines = File.ReadAllLines(file);

            int a = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    rushOrderPrices[x, y] = decimal.Parse(lines[a]);
                    a++;
                }
            }

            return rushOrderPrices; 
        }*/


    }

}
