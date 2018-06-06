using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantiateUsingVariables
{
    abstract class Account  
    {
        //Properties
        public double AcctBal { get; set; }
        public double DepositAmt { get; set; }
        public double WithdrawAmt { get; set; }
        public string Name { get; set; }

        //Constructor
        public Account()
        {
               //Default Constructor
        }

        public double Deposit(double num)
        {
            AcctBal = AcctBal + num;
            return AcctBal;
        }
        public virtual double Withdraw(double num)
        {
            AcctBal = AcctBal - num;
            return AcctBal;
        }

        public virtual double CheckBalance()
        {
            return AcctBal;
        }
    }
}
