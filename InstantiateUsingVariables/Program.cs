using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantiateUsingVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            int userResponse;
            string acctName = "";
            int acctType;
            string exitNewUser = "no";
            string exitMainMenu = "no";
            string exitExistingMenu = "no";
            Customer Cust = new Customer();


            Console.WriteLine("Welcome to the Bank of Ukraine");
            while (exitMainMenu.Equals("no"))
            {
                Console.WriteLine("Do you have an account or would you like to open a new account?");
                Console.WriteLine("Select 1 to create new account");
                Console.WriteLine("Select 2 to access existing account menu");
                Console.WriteLine("Select 3 to exit");
                userResponse = int.Parse(Console.ReadLine());
                Console.Clear();
                exitExistingMenu = "no";
                if (userResponse == 1)
                {
                    do
                    {
                        Console.WriteLine("Welcome to the new customers menu.");
                        Console.WriteLine("Please enter the new customers name.");
                        acctName = Console.ReadLine().ToLower();
                        Console.Clear();

                        Console.WriteLine("What type of account would you like to open?");
                        Console.WriteLine("Select 1 for checking.");
                        Console.WriteLine("Select 2 for saving.");
                        acctType = int.Parse(Console.ReadLine());
                        Console.Clear();

                        if (acctType == 1)
                        {

                            Console.WriteLine("How much will you deposit into your checking account today?");
                            double initDeposit = double.Parse(Console.ReadLine());
                            acctName = Cust.ConvertUsername(acctName, acctType);
                            Checking checkAcct = new Checking(acctName, initDeposit);
                            Cust.SetChecking(checkAcct);
                            Console.WriteLine(Cust.GetCheckAccount().Exists(x => x.Name == acctName));
                            var userCkaccount = Cust.GetChecking(acctName);
                            Console.WriteLine("{0} account balance is {1}", userCkaccount.Name, userCkaccount.AcctBal);
                        }
                        else
                        {
                            Console.WriteLine("How much will you deposit into your saving account today?");
                            double initDeposit = double.Parse(Console.ReadLine());
                            acctName = Cust.ConvertUsername(acctName, acctType);
                            Saving saveAcct = new Saving(acctName, initDeposit);
                            Cust.SetSaving(saveAcct);
                            Console.WriteLine(Cust.GetSaveAccount().Exists(x => x.Name == acctName));
                            var userSVaccount = Cust.GetSaving(acctName);
                            Console.WriteLine("{0} account balance is {1}", userSVaccount.Name, userSVaccount.AcctBal);
                        }
                        Console.WriteLine("Would you like to enter another account?");
                        Console.WriteLine("Type yes to add another account and no to return to main menu.");
                        exitNewUser = Console.ReadLine().ToLower();
                        Console.Clear();

                    } while (exitNewUser.Equals("yes"));
                }
                else if (userResponse == 2)
                {
                    
                        Console.WriteLine("Please enter the name on your account.");
                        acctName = Console.ReadLine().ToLower();
                        Console.Clear();

                    while (exitExistingMenu.Equals("no"))
                    {    
                        Console.WriteLine("Which account would you like to manage?");
                        Console.WriteLine("Select 1 for checking.");
                        Console.WriteLine("Select 2 for saving.");
                        acctType = int.Parse(Console.ReadLine());
                        Console.Clear();

                        if (acctType == 1) {

                            var checkAcctName = Cust.ConvertUsername(acctName, acctType);
                            
                            if (Cust.GetCheckAccount().Exists(x => x.Name == checkAcctName))
                            {
                                Console.WriteLine("Please select from the following menus options.");
                                Console.WriteLine("Select 1 to check your account balance.");
                                Console.WriteLine("Select 2 to make a deposit into your checking account.");
                                Console.WriteLine("Select 3 to make a withdrawal from your checking account.");
                                string SavAcctName = Cust.ConvertUsername(acctName, 2);
                                if (Cust.GetSaveAccount().Exists(x => x.Name == SavAcctName))
                                { 
                                    Console.WriteLine("Select 4 to transfer funds to your savings account.");
                                }
                                int accountMenuChoice = int.Parse(Console.ReadLine());
                                Console.Clear();
                                switch (accountMenuChoice)
                                {
                                    case 1:
                                        var userCkaccount = Cust.GetChecking(checkAcctName);
                                        userCkaccount.SetInterest(1);
                                        Console.WriteLine("{0} checking account balance is {1}", userCkaccount.Name, userCkaccount.AcctBal);
                                        break;
                                    case 2:
                                        userCkaccount = Cust.GetChecking(checkAcctName);
                                        userCkaccount.SetInterest(1);
                                        Console.Write("Enter an amount to deposit into your checking account: ");
                                        double depositAmt = double.Parse(Console.ReadLine());
                                        userCkaccount.Deposit(depositAmt);
                                        Console.WriteLine("{0} checking account balance is {1}", userCkaccount.Name, userCkaccount.AcctBal);
                                        break;
                                    case 3:
                                        userCkaccount = Cust.GetChecking(checkAcctName);
                                        userCkaccount.SetInterest(1);
                                        Console.Write("Enter an amount to withdraw into your checking account: ");
                                        double withdrawAmt = double.Parse(Console.ReadLine());
                                        userCkaccount.Withdraw(withdrawAmt);
                                        Console.WriteLine("{0} checking account balance is {1}", userCkaccount.Name, userCkaccount.AcctBal);
                                        break;
                                    case 4:
                                        userCkaccount = Cust.GetChecking(checkAcctName);
                                        userCkaccount.SetInterest(1);
                                        Console.Write("Enter an amount to withdraw into your checking account: ");
                                        double transferAmt = double.Parse(Console.ReadLine());
                                        userCkaccount.Withdraw(transferAmt);
                                        var userSVaccount = Cust.GetSaving(SavAcctName);
                                        userSVaccount.Deposit(transferAmt);
                                        userSVaccount.SetInterest(2);
                                        Console.WriteLine("{0} checking account balance is {1}", userCkaccount.Name, userCkaccount.AcctBal);
                                        Console.WriteLine("{0} saving account balance is {1}", userSVaccount.Name, userSVaccount.AcctBal);

                                        break;
                                    default:
                                        Console.WriteLine("You have entered an incorrect value, please try again.");
                                        break;
                                }
                            }
                        }
                        else if (acctType == 2)
                        {

                            var saveAcctName = Cust.ConvertUsername(acctName, acctType);

                            if (Cust.GetSaveAccount().Exists(x => x.Name == saveAcctName))
                            {
                                Console.WriteLine("Please select from the following menus options.");
                                Console.WriteLine("Select 1 to check your account balance.");
                                Console.WriteLine("Select 2 to make a deposit into your saving account.");
                                Console.WriteLine("Select 3 to make a withdrawal from your savings account.");
                                string checkAcctName = Cust.ConvertUsername(acctName, 2);
                                if (Cust.GetCheckAccount().Exists(x => x.Name == checkAcctName))
                                {
                                    Console.WriteLine("Select 4 to transfer funds to your checking account.");
                                }
                                int accountMenuChoice = int.Parse(Console.ReadLine());

                                switch (accountMenuChoice)
                                {
                                    case 1:
                                        var userSVaccount = Cust.GetSaving(saveAcctName);
                                        userSVaccount.SetInterest(2);
                                        Console.WriteLine("{0} savings account balance is {1}", userSVaccount.Name, userSVaccount.AcctBal);
                                        break;
                                    case 2:
                                        userSVaccount = Cust.GetSaving(saveAcctName);
                                        userSVaccount.SetInterest(2);
                                        Console.Write("Enter an amount to deposit into your saving's account: ");
                                        double depositAmt = double.Parse(Console.ReadLine());
                                        userSVaccount.Deposit(depositAmt);
                                        Console.WriteLine("{0} saving account balance is {1}", userSVaccount.Name, userSVaccount.AcctBal);
                                        break;
                                    case 3:
                                        userSVaccount = Cust.GetSaving(saveAcctName);
                                        userSVaccount.SetInterest(2);
                                        Console.Write("Enter an amount to withdraw from your savings account: ");
                                        double withdrawAmt = double.Parse(Console.ReadLine());
                                        while(userSVaccount.AcctBal - withdrawAmt < 150.00)
                                        {
                                            Console.WriteLine("You are required to keep a minimum balance of $150.00 in your saving account.");
                                            Console.WriteLine("You are only authorized to withdraw {0} or less from saving", userSVaccount.AcctBal - 150.00);
                                            Console.WriteLine("Please enter a new value");
                                            withdrawAmt = double.Parse(Console.ReadLine());
                                            userSVaccount.SetInterest(2);
                                        }

                                        userSVaccount.Withdraw(withdrawAmt);
                                        Console.WriteLine("{0} checking account balance is {1}", userSVaccount.Name, userSVaccount.AcctBal);
                                        break;
                                    case 4:
                                        userSVaccount = Cust.GetSaving(saveAcctName);
                                        userSVaccount.SetInterest(2);
                                        Console.Write("Enter an amount to withdraw from your savings account: ");
                                        double transferAmt = double.Parse(Console.ReadLine());
                                        userSVaccount.Withdraw(transferAmt);
                                        var userCkaccount = Cust.GetChecking(checkAcctName);
                                        userCkaccount.Deposit(transferAmt);
                                        userCkaccount.SetInterest(1);
                                        Console.WriteLine("{0} checking account balance is {1}", userCkaccount.Name, userCkaccount.AcctBal);
                                        Console.WriteLine("{0} saving account balance is {1}", userSVaccount.Name, userSVaccount.AcctBal);

                                        break;
                                    default:
                                        Console.WriteLine("You have entered an incorrect value, please try again.");
                                        break;
                                }
                            }
                        }
                        Console.WriteLine("Type yes exit or no manage another account?");
                        exitExistingMenu = Console.ReadLine();
                        Console.Clear();
                    }
                }
                else if (userResponse == 3)
                {
                    Console.WriteLine("Thanks for banking with the Bank of Ukraine.");
                    exitMainMenu = "yes";
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Please select a valid number.");

                }
            }     
        }
    }
}
