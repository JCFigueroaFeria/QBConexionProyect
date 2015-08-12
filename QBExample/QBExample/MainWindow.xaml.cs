using Controller;
using MahApps.Metro.Controls;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QBExample
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        List<Invoice> ultimaLista;
        ControllerPayInvoice cargarInvoice;
        public MainWindow()
        {
            InitializeComponent();
            cargarInvoice = new ControllerPayInvoice();
            dpFechaInicio.SelectedDate = dpFechaTermino.SelectedDate = DateTime.Now;
        }

        private void btnCargarTabla_Click(object sender, RoutedEventArgs e)
        {
            cargarDatosDePagos();
        }


        public void cargarTablaPorReferencia()
        {
            List<Invoice> listInvoice = new List<Invoice>();
            Invoice rBill = cargarInvoice.cargarInvoiceNumReferent(txtRefNumber.Text);
            listInvoice.Add(rBill);
            ultimaLista = listInvoice;
        }

        private void cargarDatosDePagos()
        {
            List<Invoice> iNvoice = cargarInvoice.cargarPagosInvoiceFecha((DateTime)dpFechaInicio.SelectedDate, (DateTime)dpFechaTermino.SelectedDate);
            this.tblInvoice.ItemsSource = iNvoice;
            ultimaLista = iNvoice;
        }

        private void btnFacturados_Click(object sender, RoutedEventArgs e)
        {
            List<Invoice> tem = new List<Invoice>();
            for (int i = 0; i < ultimaLista.Count; i++)
            {
                if (ultimaLista[i].PAID == true)
                {
                    tem.Add(ultimaLista[i]);
                }
            }
            this.tblInvoice.ItemsSource = tem;
        }


        private void btnNoFacturaos_Click_1(object sender, RoutedEventArgs e)
        {
            List<Invoice> tem = new List<Invoice>();
            for (int i = 0; i < ultimaLista.Count; i++)
            {
                if (ultimaLista[i].PAID == false)
                {
                    tem.Add(ultimaLista[i]);
                }
            }
            this.tblInvoice.ItemsSource = tem;
        }
    }
}
