using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tis3Oficina.src.Config;
using Tis3Oficina.src.OBJETOS;

namespace Tis3Oficina.src.DAO
{
    class DAOOrcamento
    {
        Conexao conexao = new Conexao();
        public DAOOrcamento()
        {
            conexao.conectar();
        }

        public void inserir(Orcamento orc)
        {


            try
            {
                // Query mysql
                String query = "INSERT INTO orcamento (QtdeItens,TotOrc,idCliente) VALUES('" + orc.QtdeItens + "', '" + orc.TotOrc + "', '" + orc.IdCliente + "')";
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
                String sql = "SELECT * FROM orcamento";
                MySqlCommand cmd = new MySqlCommand(sql, conexao.getInstancia());

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro inserir Orçamento : " + ex.Message, "Erro");
            }
            return dt;
        }
        public List<Peca> getTodos()
        {
            List<Peca> listaorcamento = new List<Peca>();
            DataTable dt = new DataTable();
            try
            {
                // Query mysql
                String sql = "SELECT * FROM orcamento";
                MySqlCommand cmd = new MySqlCommand(sql, conexao.getInstancia());


                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Orcamento orc = new Orcamento();

                        orc.CodOrc = (int)dr["CodOrc"];
                        orc.QtdeItens = (int)dr["QtdeItens"];
                        orc.TotOrc = (int)dr["TotOrc"];
                        orc.IdCliente = (int)dr["IdCliente"];
                        
                       
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro buscar todos Serviços : " + ex.Message, "Erro");
            }

            return listaorcamento;
        }

        public void editar(Peca peca, string codPec)
        {
            try
            {
                // Query mysql
                String query = "UPDATE orcamento SET NomePec = '" + peca.NomePec + "', QtdePec= '" + peca.QtdePeca + "', '" + peca.ValPec + "' WHERE CodPec = " + codPec + "; ";

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

        public void deletar(string codPec)
        {
            try
            {
                // Query mysql
                String query = "DELETE FROM orcamento WHERE CodPec = " + codPec + ";";

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

