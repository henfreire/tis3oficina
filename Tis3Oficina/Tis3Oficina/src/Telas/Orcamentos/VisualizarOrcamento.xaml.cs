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
    /// Lógica interna para VisualizarOrcamento.xaml
    /// </summary>
    public partial class VisualizarOrcamento : Window
    {
        private string codOrc;
        public VisualizarOrcamento(string codOrc)
        {
            this.codOrc = codOrc;
            InitializeComponent();
            this.carregarDados();
            
        }


        public void carregarDados()
        {
            DAOOrcamento nome = new DAOOrcamento();
            lblNome.Content = nome.getNomeCliente(codOrc);
            DAOItemOrcamento daoItemOrc = new DAOItemOrcamento();
            List<ItemOrcamento> listaOrc = daoItemOrc.getTodosByID(codOrc);
            dataGrid1.ItemsSource = listaOrc;
        }

        private void btnVoltar(object sender, RoutedEventArgs e)
        {
            var listar = new ListarOrcamento();
            this.Close();
            listar.Show();
        }
    }
}
