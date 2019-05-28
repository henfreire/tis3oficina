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

namespace Tis3Oficina.src.Telas.CadastroCliente
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

        private void btnEdit(object sender, RoutedEventArgs e)
        {
            Cliente cl = dataGrid1.SelectedItem as Cliente;
            var editarCliente = new EditarCliente(cl.Id);
            this.Close();
            editarCliente.Show();
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            var alerta = new Alerta(1);
            alerta.conteudo.Content = "Tem certeza que deseja deletar?";
            alerta.ShowDialog();
            
            if (alerta.yes)
            {
                Cliente cl = dataGrid1.SelectedItem as Cliente;
                DAOCliente delete = new DAOCliente();
                delete.deletar(cl.Id);
                List<Cliente> c = delete.getTodos();
                dataGrid1.ItemsSource = c;
            }
        }
    }
}
