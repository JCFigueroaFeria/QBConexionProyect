using DataAccess;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ControllerPayInvoice
    {
        private DAInvoice daInvoice;
        public ControllerPayInvoice()
        {

            daInvoice = new DAInvoice();
        }

        public List<Invoice> cargarPagosInvoiceFecha(DateTime fechaInicio, DateTime fechaTermino)
        {
            return daInvoice.getListInvoiceDate(fechaInicio, fechaTermino);
        }

        public Invoice cargarInvoiceNumReferent(string numReferent)
        {
            return daInvoice.getElement(numReferent);
        }
    }
}
