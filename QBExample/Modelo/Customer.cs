using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Customer
    {
        private string CompanyName;
        private string JobName;
        private string BillTo;
        public Customer() {

            CompanyName = "";
            JobName = "";
            BillTo = "";
        }

        public string COMPANYNAME { get { return CompanyName; } set { CompanyName = value; } }
        public string JOBNAME { get { return JobName; } set { JobName = value; } }
        public string BILLTO { get { return BillTo; } set { BillTo = value; } }
    }
}
