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
            
            
            Console.WriteLine("Welcome to the Bank of Ukraine");
            Console.WriteLine("Do you have an account or would you like to open a new account?");
            Console.WriteLine("Select 1 to create new account");
            Console.WriteLine("Select 2 to access existing account");
            userResponse = int.Parse(Console.ReadLine());

            if(userResponse == 1)
            {
                Customer newCust = new Customer();
                Console.WriteLine("Please enter the new customers name.");
                acctName = Console.ReadLine();
                Console.WriteLine("What type of account would you like to open?");
                Console.WriteLine("Select 1 for checking.");
                Console.WriteLine("Select 2 for saving.");
                acctType = int.Parse(Console.ReadLine());
                
                if(acctType == 1)
                {
                    
                    Checking checkAcct = new Checking(acctName, 1000);
                    // Pete: I think you're just missing adding the new checkAcct to the customer's list.
                    // If I add these two lines here I think it will do what you wanted:
                    var allCheckingAccounts = newCust.GetCheckAccount();
                    allCheckingAccounts.Add(checkAcct);

                    // But!  The code I wrote above is violating the Tell Don't Ask principle.
                    // I'm asking newCust for the checking accounts, and then I do something
                    // to the checking accounts.  The idea with TDAP is that I should "Tell"
                    // the newCust class that I want to add an account, and it should be responsible
                    // for making that happen.  So, I'd refactor it to use something like this instead:
                    //newCust.AddCheckingAccount(checkAcct);
                    // That way I'm saying "Hey, newCust, you should add this new checking account" but
                    // I don't know the details about how that happens.
                    // Martin Fowler has a great article on it here:
                    //  https://martinfowler.com/bliki/TellDontAsk.html

                    Console.WriteLine(newCust.GetCheckAccount().Exists(x => x.Name == acctName));
                    //This keeps coming up false even though I believe the object is being saved to the checking list
                    var userCkaccount = newCust.GetChecking(acctName); // Trying to find the account that i've created earlier
                    //The above userCKaccount keeps returning null. I dont know why
                    userCkaccount.Deposit(100); // trying to add money on it
                    Console.WriteLine("{0} account balance is {1}", userCkaccount.Name, userCkaccount.AcctBal);
                }

            }
            
            
        }
    }
}
