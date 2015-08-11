﻿using Modelo;
using QBFC13Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAInvoice
    {

        private SessionQB session;
        private IMsgSetRequest request;
        private QBSessionManager sessionManager;
        private IInvoiceQuery invoiceQuery;

        public DAInvoice()
        {

            session = new SessionQB();
            invoiceQuery = null;
        }

        public List<Invoice> getListInvoice()
        {
            List<Invoice> completeList = new List<Invoice>();
            prepareQuery();
            IResponse respuesta = executeQuery();
            readData(completeList, respuesta);
            return completeList;

        }

        public List<Invoice> getListInvoiceDate(DateTime fechaInicio, DateTime fechaTermino)
        {
            List<Invoice> completeList = new List<Invoice>();
            prepareQuery();
            setFilter(fechaInicio, fechaTermino);
            IResponse respuesta = executeQuery();
            readData(completeList, respuesta);
            return completeList;

        }

        public Invoice getElement(string numInvoice)
        {
            List<Invoice> completeList = new List<Invoice>();
            prepareQuery();
            setFilter(numInvoice);
            IResponse respuesta = executeQuery();
            readData(completeList, respuesta);
            if (completeList.Count >= 1)
                return completeList[0];

            return null;
        }

        private void setFilter(string numInvoice)
        {
            invoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
            invoiceQuery.ORInvoiceQuery.InvoiceFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(numInvoice);
        }
        private void setFilter(DateTime fechaInicio, DateTime fechaTermino)
        {
            invoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(fechaInicio);
            invoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(fechaTermino);
        }


        private void prepareQuery()
        {
            session.open();
            request = session.getRequest();
            sessionManager = session.getSession();
            invoiceQuery = request.AppendInvoiceQueryRq();
            invoiceQuery.IncludeLineItems.SetValue(true);
        }
        private IResponse executeQuery()
        {
            IMsgSetResponse respuestaMsg = sessionManager.DoRequests(request);
            IResponse respuesta = respuestaMsg.ResponseList.GetAt(0);
            session.close();
            return respuesta;
        }
        private void readData(List<Invoice> completeList, IResponse respuesta)
        {
            if (respuesta.StatusCode == 0)
            {
                IInvoiceRetList invoiceRetList = (IInvoiceRetList)respuesta.Detail;
                for (int i = 0; i < invoiceRetList.Count; i++)
                {
                    Invoice invoice = readInvoice(invoiceRetList.GetAt(i));
                    completeList.Add(invoice);
                }
            }
        }

        private Invoice readInvoice(IInvoiceRet invoiceLineRet)
        {
            Invoice invoice = new Invoice();
            invoice.DATE = invoiceLineRet.TxnDate.GetValue();
            invoice.REFNUMBER = invoiceLineRet.RefNumber.GetValue();
            invoice.AMOUNT = invoiceLineRet.AppliedAmount.GetValue();
            invoice.MEMO = invoiceLineRet.Memo.GetValue();
            return invoice;
        }
    }
}
