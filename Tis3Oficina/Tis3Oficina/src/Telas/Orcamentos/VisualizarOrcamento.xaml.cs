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
using Tis3Oficina.src.DAO;
using Tis3Oficina.src.OBJETOS;

namespace Tis3Oficina.src.Telas.Orcamentos
{
    /// <summary>
    /// Lógica interna para VisualizarOrcamento.xaml
    /// </summary>
    public partial class VisualizarOrcamento : Window
    {
        private string codOrc;
        public VisualizarOrcamento(string codOrc)
        {
            this.codOrc = codOrc;
            InitializeComponent();
            this.carregarDados();
            
        }


        public void carregarDados()
        {
            DAOOrcamento nome = new DAOOrcamento();
            lblNome.Content = nome.getNomeCliente(codOrc);
            DAOItemOrcamento daoItemOrc = new DAOItemOrcamento();
            List<ItemOrcamento> listaOrc = daoItemOrc.getTodosByID(codOrc);
            dataGrid1.ItemsSource = listaOrc;
        }

        private void btnVoltar(object sender, RoutedEventArgs e)
        {
            var listar = new ListarOrcamento();
            this.Close();
            listar.Show();
        }

        private void btnPrint(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            //FlowDocument doc = new FlowDocument(new Paragraph(new Run("Some text goes here")));

            FlowDocument doc = CreateFlowDocument();

            doc.Name = "Orçamento";

            IDocumentPaginatorSource idpSource = doc;

            printDlg.PrintDocument(idpSource.DocumentPaginator, "Imprimir orçamento");
        }

        private FlowDocument CreateFlowDocument()
        {
            DAOOrcamento nome = new DAOOrcamento();
            DAOItemOrcamento daoItemOrc = new DAOItemOrcamento();
            List<ItemOrcamento> listaOrc = daoItemOrc.getTodosByID(codOrc);

            // Create a FlowDocument  
            FlowDocument doc = new FlowDocument();
            // Create a Section  
            Section sec = new Section();
            // Create first Paragraph  
            Paragraph paragNome = new Paragraph();
            Paragraph paragItens = new Paragraph();
            Paragraph paragTotal = new Paragraph();

            // Create and add a new Bold, Italic and Underline  
            Bold bld = new Bold();
            Bold bld2 = new Bold();
            bld.Inlines.Add(new Run("Nome do cliente: "+ nome.getNomeCliente(codOrc)));
            
       
            // Add Bold, Italic, Underline to Paragraph  
            paragNome.Inlines.Add(bld);
            foreach (ItemOrcamento i in listaOrc)
            {
                paragItens.Inlines.Add(new Run("Nome: " + i.Nome + " \tQuantidade: " + i.Quantidade + " \tValor unitário: " + i.Valor + "\n"));
            }
            bld2.Inlines.Add(new Run("Total: "));

            paragTotal.Inlines.Add(bld2);
            paragTotal.Inlines.Add(new Run("100"));
            // Add Paragraph to Section  
            sec.Blocks.Add(paragNome);
            sec.Blocks.Add(paragItens);
            sec.Blocks.Add(paragTotal);
            // Add Section to FlowDocument 
            doc.Blocks.Add(sec);
            doc.ColumnWidth = 900;
            doc.PageHeight = 900;
            doc.PageWidth = 900;
            return doc;
        }
    }
}
