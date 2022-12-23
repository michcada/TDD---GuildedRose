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
                                    this.QualityIncrease(1);
                                }
                            }
                            break;

                        case ("Backstage passes"):
                            {
                                if (this.QualityValue == 50)
                                {
                                    break;
                                }
                                else
                                {
                                    if (this.SellInValue > 10)
                                    {
                                        {
                                            this.SellInReduce(1);
                                            this.QualityIncrease(1);
                                        }
                                    }
                                    else
                                    {
                                        if (this.SellInValue <= 10)
                                        {
                                            {
                                                if (this.SellInValue > 5)
                                                {
                                                    if (this.QualityValue < 49)
                                                    {
                                                        this.SellInReduce(1);
                                                        this.QualityIncrease(2);
                                                    }
                                                    else
                                                    {
                                                        this.SellInReduce(1);
                                                        this.QualityIncrease(1);
                                                    }
                                                }
                                                else
                                                {
                                                    if (this.QualityValue < 48)
                                                    {
                                                        if (this.SellInValue > 0)
                                                        {
                                                            this.SellInReduce(1);
                                                            this.QualityIncrease(3);
                                                        }
                                                        else
                                                        {
                                                            this.QualityValue = 0;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (this.SellInValue > 0)
                                                        {
                                                            this.SellInReduce(1);
                                                            this.QualityValue = 50;
                                                        }
                                                        else
                                                        {
                                                            this.QualityValue = 0;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
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
                                            if (this.QualityValue > 0 && !this.Name.Contains("Conjured"))
                                            {
                                                this.QualityReduce(2);
                                            }
                                            else
                                            {
                                                if (this.QualityValue > 0 && this.Name.Contains("Conjured"))
                                                {
                                                    this.QualityReduce(4);
                                                }
                                            }
                                            break;

                                    }
                                    break;

                                default:
                                    if (this.SellInValue > 0)
                                    {
                                        this.SellInReduce(1);
                                    }

                                    if (this.QualityValue > 0 && !this.Name.Contains("Conjured"))
                                    {
                                        this.QualityReduce(1);
                                    }
                                    else
                                    {
                                        if (this.QualityValue > 0 && this.Name.Contains("Conjured"))
                                        {
                                            this.QualityReduce(2);
                                        }
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
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    Console.WriteLine("You have a Sulfuras, its quality is always 80\nThis item never has to be sold");
                }
            }
        }

        void SellInReduce(int reduc)
        {
            this.SellInValue -= reduc;
        }
        void QualityReduce(int reduc)
        {
            this.QualityValue -= reduc;
        }
        void QualityIncrease(int incr)
        {
            this.QualityValue += incr;
        }
    }
}