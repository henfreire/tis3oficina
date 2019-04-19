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

namespace Tis3Oficina.src.Telas.Servicos
{
    /// <summary>
    /// Lógica interna para ListarServico.xaml
    /// </summary>
    public partial class ListarServico : Window
    {
        public static string id = "";

        public ListarServico()
        {
            InitializeComponent();
            this.carregarDados();
        }


        public void carregarDados()
        {

            DAOServico daoS = new DAOServico();
            List<Servico> s = daoS.getTodos();
            dataGrid1.ItemsSource = s;
        }


        //Botao Criar novo Servico
        private void btnCriarServico(object sender, RoutedEventArgs e)
        {
            var Servico = new CadastroServico();
            this.Close();
            Servico.Show();
        }

        //Botao Voltar
        private void btnVoltar(object sender, RoutedEventArgs e)
        {
            var menu = new MainWindow();
            this.Close();
            menu.Show();
        }

        private void DataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGrid1.Items.IndexOf(dataGrid1.CurrentItem) != -1)
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

        //Botao Deletar
        private void btnDeletar(object sender, RoutedEventArgs e)
        {

            DAOServico delete = new DAOServico();
            delete.deletar(id);
            List<Servico> c = delete.getTodos();
            dataGrid1.ItemsSource = c;
            BEdit.IsEnabled = false;
            BDelete.IsEnabled = false;
        }

        private void btnEditar(object sender, RoutedEventArgs e)
        {
            var editarServico = new EditarServico(id);
            this.Close();
            editarServico.Show();
        }
    }
}
