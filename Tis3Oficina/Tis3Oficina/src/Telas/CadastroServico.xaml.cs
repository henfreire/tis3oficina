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

namespace Tis3Oficina.src.Telas
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

            novoServico.NomeServico = textNomeServico.Text;
            novoServico.Valor = textValor.Text;

            DAOServico servico = new DAOServico();
            servico.inserir(novoServico);
            System.Windows.Forms.MessageBox.Show("Servico Salvo");
            

            var telaListaServico = new ListarServico();
            this.Close();
            telaListaServico.Show();
        }

        //Botao Voltar
        private void btnVoltar(object sender, RoutedEventArgs e)
        {
            var telaListarServico = new ListarServico();
            this.Close();
            telaListarServico.Show();
        }

        //Verificar se é so numero no telefone
        private void txtValorEntrada(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
