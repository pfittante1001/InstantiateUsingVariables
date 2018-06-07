using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantiateUsingVariables
{
    class Customer 
    {
        //trying to create lists of objects
        List<Checking> checkAcct = new List<Checking>();
        List<Saving> savAcct = new List<Saving>();

        //Getting the objects is the list
        public List<Checking> GetCheckAccount()
        { 
            return checkAcct;
        }
        public List<Saving> GetSaveAccount()
        {
            return savAcct;
        }

        // This is the method you could add to support the Tell Dont Ask thing I mentioned:
        public void AddCheckingAccount(Checking acct)
        {
            checkAcct.Add(acct);
        }

        //check the checkAcct list object Name field against the user input and return that value
        public Checking GetChecking(string name)
        {
            
            return checkAcct.Where(x => x.Name == name).FirstOrDefault();
        }
        public Saving GetSaving(string name)
        {
            return savAcct.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
