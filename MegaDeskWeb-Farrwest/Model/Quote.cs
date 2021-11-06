using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MegaDeskWeb_Farrwest.Model
{
    public class Quote
    {

        public Quote(int width, int depth, int numOfDrawers, MaterialType desktopMaterial, string customerName, DeliveryOptions deliveryOptions)
        {
            // desktop material and deliveryOptions changed to ints so that is scaffolds easier.
            this.desktopMaterial = desktopMaterial;
            this.deliveryOptions = deliveryOptions;


            this.width = width;
            this.depth = depth;
            this.numOfDrawers = numOfDrawers;
            this.customerName = customerName;
            this.totalPrice = calculateTotalPrice();
            this.dateDisplayString = this.quoteDate.ToShortDateString();
        }

        public Quote()
        {
            this.desktopMaterial = 0;
            this.deliveryOptions = 0;


            this.width = 0;
            this.depth = 0;
            this.numOfDrawers = 0;
            this.customerName = "";
            this.totalPrice = 0;
            this.dateDisplayString = this.quoteDate.ToShortDateString();
        }

        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(30)]
        [Display(Name = "Name")]
        [Required]
        public string customerName { get; set; }

        [Range(24, 96)]
        [Display(Name = "Width")]
        [Required]
        public int width { get; set; }

        [Range(12, 48)]
        [Display(Name = "Depth")]
        [Required]
        public int depth { get; set; }

        [Range(0,7)]
        [Display(Name = "# Drawers")]
        [Required]
        public int numOfDrawers { get; set; }

        [Display(Name = "Material")]
        [Range(0,4)]
        [Required]
        public MaterialType desktopMaterial { get; set; }

        [Display(Name = "Rush Order")]
        [Range(0,2)]
        [Required]
        public DeliveryOptions deliveryOptions { get; set; }

        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        public double totalPrice { get; set; }

        [Display(Name = "Date")]
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
                case MaterialType.Oak:
                    deskTopMaterialPrice = PRICEFOROAKTOP;
                    break;
                case MaterialType.Laminate:
                    deskTopMaterialPrice = PRICEFORLAMINATETOP;
                    break;
                case MaterialType.Rosewood:
                    deskTopMaterialPrice = PRICEFORROSEWOODTOP;
                    break;
                case MaterialType.Veneer:
                    deskTopMaterialPrice = PRICEFORVENEERTOP;
                    break;
                case MaterialType.Pine:
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
                case DeliveryOptions.Three:
                    deliveryPrice = ((deskSizePrice < 1000) ? rushOrderPrices[(int)DeliveryOptions.Three, 0] : (deskSizePrice > 1000 && deskSizePrice < 2000) ? rushOrderPrices[(int)DeliveryOptions.Three, 1] : rushOrderPrices[(int)DeliveryOptions.Three, 2]);
                    break;
                case DeliveryOptions.Five:
                    deliveryPrice = ((deskSizePrice < 1000) ? rushOrderPrices[(int)DeliveryOptions.Five, 0] : (deskSizePrice > 1000 && deskSizePrice < 2000) ? rushOrderPrices[(int)DeliveryOptions.Five, 1] : rushOrderPrices[(int)DeliveryOptions.Five, 2]);
                    break;
                case DeliveryOptions.Seven:
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

        public enum MaterialType
        {
            Laminate, Oak, Rosewood, Veneer, Pine
        }
    }
}
