using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tis3Oficina.src.Config;

namespace Tis3Oficina.src.DAO
{
    class DAOCliente
    {
        Conexao conexao = new Conexao();
        public DAOCliente()
        {
            //conexao.conectar();
        }

        public void inserir( )
        {
            try
            {
                // Query mysql
                String query = "INSERT INTO cliente (nome) VALUES ('Henrique');";
                // Aqui passar a query e estância de conexão que é configurada na Classe no Conexao na pasta config
                MySqlCommand command = new MySqlCommand(query, conexao.getInstancia());
                // Executa a query
                command.ExecuteNonQuery();
            }catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro inserir Cliente : " + ex.Message, "Erro");
            }
        }
        
    }
}
