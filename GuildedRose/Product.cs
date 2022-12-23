using System.Reflection;
using System.Xml.Linq;

namespace GuildedRose
{
    public class Product
    {
        public Product(string name, int sellInValue, int qualityValue)
        {
            this.Name = name;
            this.SellInValue = sellInValue;
            this.QualityValue = qualityValue;
        }

        public string Name { get; }
        public int SellInValue { get; set; }
        public int QualityValue { get; set; }
        public void UpdateProduct()
        {
            if (this.Name != "Sulfuras")
            {
                if (this.QualityValue <= 50)
                {
                    switch (this.Name)
                    {
                        case ("Aged Brie"):
                            {
                                if (this.QualityValue == 50)
                                {
                                    break;
                                }
                                else
                                {
                                    this.SellInReduce(1);
                                    this.QualityValue++;
                                }
                            }
                            break;

                        default:
                            switch (this.SellInValue)
                            {
                                case 0:
                                    switch (this.QualityValue)
                                    {
                                        case 0:
                                            break;
                                        case 1:
                                            this.QualityValue = 0;
                                            break;
                                        default:
                                            this.QualityReduce(2);
                                            break;

                                    }
                                    break;

                                default:
                                    if (this.SellInValue > 0)
                                    {
                                        this.SellInReduce(1);
                                    }
                                    if (this.QualityValue > 0)
                                    {
                                        this.QualityReduce(1);
                                    }
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }


            }
            else
            {
                if (this.QualityValue != 80)
                {
                    this.QualityValue = 80;
                    Console.WriteLine("You have a Sulfuras, its quality is always 80\nQuality updated to 80\nThis item has never be sold");
                }
                else
                {
                    Console.WriteLine("You have a Sulfuras, its quality is always 80\nThis item never has to be sold");
                }
            }
        }

        void SellInReduce(int reduc)
        {
            this.SellInValue-=reduc;
        }
        void QualityReduce(int reduc)
        {
            this.QualityValue-=reduc;
        }
    }
}