﻿using MySql.Data.MySqlClient;
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

namespace Tis3Oficina.src.Telas.CadastroCliente
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
                            if (((String)dr["Cpf"]).Length == 11)
                                textCpf.Text = (String)dr["Cpf"];
                            else
                            {
                                radioCNPJ.IsChecked = true;
                                textCNPJ.Text = (String)dr["Cpf"];
                            }
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
            string nome = textNome.Text.Trim();
            string email = textEmail.Text;
            string cpf = textCpf.Text.Replace(".", "").Replace("-", "").Replace("_", "");
            string telefone = textTelefone.Text.Replace("_", "").Replace("(", "").Replace(")", "").Replace("-", "");
            string endereco = textEndereco.Text;
            string obs = textObservacao.Text;

            //Usado o método Convert.ToBoolean pois o WPF o metodo IsChecked é "bool?"
            //Verificando qual radioButton está selecionado para definir o CPF ou CNPJ
            if (Convert.ToBoolean(radioCPF.IsChecked))
            {
                if (isName(nome) && IsValidTel(telefone) && IsValidEmailAddress(email) && IsCpf(cpf))
                {
                    novoCliente.Nome = nome;
                    novoCliente.Email = email;
                    novoCliente.Cpf = cpf;
                    novoCliente.Telefone = telefone;
                    novoCliente.Endereco = endereco;
                    novoCliente.Observacao = obs;

                    DAOCliente cliente = new DAOCliente();
                    cliente.editar(novoCliente,id);
                    var alerta = new Alerta();
                    alerta.conteudo.Content = "Cliente editado com sucesso";
                    alerta.ShowDialog();
                    var telaListarClientes = new ListarClientes();
                    this.Close();
                    telaListarClientes.Show();

                }
                else
                {
                    var alerta = new Alerta();
                    alerta.conteudo.Content = "Preencha os campos corretamente!";
                    alerta.ShowDialog();
                }
            }
            else
            {
                if (isName(nome) && IsValidTel(telefone) && IsValidEmailAddress(email) && IsCnpj(textCNPJ.Text.Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", "")))
                {
                    novoCliente.Nome = nome;
                    novoCliente.Email = email;
                    novoCliente.Cpf = textCNPJ.Text.Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", "");
                    novoCliente.Telefone = telefone;
                    novoCliente.Endereco = endereco;
                    novoCliente.Observacao = obs;

                    DAOCliente cliente = new DAOCliente();
                    cliente.editar(novoCliente, id);
                    var alerta = new Alerta();
                    alerta.conteudo.Content = "Cliente editado com sucesso";
                    alerta.ShowDialog();
                    var telaListarClientes = new ListarClientes();
                    this.Close();
                    telaListarClientes.Show();

                }
                else
                {
                    var alerta = new Alerta();
                    alerta.conteudo.Content = "Preencha os campos corretamente!";
                    alerta.ShowDialog();
                }
            }


        }
        //


        //Botao Voltar
        private void btnVoltar(object sender, RoutedEventArgs e)
        {
            var telaListarClientes = new ListarClientes();
            this.Close();
            telaListarClientes.Show();
        }

        //Mostra messagem de erro para usuario caso nome esteja incorreto
        private void validaNome(object sender, RoutedEventArgs e)
        {
            bool result = isName(textNome.Text);

            if (!result)
                lblNomeIncorreto.Visibility = Visibility.Visible;

            else
                lblNomeIncorreto.Visibility = Visibility.Hidden;
        }

        //Mostra messagem de erro para usuario caso email esteja incorreto
        private void validaEmail(object sender, RoutedEventArgs e)
        {
            bool result = IsValidEmailAddress(textEmail.Text);

            if (!result)
                lblEmailIncorreto.Visibility = Visibility.Visible;
            else
                lblEmailIncorreto.Visibility = Visibility.Hidden;
        }

        //Mostra messagem de erro para usuario caso CPF esteja incorreto
        private void verificaCPF(object sender, RoutedEventArgs e)
        {
            bool result = IsCpf(textCpf.Text.Replace(".", "").Replace("-", "").Replace("_", ""));

            if (!result)
                lblCPFIncorreto.Visibility = Visibility.Visible;
            else
                lblCPFIncorreto.Visibility = Visibility.Hidden;
        }

        //Mostra messagem de erro para usuario caso CNPJ esteja incorreto
        private void verificaCNPJ(object sender, RoutedEventArgs e)
        {
            bool result = IsCnpj(textCNPJ.Text.Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", ""));

            if (!result)
                lblCNPJIncorreto.Visibility = Visibility.Visible;
            else
                lblCNPJIncorreto.Visibility = Visibility.Hidden;
        }

        //Mostra messagem de erro para usuario caso CNPJ esteja incorreto
        private void verificaTel(object sender, RoutedEventArgs e)
        {
            bool result = IsValidTel(textTelefone.Text.Replace("_", "").Replace("(", "").Replace(")", "").Replace("-", ""));

            if (!result)
                lblTelIncorreto.Visibility = Visibility.Visible;
            else
                lblTelIncorreto.Visibility = Visibility.Hidden;
        }

        //Validando entrada de nome para somente caracteres
        private void validateNome(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-zA-Z]+").IsMatch(e.Text);
        }

        //Verificar se esta digitando numero ao invés de letra
        private void validateCPFTel(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        public static bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        public static bool IsValidTel(string tel)
        {
            Regex regex = new Regex("[^0-9]+");
            if (tel.Length < 11 || tel == "" || regex.IsMatch(tel))
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
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        private void RadioCNPJ_Click(object sender, RoutedEventArgs e)
        {
            lblCPFIncorreto.Visibility = Visibility.Hidden;
        }

        private void RadioCPF_Click(object sender, RoutedEventArgs e)
        {
            lblCNPJIncorreto.Visibility = Visibility.Hidden;
        }
    }
}
