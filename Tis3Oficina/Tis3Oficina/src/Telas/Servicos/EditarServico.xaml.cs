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

namespace Tis3Oficina.src.Telas.Servicos
{
    /// <summary>
    /// Lógica interna para EditarServico.xaml
    /// </summary>
    public partial class EditarServico : Window
    {
        private string id;
        public EditarServico(string id)
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
                String sql = "SELECT * FROM servico";
                MySqlCommand cmd = new MySqlCommand(sql, conexao.getInstancia());
                bool achou = false;
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read() && !achou)
                    {
                        if (id == dr["id"].ToString())
                        {
                            achou = true;
                            textNomeServico.Text = (String)dr["NomeServico"];
                            textValor.Text = (String)dr["Valor"];
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
            Servico novoServico = new Servico();

            novoServico.NomeServico = textNomeServico.Text;
            novoServico.Valor = textValor.Text.Replace("_", "");

            DAOServico servico = new DAOServico();
            servico.editar(novoServico, id);
            var alerta = new Alerta();
            alerta.conteudo.Content = "Serviço editado com sucesso";
            alerta.ShowDialog();


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
