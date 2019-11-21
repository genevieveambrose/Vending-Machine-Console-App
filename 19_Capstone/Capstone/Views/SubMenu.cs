using Capstone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Views
{
    public class SubMenu : CLIMenu
    {
        
        
        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public SubMenu(Machine machine) : base(machine)
        {
            this.Title = "*** Sub Menu ***";
            this.menuOptions.Add("1", "Feed Money");
            this.menuOptions.Add("2", "Select Product");
            this.menuOptions.Add("3", "Finish Transaction");
            


            
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {

           


            switch (choice)
            {
                
                case "1":
                    Console.Clear();
                    while (true)
                    {
                        decimal moneyAddedDecimal = GetDecimal("Please enter money in whole dollar amounts.");
                        //Console.WriteLine("Please enter moneys in whole dollar amounts.");
                        //string moneyAdded = Console.ReadLine();
                        //decimal moneyAddedDecimal = decimal.Parse(moneyAdded);
                        myMachine.AddMoney(moneyAddedDecimal);
                        Console.WriteLine($"Your current balance is {myMachine.CurrentMoney:C}");
                        Console.WriteLine("Press 1 to enter more, press 2 to finish adding money.");
                        string exit = Console.ReadLine();
                        if (exit == "2")
                        {
                            return true;
                        }
                    }

                case "2":
                    Console.Clear();
                    DisplayItems();
                    Console.WriteLine("Please enter a product code.");
                    string input = Console.ReadLine().Substring(0,2).ToUpper();

                    try
                    {
                        Item item = myMachine.DispenseItem(input);
                        if (item != null)
                        {
                            Console.WriteLine($"You bought {item.Name} and have {myMachine.CurrentMoney:C} remaining!  The item cost you {item.Price:C}.");
                            Console.WriteLine(item.MakeSound());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Pause("");
                    return true;
                case "3":
                    Console.Clear();
                    Console.WriteLine(myMachine.GiveChange());
                    Console.ReadKey();
                    return false;
                    
            }
            return true;
        }
    }
}
