using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace Cadastro
{
    class DAO
    {
        public MySqlConnection conexao;//COnectar ao banco de dados 
        public string dados;
        public string sql;
        public string resultado;
        public int[] codigo;
        public string[] nome;
        public string[] telefone;
        public string[] cidade;
        public string[] endereco;
        public int i;
        public int contador;
        public string msg;
        public DAO()
        {

            conexao = new MySqlConnection("server=localhost;DataBase=ti18nPessoa;Uid=root;Password=");
            try
            {
                conexao.Open();//Abri a conexão com o DB
                Console.WriteLine("Conectado com sucesso!");
            }
            catch (Exception erro) 
            {
                Console.WriteLine("Algo deu errado! Verifique a conexão!\n\n" + erro);
                conexao.Close();//Fechar a conexão com o DB
            }//FIm do try catch
        }//Fim do método

        //Método inserir

        public void inserir(string nome, string telefone, string cidade, string endereco)
        {
            try
            {
            
                dados = "('','" + nome + "','" + telefone + "','" + cidade + "','" + endereco + "')";
                sql = "insert into Pessoa(codigo, nome, telefone, cidade, endereco) values" + dados;

                MySqlCommand conn = new MySqlCommand(sql, conexao);//Prepara a execução no banco de dados
                resultado = "" + conn.ExecuteNonQuery();//Ctrl + Enter -> executando o comando no banco de dados
                Console.WriteLine(resultado + "Linha afetada");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro!!! Algo deu errado\n\n\n" + erro);
            }//Fim do try catch
        }//Fim do método

        //Método consultar
        public void PreencherVetor()
        {
            string query = "select * from Pessoa";

            //Instanciar vetor
            codigo = new int[100];
            nome = new string[100];
            telefone = new string[100];
            cidade = new string[100];
            endereco = new string[100];

            //Preencher com valores genéricos
            for(i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                nome[i] = "";
                telefone[i] = "";
                cidade[i] = "";
                endereco[i] = "";    
            }//Fim do for

            //Preparando o comando para o banco
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Leitura do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;
            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                nome[i] = "" + leitura["nome"];
                telefone[i] = "" + leitura["telefone"];
                cidade[i] = "" + leitura["cidade"];
                endereco[i] = "" + leitura["endereco"];
                i++;
                contador++;
            }//Preenchendo o vetor com os dados do banco
            
            leitura.Close();//Encerar o acessoao banco de dados            
        }//Fim do preencher

        //Método para consultar TODOS os dados do banco de dados
        public string ConsultarTudo()
        {
            //Preencher o vetor
            PreencherVetor();
            msg = "";
            for(i=0;i < contador; i++)
            {
                msg += "\n\nCódigo: " + codigo[i]   + 
                       ", Nome: " + nome[i]         +      
                       ", Telefone: " + telefone[i] + 
                       ", Cidade: " + cidade[i]     + 
                       ", Endereço: " + endereco[i];
            }//Fim do for

            return msg;//Mostrar em tela o resultado da consulta
        }//Fim do ConsultarTudo
        
        public string ConsultarTudo(int cod)
        {
            PreencherVetor();

            for (i=0; i < contador; i++)
            {
                if (codigo[i] == cod)
                {
                    msg = "\n\nCódigo: "   + codigo[i]   +
                          ", Nome: "       + nome[i]     +
                          ", Telefone: "   + telefone[i] +
                          ", Cidade: "     + cidade[i]   +
                          ", Endereco: "   + endereco[i];
                    return msg;
                }//Fim do if               
            }//Fim do for
            return "Código informado não encontrado!";
        }//Fim do método

        public string Atualizar(int cod, string campo, string dado)
        {
            try
            {
                string query = "update pessoa set" + campo + " = '" + dado + "' where codigo = '" + cod + "'"; 
                //Prepara o comando do BD
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " Linha afetada!"; 
            }catch(Exception erro)
            {
                return "Algo deu errado!\n\n" + erro;
            }//Fim do try catch
        }//Fim do método

        public string Excluir(int cod)
        {
            string query = "delete from pessoa where codigo = '" + cod + "'";
            //Preparar comando
            MySqlCommand sql = new MySqlCommand(query, conexao);
            string resultado = "" + sql.ExecuteNonQuery();
            //Mostrar resultado
            return resultado + " Linha afetada";
        }//Fim do método

    }//Fim da classe
}//Fim do projeto
