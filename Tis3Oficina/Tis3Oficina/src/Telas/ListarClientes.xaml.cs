using System;
using System.Collections.Generic;
using System.Data;
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
using Tis3Oficina.src.DAO;

namespace Tis3Oficina.src.Telas
{
    /// <summary>
    /// Lógica interna para ListarCliente.xaml
    /// </summary>
    public partial class ListarClientes : Window
    {
        public ListarClientes()
        {
            InitializeComponent();
            this.carregarDados();


        }

      
        public void carregarDados()
        {
            
          DAOCliente daoC = new DAOCliente();
            DataTable result = daoC.listarTodos();
            dataGrid1.ItemsSource = result.DefaultView;

        }
    }
}
