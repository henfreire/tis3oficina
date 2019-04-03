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
using Tis3Oficina.src.OBJETOS;

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
            List<Cliente> c = daoC.getTodos();
            dataGrid1.ItemsSource = c;

           
            
           
          

        }

        //Botao Voltar
        private void btnVoltar(object sender, RoutedEventArgs e)
        {
            var menu = new MainWindow();
            this.Close();
            menu.Show();
        }

        //Botao Criar novo Cliente
        private void btnNovoCliente(object sender, RoutedEventArgs e)
        {
            var Cadastro = new CadastroCliente();
            this.Close();
            Cadastro.Show();
        }
    }
}
