﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
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
        public ObservableCollection<ItemOrcamento> itensOrcamento;
        
        public Double TotalOrcamento
        {
            get;
            set;
        }
      
        List<Peca> pecas;
        List<Servico> servicos;
        List<Cliente> clientes;
        public CriarOrcamento()
        {
            InitializeComponent();
            conexao.conectar();
            carregarComboBox();

            ItensOrcamento = new ObservableCollection<ItemOrcamento>();
            this.DataContext = itensOrcamento;
        }

        

        public void carregarComboBox()
        {
            DAOPeca daoPeca = new DAOPeca();
            DAOServico daoServico = new DAOServico();
            DAOCliente daoCliente = new DAOCliente();
            pecas = daoPeca.getTodos();
            servicos = daoServico.getTodos();
            clientes = daoCliente.geTodos();

            comboItemPecas.ItemsSource = pecas;
            comboItemServicos.ItemsSource = servicos;
            comboItemClientes.ItemsSource = clientes;


        }

        private void adicionarPeca(object sender, RoutedEventArgs e)
        {
            
            Peca peca = (Peca)comboItemPecas.SelectedItem;
        
            ItemOrcamento item = new ItemOrcamento();
            int quantidade = (int) qtdePeca.Value;
            item.IdPeca =  peca.CodPec;
            item.Nome = peca.NomePec;
            item.Valor = peca.ValPec;
            item.Quantidade = quantidade;
            ItensOrcamento.Add(item);
            
            GridItensOrcamento.ItemsSource = ItensOrcamento;
        }
        private void adicionarServico(object sender, RoutedEventArgs e)
        {
            Servico servico = (Servico)comboItemServicos.SelectedItem;

            ItemOrcamento item = new ItemOrcamento();
          
            double valServ = double.Parse(valorServico.Text.Replace("$", "").Replace(",", ""), CultureInfo.InvariantCulture);
            item.IdPeca = servico.Id;
            item.Nome = servico.NomeServico;
            item.Quantidade = 1;
            if(valServ != 0)
            {
                item.Valor = valServ;
            }
            else
            {
                item.Valor = servico.Valor;
            }
            ItensOrcamento.Add(item);
            GridItensOrcamento.ItemsSource = ItensOrcamento;
        }
        private void validaValor(object sender, RoutedEventArgs e)
        {
            bool result = isValue(valorServico.Text);

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

        public ObservableCollection<ItemOrcamento> ItensOrcamento { get => itensOrcamento; set => itensOrcamento = value; }

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
