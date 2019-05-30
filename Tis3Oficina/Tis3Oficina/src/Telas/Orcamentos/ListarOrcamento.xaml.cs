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

namespace Tis3Oficina.src.Telas.Orcamentos
{
    /// <summary>
    /// Lógica interna para ListarOrcamento.xaml
    /// </summary>
    public partial class ListarOrcamento : Window
    {
        public ListarOrcamento()
        {
            InitializeComponent();
            this.carregarDados();
        }


        public void carregarDados()
        {

            DAOOrcamento daoOrc = new DAOOrcamento();
            List<Orcamento> listaOrc = daoOrc.getTodos();
            dataGrid1.ItemsSource = listaOrc;
        }

        private void btnVoltar(object sender, RoutedEventArgs e)
        {
            var telaOrcamento = new CriarOrcamento();
            this.Close();
            telaOrcamento.Show();

        }

        private void btnVisualizar(object sender, RoutedEventArgs e)
        {
            Orcamento cl = dataGrid1.SelectedItem as Orcamento;
            var visuCliente = new VisualizarOrcamento(cl.CodOrc);
            this.Close();
            visuCliente.Show();
        }
    }
}
