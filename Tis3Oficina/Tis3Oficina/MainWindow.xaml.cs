﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tis3Oficina.src.Telas.Servicos;
using Tis3Oficina.src.Telas.CadastroCliente;
using Tis3Oficina.src.Telas.Pecas;
using Tis3Oficina.src.Telas.Orcamentos;

namespace Tis3Oficina
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCliente(object sender, RoutedEventArgs e)
        {
            // var telaCadastroCliente = new CadastroCliente();
            
            var telaListarClientes = new ListarClientes();
            this.Close();
            telaListarClientes.Show();

        }

        private void btnServico(object sender, RoutedEventArgs e)
        {
            var telaListarServico = new ListarServico();
            this.Close();
            telaListarServico.Show();

        }

        private void btnPeca(object sender, RoutedEventArgs e)
        {
            var telaListarPeca = new ListarPecas();
            this.Close();
            telaListarPeca.Show();
        }

        private void btnOrcamento(object sender, RoutedEventArgs e)
        {
            var telaOrcamento = new CriarOrcamento();
            this.Close();
            telaOrcamento.Show();
        }

    }
}
