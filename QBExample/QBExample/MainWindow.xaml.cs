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
        public MainWindow()
        {
            InitializeComponent();
            dpFechaInicio.SelectedDate = dpFechaTermino.SelectedDate = DateTime.Now;
        }

        private void btnCargarTabla_Click(object sender, RoutedEventArgs e)
        {
            cargarDatosDePagosFecha();
        }



        public void cargarDatosTablaPorReferencia() {
            ControllerPayInvoice cargarInvoice = new ControllerPayInvoice();
            Invoice rInvoice = cargarInvoice.cargarInvoice(this.txtRefNumber.Text);
            List<Invoice> lista = new List<Invoice>();
            lista.Add(rInvoice);
            this.tblInvoice.ItemsSource = lista;
        
        }

        private void cargarDatosDePagosFecha()
        {
            ControllerPayInvoice cargarInvoice = new ControllerPayInvoice();
            this.tblInvoice.ItemsSource = cargarInvoice.cargarPagosInvoice((DateTime)dpFechaInicio.SelectedDate, (DateTime)dpFechaTermino.SelectedDate);
        }
    }
}
