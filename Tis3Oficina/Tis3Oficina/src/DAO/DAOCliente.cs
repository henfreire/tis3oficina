﻿using MySql.Data.MySqlClient;
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
            List<Cliente> clientes = new List<Cliente>();
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

                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro inserir Cliente : " + ex.Message, "Erro");
            }
            Console.WriteLine("Teste", dt.ToString());
            return clientes;
        }

    }
}
