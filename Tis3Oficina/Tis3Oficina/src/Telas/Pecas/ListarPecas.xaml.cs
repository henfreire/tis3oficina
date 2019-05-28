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

        //Botao Deletar
        private void btnDeletar(object sender, RoutedEventArgs e)
        {
            var alerta = new Alerta(1);
            alerta.conteudo.Content = "Tem certeza que deseja deletar?";
            alerta.ShowDialog();

            if (alerta.yes)
            {
                Peca pl = dataGrid1.SelectedItem as Peca;
                DAOPeca delete = new DAOPeca();
                delete.deletar(pl.CodPec);
                List<Peca> c = delete.getTodos();
                dataGrid1.ItemsSource = c;
            }
        }

        private void btnEditar(object sender, RoutedEventArgs e)
        {
            Peca pl = dataGrid1.SelectedItem as Peca;
            var editarPeca = new EditarPeca(pl.CodPec);
            this.Close();
            editarPeca.Show();
        }
    }
}
