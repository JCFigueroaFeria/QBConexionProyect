using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{

    public class Invoice
    {

        private DateTime date;
        private string refNumber;
        private string item;
        private double amount;
        private string memo;
        private bool paid;

        public Invoice()
        {
            refNumber = "";
            item = "";
            amount = 0d;
            memo = "";
            paid = false;
        }

        public DateTime DATE { get { return date; } set { date = value; } }
        public string REFNUMBER { get { return refNumber; } set { refNumber = value; } }
        public string ITEM { get { return item; } set { item = value; } }
        public double AMOUNT { get { return amount; } set { amount = value; } }
        public string MEMO { get { return memo; } set { memo = value; } }
        public bool PAID { get { return paid; } set { paid = value; } }

    }
}