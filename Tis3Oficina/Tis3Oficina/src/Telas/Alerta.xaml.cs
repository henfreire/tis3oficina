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
        public Alerta()
        {
            InitializeComponent();
        }

        private void btnOk(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
