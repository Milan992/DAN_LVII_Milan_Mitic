using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfReceipt
{
    public class Article
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public Article() { }

        public Article(string name, int price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }

        public override string ToString()
        {
            return Name + ", " + Price + ", " + Amount;
        }
    }
}