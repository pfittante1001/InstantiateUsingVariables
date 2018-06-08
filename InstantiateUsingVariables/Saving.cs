using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantiateUsingVariables
{
    class Saving : Account
    {
        
        public Saving()
        {

        }
        public Saving(string userName, double balance)
        {
            this.Name = userName;
            this.AcctBal = balance;
        }


        public override void TransferFunds()
        {
            throw new NotImplementedException();
        }
    }
}
