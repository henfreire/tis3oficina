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
using System.Windows.Shapes;

namespace Tis3Oficina.src.Telas
{
    /// <summary>
    /// Lógica interna para Alerta.xaml
    /// </summary>
    public partial class Alerta : Window
    {
        public bool yes=false;
        public bool no=false;
        public Alerta()
        {
            InitializeComponent();
        }

        public Alerta(int tipo)
        {
            InitializeComponent();
            if (tipo == 1)
                alteraBox();
        }

        private void alteraBox()
        {
            btnYes.Visibility = Visibility.Visible;
            btnNo.Visibility = Visibility.Visible;
            btnOK.Visibility = Visibility.Hidden;
        }

        private void btnOk(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSim(object sender, RoutedEventArgs e)
        {
            yes = true;
            this.Close();
        }

        private void btnNao(object sender, RoutedEventArgs e)
        {
            no = true;
            this.Close();
        }
    }
}
