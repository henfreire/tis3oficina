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
    class DAOPeca
    {
        Conexao conexao = new Conexao();
        public DAOPeca()
        {
            conexao.conectar();
        }

        public void inserir(Peca peca)
        {


            try
            {
                // Query mysql
                String query = "INSERT INTO pecas (NomePec,QtdePec,ValPec) VALUES('" + peca.NomePec + "', '" + peca.QtdePeca + "', '" + peca.ValPec + "')";
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
                String sql = "SELECT * FROM pecas";
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
        public List<Peca> getTodos()
        {
            List<Peca> listaPecas = new List<Peca>();
            DataTable dt = new DataTable();
            try
            {
                // Query mysql
                String sql = "SELECT * FROM pecas";
                MySqlCommand cmd = new MySqlCommand(sql, conexao.getInstancia());


                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Peca s = new Peca();

                        s.CodPec = dr["CodPec"].ToString();
                        s.NomePec = (String)dr["NomePec"];
                        s.QtdePeca = (String)dr["QtdePec"];
                        s.ValPec = (String)dr["ValPec"];

                        listaPecas.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro buscar todos Serviços : " + ex.Message, "Erro");
            }

            return listaPecas;
        }

        public void editar(Peca peca, string codPec)
        {
            try
            {
                // Query mysql
                String query = "UPDATE pecas SET NomePec = '" + peca.NomePec + "', QtdePec= '" + peca.QtdePeca + "', '" + peca.ValPec + "' WHERE CodPec = " + codPec + "; ";

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
                String query = "DELETE FROM pecas WHERE CodPec = " + codPec + ";";

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
