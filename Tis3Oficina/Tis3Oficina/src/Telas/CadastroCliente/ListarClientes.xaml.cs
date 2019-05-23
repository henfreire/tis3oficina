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
        public static string id="";

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

        //Botao Editar
        private void btnEditar(object sender, RoutedEventArgs e)
        {
            
            var editarCliente = new EditarCliente(id);
            this.Close();
            editarCliente.Show();

        }

        //Botao Deletar
        private void btnDeletar(object sender, RoutedEventArgs e)
        {

            DAOCliente delete = new DAOCliente();
            delete.deletar(id);
            DataTable result = delete.listarTodos();
            List<Cliente> c = delete.getTodos();
            dataGrid1.ItemsSource = c;
            dataGrid1.Columns[1].Visibility = Visibility.Collapsed;
            BEdit.IsEnabled = false;
            BDelete.IsEnabled = false;
        }

        //Botao Criar novo Cliente
        private void btnNovoCliente(object sender, RoutedEventArgs e)
        {
            var Cadastro = new CadastroCliente();
            this.Close();
            Cadastro.Show();
        }

        private void DataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dataGrid1.Items.IndexOf(dataGrid1.CurrentItem) != -1)
            {
                object item = dataGrid1.SelectedItem;
                id = (dataGrid1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            }
            if (id != null)
            {
                BEdit.IsEnabled = true;
                BDelete.IsEnabled = true;
            }
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
                DataTable result = delete.listarTodos();
                List<Cliente> c = delete.getTodos();
                dataGrid1.ItemsSource = c;
            }
        }
    }
}
