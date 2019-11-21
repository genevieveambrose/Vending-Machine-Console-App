using Capstone.Models;
using Capstone.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Models
{
    public class Machine
    {
        public decimal CurrentMoney { get; private set; }
        public Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();

        public void Load(string path)
        {
            string line = "";
            
            string[] information = new string[4];

            using (StreamReader sr = new StreamReader(path))
            {

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    information = line.Split("|");
                    string informationTwo = information[2];
                    decimal informationTwoD = decimal.Parse(informationTwo);
                    Item item = new Item(information[1], 5, information[3], informationTwoD);
                    itemDictionary.Add(information[0], item);
                }
            }
        }



        public decimal AddMoney(decimal moneyAddedDecimal)
        {
            CurrentMoney += moneyAddedDecimal;
            LogTxt.Write($"{DateTime.Now} FEED MONEY: {moneyAddedDecimal:C} {CurrentMoney:C} ");
            return CurrentMoney;
        }


        public Item DispenseItem(string input)
        {

            if (itemDictionary.ContainsKey(input))
            {
                Item item = itemDictionary[input];

                if (item.Quantity > 0)
                {

                    if (CurrentMoney >= item.Price)
                    {
                        CurrentMoney -= item.Price;
                        
                        item.Quantity -= 1;
                        LogTxt.Write($"{DateTime.Now} {item.Name} {CurrentMoney + item.Price:C} {CurrentMoney:C} ");


                        return item;

                        
                        
                    }
                    else
                    {
                        throw new Exception("Sorry, you do not have enough money to purchase this item!");
                        
                    }
                }
                else
                {
                    throw new Exception("Sorry, this item is sold out!");
                }


            }
            else
            {
                throw new Exception("Product does not exist!");
            }

        }
        public string GiveChange()
        {
            int quarterCount = 0;
            int dimeCount = 0;
            int nickelCount = 0;
            LogTxt.Write($"{DateTime.Now} GIVE CHANGE: {CurrentMoney:C} $0.00");
            while (CurrentMoney > 0)
            {
                if (CurrentMoney >= .25M)
                {
                    CurrentMoney -= .25M;
                    quarterCount++;
                }
                if (CurrentMoney >= .10M && CurrentMoney < .25M)
                {
                    CurrentMoney -= .10M;
                    dimeCount++;
                }
                if (CurrentMoney >= .05M && CurrentMoney < .10M)
                {
                    CurrentMoney -= .05M;
                    nickelCount++;
                }
            }
            
            return $"Your change is: {quarterCount} Quarters, {dimeCount} Dimes and {nickelCount} Nickels.";

        }
        public Dictionary<string, int> salesReportDictionary = new Dictionary<string, int>();

    }
}
