using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    internal class Account
    {
        public int Number { get; set; }
        public int BranchNumber { get; set; }
        public String BankCode { get; set; }
        public String Type { get; set; }
        public double Balance { get; set; }
    }
}
