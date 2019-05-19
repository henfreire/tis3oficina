using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Tis3Oficina.src.Telas.Servicos
{
    /// <summary>
    /// Lógica interna para CadastroServico.xaml
    /// </summary>
    public partial class CadastroServico : Window
    {
        public CadastroServico()
        {
            InitializeComponent();
        }

        // Botao de salvar serviço
        private void btnSalvar(object sender, RoutedEventArgs e)
        {
            Servico novoServico = new Servico();

            if (isName(textNomeServico.Text) && isValue(textValor.Text))
            {
                novoServico.NomeServico = textNomeServico.Text;
                novoServico.Valor = double.Parse(textValor.Text.Replace("$", "").Replace(",", ""), CultureInfo.InvariantCulture);

                DAOServico servico = new DAOServico();
                servico.inserir(novoServico);
                var alerta = new Alerta();
                alerta.conteudo.Content = "Serviço criado com sucesso";
                alerta.ShowDialog();


                var telaListaServico = new ListarServico();
                this.Close();
                telaListaServico.Show();
            }
            else
            {
                if (!isName(textNomeServico.Text))
                    lblNomeIncorreto.Visibility = Visibility.Visible;
                if (!isValue(textValor.Text))
                    lblValorIncorreto.Visibility = Visibility.Visible;

                var alerta = new Alerta();
                alerta.conteudo.Content = "Preencha os campos corretamente!";
                alerta.ShowDialog();
            }
        }

        //Botao Voltar
        private void btnVoltar(object sender, RoutedEventArgs e)
        {
            var telaListarServico = new ListarServico();
            this.Close();
            telaListarServico.Show();
        }

        //Validando entrada de nome para somente caracteres
        private void validateNome(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-zA-Z]+").IsMatch(e.Text);
        }

        //Mostra messagem de erro para usuario caso nome esteja incorreto
        private void validaNome(object sender, RoutedEventArgs e)
        {
            bool result = isName(textNomeServico.Text);

            if (!result)
                lblNomeIncorreto.Visibility = Visibility.Visible;

            else
                lblNomeIncorreto.Visibility = Visibility.Hidden;
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

        public static bool isName(string name)
        {
            Regex regex = new Regex(
              "^(\\b[A-Za-z]*\\b\\s+\\b[A-Za-z]*\\b+\\.[A-Za-z])$",
            RegexOptions.IgnoreCase
            | RegexOptions.CultureInvariant
            | RegexOptions.IgnorePatternWhitespace
            | RegexOptions.Compiled
            );
            name = name.Trim();
            if (name.Length < 3 || name == "" || regex.IsMatch(name))
                return false;

            return true;
        }
    }
}
