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
using Tis3Oficina.src.DAO;
using Tis3Oficina.src.OBJETOS;

namespace Tis3Oficina.src.Telas.Pecas
{
    /// <summary>
    /// Lógica interna para ListarPecas.xaml
    /// </summary>
    public partial class ListarPecas : Window
    {
        public static string codPec = "";
        public ListarPecas()
        {
            InitializeComponent();
            this.carregarDados();
        }

        public void carregarDados()
        {

            DAOPeca daoP = new DAOPeca();
            List<Peca> p = daoP.getTodos();
            dataGrid1.ItemsSource = p;
        }


        //Botao Criar novo Servico
        private void btnCriarPeca(object sender, RoutedEventArgs e)
        {
            var peca = new CadastroPeca();
            this.Close();
            peca.Show();
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
                codPec = (dataGrid1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            }
            if (codPec != null)
            {
                BEdit.IsEnabled = true;
                BDelete.IsEnabled = true;
            }
        }

        //Botao Deletar
        private void btnDeletar(object sender, RoutedEventArgs e)
        {

            DAOPeca delete = new DAOPeca();
            delete.deletar(codPec);
            List<Peca> c = delete.getTodos();
            dataGrid1.ItemsSource = c;
            BEdit.IsEnabled = false;
            BDelete.IsEnabled = false;
        }

        private void btnEditar(object sender, RoutedEventArgs e)
        {
            var editarPeca = new EditarPeca(codPec);
            this.Close();
            editarPeca.Show();
        }
    }
}
