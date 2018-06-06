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
        public Saving(string userName)
        {
            this.Name = userName;
        }
    }
}
