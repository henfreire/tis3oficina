using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica interna para CadastroPeca.xaml
    /// </summary>
    public partial class CadastroPeca : Window
    {
        public CadastroPeca()
        {
            InitializeComponent();
        }

        private void btnSalvar(object sender, RoutedEventArgs e)
        {
            Peca novaPeca = new Peca();
            string nome = textNomePec.Text.Trim();
            string quantidade = textQtdePec.Text;
            string valor = textValorPec.Text.Replace("_", "");

            novaPeca.NomePec = nome;
            novaPeca.QtdePeca = quantidade;
            novaPeca.ValPec = valor;

            DAOPeca peca = new DAOPeca();
            peca.inserir(novaPeca);
            var alerta = new Alerta();
            alerta.conteudo.Content = "Peça cadastrada com sucesso";
            alerta.ShowDialog();
            var telaListarPeca = new ListarPecas();
            this.Close();
            telaListarPeca.Show();
        }


    

    //Validando entrada de nome para somente caracteres
    private void validateNome(object sender, TextCompositionEventArgs e)
    {
        e.Handled = new Regex("[^a-zA-Z]+").IsMatch(e.Text);
    }

    //Verificar se esta digitando numero ao invés de letra
    private void validateNumber(object sender, TextCompositionEventArgs e)
    {
        e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
    }

        private void btnVoltar(object sender, RoutedEventArgs e)
        {
            var telaListarPeca = new ListarPecas();
            this.Close();
            telaListarPeca.Show();
        }
    }
}

