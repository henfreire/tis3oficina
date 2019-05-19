using MySql.Data.MySqlClient;
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
using Tis3Oficina.src.Config;
using Tis3Oficina.src.DAO;
using Tis3Oficina.src.OBJETOS;

namespace Tis3Oficina.src.Telas.Orcamento
{
    /// <summary>
    /// Lógica interna para CriarOrcamento.xaml
    /// </summary>
    public partial class CriarOrcamento : Window
    {
        Conexao conexao = new Conexao();
        List<ItemOrcamento> itensOrcamento;
        List<Peca> pecas;
        List<Servico> servicos;
        public CriarOrcamento()
        {
            InitializeComponent();
            conexao.conectar();
            carregarComboBox();
            itensOrcamento = new List<ItemOrcamento>();
        }

        public void carregarComboBox()
        {
            DAOPeca daoPeca = new DAOPeca();
            DAOServico daoServico = new DAOServico();
            pecas = daoPeca.getTodos();
            servicos = daoServico.getTodos();
            
            comboItemPecas.ItemsSource = pecas;
            comboItemServicos.ItemsSource = servicos;
         
        }

        private void adicionarPeca(object sender, RoutedEventArgs e)
        {
            
            Peca peca = (Peca)comboItemPecas.SelectedItem;
        
            ItemOrcamento item = new ItemOrcamento();
            item.IdPeca =  peca.CodPec;
            item.Nome = peca.NomePec;
            item.Valor = peca.ValPec;
            item.Quantidade = peca.QtdePeca;
            Console.WriteLine(item);
            itensOrcamento.Add(item);
            GridItensOrcamento.ItemsSource = itensOrcamento;
        }
        private void adicionarServico(object sender, RoutedEventArgs e)
        {
            Servico servico = (Servico)comboItemServicos.SelectedItem;

            ItemOrcamento item = new ItemOrcamento();
            item.IdPeca = servico.Id;
            item.Nome = servico.NomeServico;
            item.Valor = servico.Valor;
            Console.WriteLine(item);
            itensOrcamento.Add(item);
            GridItensOrcamento.ItemsSource = itensOrcamento;
        }
        private void validaValor(object sender, RoutedEventArgs e)
        {
            bool result = isValue(textValor.Text);

            if (!result)
                lblValorIncorreto.Visibility = Visibility.Visible;
            else
                lblValorIncorreto.Visibility = Visibility.Hidden;
        }
        public static bool isValue(string valor)
        {
            if (valor == "$0.00")
                return false;

            return true;
        }
        //Botao Voltar
        private void btnVoltar(object sender, RoutedEventArgs e)
        {
            var principal = new MainWindow();
            this.Close();
            principal.Show();
        }

        private bool handle = true;
        private void Closes(object sender, EventArgs e)
        {
            if (handle) Handle();
            handle = true;
        }

        private void Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }

        private void Handle()
        {

           
           /* 
            switch (comboItemPecas.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "COla":
                    qtdeInt.Maximum = 10;
                    break;
                case "2":
                    //Handle for the second combobox
                    break;
                case "3":
                    //Handle for the third combobox
                    break;
            }
            */
        }
    }
}
