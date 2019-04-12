using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using Tis3Oficina.src.Config;
using Tis3Oficina.src.DAO;
using Tis3Oficina.src.OBJETOS;

namespace Tis3Oficina.src.Telas
{
    /// <summary>
    /// Lógica interna para EditarCliente.xaml
    /// </summary>
    public partial class EditarCliente : Window
    {
        private string id;
        public EditarCliente(string id)
        {
            this.id = id;
            InitializeComponent();
            exibeDados();
        }

        private void exibeDados()
        {
            Conexao conexao = new Conexao();
            DataTable dt = new DataTable();
            try
            {
                // Query mysql
                String sql = "SELECT * FROM cliente";
                MySqlCommand cmd = new MySqlCommand(sql, conexao.getInstancia());
                bool achou = false;
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read() && !achou)
                    {
                        if (id == dr["id"].ToString())
                        {
                            achou = true;
                            textNome.Text = (String)dr["Nome"];
                            textCpf.Text = (String)dr["Cpf"];
                            textTelefone.Text = (String)dr["Telefone"];
                            textEmail.Text = (String)dr["Email"];
                            textEndereco.Text = (String)dr["Endereco"];
                            textObservacao.Text = (String)dr["Observacao"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro buscar todos Clientes : " + ex.Message, "Erro");
            }
        }


        private void btnSalvar(object sender, RoutedEventArgs e)
        {
            Cliente novoCliente = new Cliente();

            novoCliente.Nome = textNome.Text;
            novoCliente.Cpf = textCpf.Text;
            novoCliente.Telefone = textTelefone.Text;
            novoCliente.Email = textEmail.Text;
            novoCliente.Endereco = textEndereco.Text;
            novoCliente.Observacao = textObservacao.Text;

            DAOCliente cliente = new DAOCliente();
            cliente.editar(novoCliente, id);
            System.Windows.Forms.MessageBox.Show("Cliente Salvo");
            var menu = new MainWindow();
            this.Close();

            var telaListarClientes = new ListarClientes();
            telaListarClientes.Show();
        }



        //Botao Voltar
        private void btnVoltar(object sender, RoutedEventArgs e)
        {
            var telaListarClientes = new ListarClientes();
            this.Close();
            telaListarClientes.Show();
        }

        //Verificar se esta digitando letra ao invés de numero no CPF
        private void TxtCpf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        //Verificação do email
        private void TxtEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").IsMatch(e.Text);
        }

        //Verificar se é so numero no telefone
        private void Txt_tela_telefone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void Txt_tela_nome_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-zA-Z]+").IsMatch(e.Text);
        }
    }
}
