using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb_Farrwest.Model
{
    public class Quote
    {

        public Quote(int width, int depth, int numOfDrawers, int desktopMaterial, string customerName, int deliveryOptions)
        {
            // desktop material and deliveryOptions changed to ints so that is scaffolds easier.
            this.desktopMaterial = desktopMaterial;
            this.deliveryOptions = deliveryOptions;


            this.width = width;
            this.depth = depth;
            this.numOfDrawers = numOfDrawers;
            this.customerName = customerName;
            this.totalPrice = calculateTotalPrice();
            this.dateDisplayString = this.quoteDate.ToString();
        }

        public int ID { get; set; }

        public int width { get; set; }
        public int depth { get; set; }
        public int numOfDrawers { get; set; }
        public int desktopMaterial { get; set; }
        public string customerName { get; set; }
        public int deliveryOptions { get; set; }

        public double totalPrice { get; set; }

        public string dateDisplayString { get; set; }

        public DateTime quoteDate { get; set; } = DateTime.Now;




        public double calculateTotalPrice()
        {
            const double BASEDESKPRICE = 200;
            const double PRICEPERINCH = 1;
            const double PRICEPERDRAWER = 50;
            const double PRICEFOROAKTOP = 200;
            const double PRICEFORLAMINATETOP = 100;
            const double PRICEFORPINETOP = 50;
            const double PRICEFORROSEWOODTOP = 300;
            const double PRICEFORVENEERTOP = 125;

            double deskBasePrice = BASEDESKPRICE;
            double deskDrawersPrice = PRICEPERDRAWER * this.numOfDrawers;
            double deskSizePrice = (this.width * this.depth) * PRICEPERINCH;
            double deskTopMaterialPrice = 0;
            double deliveryPrice = 0;

            switch (this.desktopMaterial)
            {
                case 1:
                    deskTopMaterialPrice = PRICEFOROAKTOP;
                    break;
                case 0:
                    deskTopMaterialPrice = PRICEFORLAMINATETOP;
                    break;
                case 2:
                    deskTopMaterialPrice = PRICEFORROSEWOODTOP;
                    break;
                case 3:
                    deskTopMaterialPrice = PRICEFORVENEERTOP;
                    break;
                case 4:
                    deskTopMaterialPrice = PRICEFORPINETOP;
                    break;
            }

            

            // This is where we read in from a file in the other assignment. Not sure if we need to do that again here.
            var rushOrderPrices = new int[3, 3] {
                { 60, 70, 80 },
                { 40, 50, 60 },
                { 30, 35, 40 }
            };

            switch (deliveryOptions)
            {
                case 0:
                    deliveryPrice = ((deskSizePrice < 1000) ? rushOrderPrices[(int)DeliveryOptions.Three, 0] : (deskSizePrice > 1000 && deskSizePrice < 2000) ? rushOrderPrices[(int)DeliveryOptions.Three, 1] : rushOrderPrices[(int)DeliveryOptions.Three, 2]);
                    break;
                case 1:
                    deliveryPrice = ((deskSizePrice < 1000) ? rushOrderPrices[(int)DeliveryOptions.Five, 0] : (deskSizePrice > 1000 && deskSizePrice < 2000) ? rushOrderPrices[(int)DeliveryOptions.Five, 1] : rushOrderPrices[(int)DeliveryOptions.Five, 2]);
                    break;
                case 2:
                    deliveryPrice = ((deskSizePrice < 1000) ? rushOrderPrices[(int)DeliveryOptions.Seven, 0] : (deskSizePrice > 1000 && deskSizePrice < 2000) ? rushOrderPrices[(int)DeliveryOptions.Seven, 1] : rushOrderPrices[(int)DeliveryOptions.Seven, 2]);
                    break;
            }

            // return the total cost
            return deskBasePrice + deskDrawersPrice + deskTopMaterialPrice + deliveryPrice;
        }


        public enum DeliveryOptions
        {
            Three, Five, Seven
        }
    }
}
