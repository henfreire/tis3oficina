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

namespace Tis3Oficina.src.Telas.Orcamento
{
    /// <summary>
    /// Lógica interna para CriarOrcamento.xaml
    /// </summary>
    public partial class CriarOrcamento : Window
    {
        Conexao conexao = new Conexao();
        public CriarOrcamento()
        {
            InitializeComponent();
            conexao.conectar();
            carregarComboBox();
        }

        public void carregarComboBox()
        {
            DataTable dt = new DataTable();
            try
            {
                // Query mysql
                String sql = "SELECT NomePec FROM pecas";
                MySqlCommand cmd = new MySqlCommand(sql, conexao.getInstancia());


                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = (String)dr["NomePec"];

                        comboItem.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro buscar todos Clientes : " + ex.Message, "Erro");
            }
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

            Console.WriteLine(comboItem.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last().Replace(" ",""));
            
            switch (comboItem.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
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
        }
    }
}
