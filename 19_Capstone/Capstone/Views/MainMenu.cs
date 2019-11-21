using Capstone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Views
{
    
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class MainMenu : CLIMenu
    {
        Machine machine = new Machine();

        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        /// 

        public MainMenu(Machine machine) : base(machine)
        {
            this.Title = "*** Main Menu ***";
            this.menuOptions.Add("1", "Display Vending Machine Items");
            this.menuOptions.Add("2", "Purchase");
            this.menuOptions.Add("3", "Exit");
            
            
            //this.menuOptions.Add("Q", "Quit");

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
                    DisplayItems();
                    Console.ReadLine();

                    return true;
                case "2":
                    SubMenu sm = new SubMenu(myMachine);
                    sm.Run();
                    return true;
                case "3":
                    break;
                case "4":
                    return false;
            }
            return false;
        }

    }
}
