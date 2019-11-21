using Capstone.Models;
using Capstone.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace CapstoneTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMoneyTestFirstTime()
        {
            //Arrange
            Machine machine = new Machine();
            LogTxt.LogPath = @"..\..\..\..\log.txt";
            //Act
            decimal actualResult = machine.AddMoney(5.00M);
            //Assert
            Assert.AreEqual(5.00M, actualResult);
        }

        [TestMethod]
        public void AddMoneyTestFirstAgain()
        {

            //Arrange
            Machine machine = new Machine();
            LogTxt.LogPath = @"..\..\..\..\log.txt";
            decimal actualResult = 5.00M;
            //Act
            actualResult += machine.AddMoney(10.00M);
            //Assert
            Assert.AreEqual(15.00M, actualResult);
        }


        [TestMethod]
        public void GetChangeQuarterTest()
        {
            //Arrange
            Machine machine = new Machine();
            LogTxt.LogPath = @"..\..\..\..\log.txt";
            machine.AddMoney(1);
            //Act
            string actualResult = machine.GiveChange();
            //Assert
            Assert.AreEqual("Your change is: 4 Quarters, 0 Dimes and 0 Nickels.", actualResult);
        }

        [TestMethod]
        public void GetChangeDimeTest()
        {
            
            //Arrange
            Machine machine = new Machine();
            LogTxt.LogPath = @"..\..\..\..\log.txt";
            machine.AddMoney(0.20M);
            //Act
            string actualResult = machine.GiveChange();
            //Assert
            Assert.AreEqual("Your change is: 0 Quarters, 2 Dimes and 0 Nickels.", actualResult);
        }

        [TestMethod]
        public void GetChangeNickelTest()
        {
            //Arrange
            Machine machine = new Machine();
            LogTxt.LogPath = @"..\..\..\..\log.txt";
            machine.AddMoney(0.05M);
            //Act
            string actualResult = machine.GiveChange();
            //Assert
            Assert.AreEqual("Your change is: 0 Quarters, 0 Dimes and 1 Nickels.", actualResult);
        }

        [TestMethod]
        public void MakeSoundTestChip()
        {
            //Arrange
            Machine machine = new Machine();
            machine.Load((@"..\..\..\..\vendingmachine.csv"));
            Item item = new Item("Potato Crisps", 5, "Chip", 3.05M);
            LogTxt.LogPath = @"..\..\..\..\log.txt";
            machine.AddMoney(10.00M);
            machine.DispenseItem("A1");
            //Act
            string actualResult = item.MakeSound();
            //Assert
            Assert.AreEqual("Crunch Crunch, Yum!", actualResult);
        }

        [TestMethod]
        public void MakeSoundTestCandy()
        {
            //Arrange
            Machine machine = new Machine();
            machine.Load((@"..\..\..\..\vendingmachine.csv"));
            Item item = new Item("Moonpie", 5, "Candy", 1.80M);
            LogTxt.LogPath = @"..\..\..\..\log.txt";
            machine.AddMoney(10.00M);
            machine.DispenseItem("B1");
            //Act
            string actualResult = item.MakeSound();
            //Assert
            Assert.AreEqual("Munch Munch, Yum!", actualResult);
        }

        [TestMethod]
        public void MakeSoundTestDrink()
        {
            //Arrange
            Machine machine = new Machine();
            machine.Load((@"..\..\..\..\vendingmachine.csv"));
            Item item = new Item("Cola", 5, "Drink", 1.25M);
            LogTxt.LogPath = @"..\..\..\..\log.txt";
            machine.AddMoney(10.00M);
            machine.DispenseItem("C1");
            //Act
            string actualResult = item.MakeSound();
            //Assert
            Assert.AreEqual("Glug Glug, Yum!", actualResult);
        }

        [TestMethod]
        public void MakeSoundTestGum()
        {
            //Arrange
            Machine machine = new Machine();
            machine.Load((@"..\..\..\..\vendingmachine.csv"));
            Item item = new Item("U-Chews", 5, "Gum", 0.85M);
            LogTxt.LogPath = @"..\..\..\..\log.txt";
            machine.AddMoney(10.00M);
            machine.DispenseItem("D1");
            //Act
            string actualResult = item.MakeSound();
            //Assert
            Assert.AreEqual("Chew Chew, Yum!", actualResult);
        }

        [TestMethod]
        public void LoadTest_CheckinStock()
        {
            //Arrange
            Machine machine = new Machine();
            machine.Load((@"..\..\..\..\vendingmachine.csv"));
            Item item = new Item("Heavy", 5, "Drink", 1.50M);
            LogTxt.LogPath = @"..\..\..\..\log.txt";
            machine.AddMoney(10.00M);
            machine.DispenseItem("C4");
            //Act
            string actualResult = item.MakeSound();
            //Assert
            Assert.AreEqual("Glug Glug, Yum!", actualResult);
        }

        [TestMethod]
        public void DispenseItem_D1_NotEnoughtMoney()
        {
            //Arrange
            Machine machine = new Machine();
            LogTxt.LogPath = @"..\..\..\..\log.txt";
            machine.Load((@"..\..\..\..\vendingmachine.csv"));
            Item item = new Item("U-Chews", 5, "Gum", 0.85M);

            //Act
            try
            {
                Item actualResult = machine.DispenseItem("D1");
            }
            catch (Exception ex) when (ex.Message == "Sorry, you do not have enough money to purchase this item!")
            {
                Assert.AreEqual("Sorry, you do not have enough money to purchase this item!", ex.Message);
            }
            
            //Assert
      
            
        }

        [TestMethod]
        public void DispenseItem_D1_OutOfStock()
        {
            //Arrange
            Machine machine = new Machine();
            LogTxt.LogPath = @"..\..\..\..\log.txt";
            machine.Load((@"..\..\..\..\vendingmachine.csv"));
            Item item = new Item("U-Chews", 4, "Gum", 0.85M);
            machine.AddMoney(10.00M);
            machine.DispenseItem("D1");
            machine.DispenseItem("D1");
            machine.DispenseItem("D1");
            machine.DispenseItem("D1");
            machine.DispenseItem("D1");
            //Act
            try
            {
                Item actualResult = machine.DispenseItem("D1");
            }
            catch (Exception ex) when (ex.Message == "Sorry, this item is sold out!")
            {
                Assert.AreEqual("Sorry, this item is sold out!", ex.Message);
            }
 
        }

        [TestMethod]
        public void DispenseItem_WrongItemCode()
        {
            //Arrange
            Machine machine = new Machine();
            LogTxt.LogPath = @"..\..\..\..\log.txt";
            machine.Load((@"..\..\..\..\vendingmachine.csv"));
            Item item = new Item("U-Chews", 4, "Gum", 0.85M);
            machine.AddMoney(10.00M);

            //Act
            try
            {
                Item actualResult = machine.DispenseItem("Z1");
            }
            catch (Exception ex) when (ex.Message == "Product does not exist!")
            {
                Assert.AreEqual("Product does not exist!", ex.Message);
            }

        }

        [TestMethod]
        public void DispenseItem_Working()
        {
            //Arrange
            Machine machine = new Machine();
            LogTxt.LogPath = @"..\..\..\..\log.txt";
            machine.Load((@"..\..\..\..\vendingmachine.csv"));
            Item item = new Item("U-Chews", 4, "Gum", 0.85M);
            machine.AddMoney(10.00M);

            //Act
            Item actualResult = machine.DispenseItem("D1");

            //Assert
            Assert.AreEqual("U-Chews", actualResult.Name);
            Assert.AreEqual(4, actualResult.Quantity);
            Assert.AreEqual("Gum", actualResult.Type);
            }

        }


    }

    

