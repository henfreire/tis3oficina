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

        //Botao Deletar
        private void btnDeletar(object sender, RoutedEventArgs e)
        {
            var alerta = new Alerta(1);
            alerta.conteudo.Content = "Tem certeza que deseja deletar?";
            alerta.ShowDialog();

            if (alerta.yes)
            {
                Servico sl = dataGrid1.SelectedItem as Servico;
                DAOServico delete = new DAOServico();
                delete.deletar(sl.Id);
                List<Servico> c = delete.getTodos();
                dataGrid1.ItemsSource = c;
            }
        }

        private void btnEditar(object sender, RoutedEventArgs e)
        {
            Servico sl = dataGrid1.SelectedItem as Servico;
            var editarServico = new EditarServico(sl.Id);
            this.Close();
            editarServico.Show();
        }
    }
}
