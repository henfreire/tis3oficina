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
    class DAOServico
    {
        Conexao conexao = new Conexao();
        public DAOServico()
        {
            conexao.conectar();
        }

        public void inserir(Servico servico)
        {


            try
            {
                // Query mysql
                String query = "INSERT INTO servico (nomeServico,valor) VALUES('" + servico.NomeServico + "', '" + servico.Valor.ToString().Replace(",", ".") + "')";
                // Aqui passar a query e estância de conexão que é configurada na Classe no Conexao na pasta config
                MySqlCommand command = new MySqlCommand(query, conexao.getInstancia());

                // Executa a query

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro inserir Serviço : " + ex.Message, "Erro");
            }
        }
        public DataTable listarTodos()
        {
            DataTable dt = new DataTable();
            try
            {
                // Query mysql
                String sql = "SELECT * FROM servico";
                MySqlCommand cmd = new MySqlCommand(sql, conexao.getInstancia());

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro inserir Cliente : " + ex.Message, "Erro");
            }
            return dt;
        }
       
        public List<Servico> geTodos()
        {
            List<Servico> servicos = new List<Servico>();
            try
            {
                // Query mysql
                String sql = "SELECT * FROM servicos";
                MySqlCommand cmd = new MySqlCommand(sql, conexao.getInstancia());
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Servico servico = new Servico();

                        servico.Id = (String)dr["id"];
                        servico.NomeServico = (String)dr["nomeServico"];
                        servico.Valor = (double)dr["valor"];

                        servicos.Add(servico);
                    }
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro getTodos serviços : " + ex.Message, "Erro");
            }
            return servicos;
        }
        public List<Servico> getTodos()
        {
            List<Servico> listaServicos = new List<Servico>();
            DataTable dt = new DataTable();
            try
            {
                // Query mysql
                String sql = "SELECT * FROM servico";
                MySqlCommand cmd = new MySqlCommand(sql, conexao.getInstancia());


                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Servico s = new Servico();

                        s.Id = (String) dr["id"].ToString();
                        s.NomeServico = (String)dr["NomeServico"];
                        s.Valor = (double)dr["Valor"];

                        listaServicos.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro buscar todos Serviços : " + ex.Message, "Erro");
            }
           
            return listaServicos;
        }

        public void editar(Servico servico, string id)
        {
            try
            {
                // Query mysql
                String query = "UPDATE servico SET nomeServico = '" + servico.NomeServico + "', valor= '" + servico.Valor + "' WHERE id = " + id + "; ";
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

        public void deletar(string id)
        {
            try
            {
                // Query mysql
                String query = "DELETE FROM `servico` WHERE `id` = "+id+";";

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
