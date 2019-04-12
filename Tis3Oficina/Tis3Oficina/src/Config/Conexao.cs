using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace Tis3Oficina.src.Config
{
    class Conexao
    {
        private MySqlConnection instancia;
        public MySqlConnection getInstancia()
        {
            return this.instancia;
        }
        public Conexao()
        {
            this.conectar();
        }
        public void conectar()
        {

            try
            {
                this.instancia = new MySqlConnection("server=localhost;port=3306;User Id=root;database=oficina;password=''");
                this.instancia.Open();
                //  System.Windows.Forms.MessageBox.Show("conectado");

            }
            catch (MySqlException msqle)
            {
                System.Windows.Forms.MessageBox.Show("Erro de acesso ao MySQL : " + msqle.Message, "Erro");
            }
            finally
            {

            }
            
        }

    }
}
