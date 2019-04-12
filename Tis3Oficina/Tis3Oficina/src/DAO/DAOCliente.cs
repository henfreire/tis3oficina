using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

        public void inserir(Cliente cliente)
        {


            try
            {
                // Query mysql
                String query = "INSERT INTO cliente (nome,cpf,telefone,email,endereco,observacao) VALUES('" + cliente.Nome + "', '" + cliente.Cpf + "', '"
                    + cliente.Telefone + "', '" + cliente.Email + "', '" + cliente.Endereco + "', '" + cliente.Observacao + "')";
                // Aqui passar a query e estância de conexão que é configurada na Classe no Conexao na pasta config
                MySqlCommand command = new MySqlCommand(query, conexao.getInstancia());

                // Executa a query

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro inserir Cliente : " + ex.Message, "Erro");
            }
        }
        public DataTable listarTodos()
        {
            DataTable dt = new DataTable();
            try
            {
                // Query mysql
                String sql = "SELECT * FROM cliente";
                MySqlCommand cmd = new MySqlCommand(sql, conexao.getInstancia());

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro inserir Cliente : " + ex.Message, "Erro");
            }
            Console.WriteLine("Teste", dt.ToString());
            return dt;
        }
        public List<Cliente> getTodos()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            DataTable dt = new DataTable();
            try
            {
                // Query mysql
                String sql = "SELECT * FROM cliente";
                MySqlCommand cmd = new MySqlCommand(sql, conexao.getInstancia());


                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Cliente c = new Cliente();

                        c.Id = dr["id"].ToString();
                        c.Nome = (String)dr["Nome"];
                        c.Cpf = (String)dr["Cpf"];
                        c.Email = (String)dr["Email"];
                        c.Telefone = (String)dr["Telefone"];
                        c.Endereco = (String)dr["Endereco"];
                        c.Observacao = (String)dr["Observacao"];

                        listaClientes.Add(c);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro buscar todos Clientes : " + ex.Message, "Erro");
            }
           
            return listaClientes;
        }

        public void editar(Cliente cliente, string id)
        {
            try
            {
                // Query mysql
                String query = "UPDATE cliente SET nome = '" + cliente.Nome + "', cpf= '" + cliente.Cpf + "', telefone='" +
                    cliente.Telefone + "', email='" + cliente.Email + "', endereco='" + cliente.Endereco + "', observacao='" +
                    cliente.Observacao + "' WHERE id = " + id + "; ";
                Console.WriteLine(query);

                // Aqui passar a query e estância de conexão que é configurada na Classe no Conexao na pasta config
                MySqlCommand command = new MySqlCommand(query, conexao.getInstancia());

                // Executa a query

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro inserir Cliente : " + ex.Message, "Erro");
            }
        }

    }
}
