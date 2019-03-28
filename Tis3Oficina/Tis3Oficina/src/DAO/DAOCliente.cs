using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tis3Oficina.src.Config;
using Tis3Oficina.src.OBJETOS;

namespace Tis3Oficina.src.DAO
{
    class DAOCliente
    {
        Conexao conexao = new Conexao();
        public DAOCliente()
        {
            conexao.conectar();
        }

        public void inserir(Cliente cliente )
        {
            

            try
            {
                // Query mysql
                String query = "INSERT INTO cliente (nome,cpf,telefone,email,endereco,observacao) VALUES('" + cliente.Nome + "', '" + cliente.Cpf + "', '" 
                    +cliente.Telefone + "', '" + cliente.Email+ "', '" + cliente.Endereco+ "', '" + cliente.Observacao+"')";
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
