using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Item
    {
        public Item(string name, int quantity, string type, decimal price)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Type = type;
            this.Price = price;
        }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

        public string MakeSound()
        {
            string typeMessage = "";
            switch (Type)
            {
                case "Chip":
                    typeMessage = "Crunch Crunch, Yum!";
                    break;
                case "Candy":
                    typeMessage = "Munch Munch, Yum!";
                    break;
                case "Drink":
                    typeMessage = "Glug Glug, Yum!";
                    break;
                case "Gum":
                    typeMessage = "Chew Chew, Yum!";
                    break;
            }
            return typeMessage;
        }
    }
}
