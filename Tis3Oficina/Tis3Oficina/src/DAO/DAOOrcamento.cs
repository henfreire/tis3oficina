﻿using MySql.Data.MySqlClient;
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

        public String inserir(Orcamento orc)
        {

            String idOrc = null;
            try
            {
                // Query mysql
                String query = "INSERT INTO orcamento (QtdeItens,TotOrc,idCliente) VALUES('" + orc.QtdeItens + "', '" + orc.TotOrc + "', '" + orc.IdCliente + "'); SELECT LAST_INSERT_ID() as id;";
                Console.WriteLine("query" + query);
                // Aqui passar a query e estância de conexão que é configurada na Classe no Conexao na pasta config
                MySqlCommand cmd = new MySqlCommand(query, conexao.getInstancia());

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                     
                        idOrc = dr["id"].ToString();
                    }
                }  
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro inserir Orçamento : " + ex.Message, "Erro");
            }
            return idOrc;
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
        public List<Orcamento> getTodos()
        {
            List<Orcamento> listaOrc = new List<Orcamento>();
            try
            {
                // Query mysql
                String sql = "SELECT CodOrc, QtdeItens, TotOrc, C.nome FROM orcamento O INNER JOIN cliente C ON O.IdCliente = C.id";
                MySqlCommand cmd = new MySqlCommand(sql, conexao.getInstancia());


                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Orcamento orc = new Orcamento();

                        orc.CodOrc = dr["CodOrc"].ToString();
                        orc.QtdeItens = int.Parse(dr["QtdeItens"].ToString());
                        orc.TotOrc = Double.Parse(dr["TotOrc"].ToString());
                        orc.IdCliente = dr["nome"].ToString();
                        listaOrc.Add(orc);
                       
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro buscar todos Serviços : " + ex.Message, "Erro");
            }

            return listaOrc;
        }

        public String[] getNomeeTotal(string ID)
        {
            String[] nomeTotal= new String[2];
            try
            {
                // Query mysql
                String sql = "SELECT C.nome, TotOrc FROM orcamento O INNER JOIN cliente C ON O.IdCliente = C.id WHERE O.CodOrc = "+ ID +"";
                MySqlCommand cmd = new MySqlCommand(sql, conexao.getInstancia());


                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        nomeTotal[0]= (dr["nome"].ToString());
                        nomeTotal[1]= (dr["TotOrc"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro buscar todos Serviços : " + ex.Message, "Erro");
            }

            return nomeTotal;
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
                System.Windows.Forms.MessageBox.Show("Erro deletar Orçamento : " + ex.Message, "Erro");
            }
        }

    }
}

