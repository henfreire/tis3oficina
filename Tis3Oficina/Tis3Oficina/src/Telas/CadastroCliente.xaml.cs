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
using Tis3Oficina.src.Config;
using Tis3Oficina.src.DAO;
using Tis3Oficina.src.OBJETOS;

namespace Tis3Oficina.src.Telas
{
    /// <summary>
    /// Lógica interna para CadastroCliente.xaml
    /// </summary>
    public partial class CadastroCliente : Window
    {
        public CadastroCliente()
        {
            InitializeComponent();
           
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cliente gravaCliente = new Cliente();

            gravaCliente.Nome = txt_tela_nome.Text;
            gravaCliente.Cpf = txtCpf.Text;
            gravaCliente.Telefone = txt_tela_telefone.Text;
            gravaCliente.Email = txtEmail.Text;
            gravaCliente.Endereco = textEndereco.Text;
            gravaCliente.Observacao = textObservacao.Text;




            DAOCliente cliente = new DAOCliente();
            cliente.inserir(gravaCliente);
            System.Windows.Forms.MessageBox.Show("Cliente Salvo");
            var menu = new MainWindow();
            this.Close();
            menu.Show();

        }
        //
       

        

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
