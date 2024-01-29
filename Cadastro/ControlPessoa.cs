using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    class ControlPessoa
    {
        private int opcao = 0;
        public int codigo;
        DAO conectar;
        public ControlPessoa() 
        {
            ConsultarOpcao = 0;  
            conectar = new DAO(); //Conectando com o banco de dados
        }//Fim do construtor

        public int ConsultarOpcao
        {
            get { return this.opcao; }
            set { this.opcao = value;  }
        }//fim do getSet

        public void Menu()
        {
            Console.WriteLine("Escolha uma das opções abaixo: \n" +
                              "1. Cadastrar\n" +
                              "2. Consultar\n" +
                              "3. Consultar indivídual\n" +
                              "4. Atualizar\n" +
                              "5. Excluir\n" +
                              "6. Sair");
            ConsultarOpcao = Convert.ToInt32(Console.ReadLine());
        }//Fim do Menu

        public void operacao()
        {
            do
            {
                Menu();//Mostrar as opções para o usuário
                switch (ConsultarOpcao)
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        ConsultarTudo();
                        break;
                    case 3:
                        ConsultarIndividual();
                        break;
                    case 4:
                        MenuAtualizar();
                        break;
                    case 5:
                        Deletar();
                        break;
                    case 6:
                        //Agradecer
                        Console.WriteLine("Obrigado!");
                        break;
                    default:
                        Console.WriteLine("Informe um código de acordo com o menu");
                        break;
                }//Fim do escolha caso
            } while (ConsultarOpcao != 6);
        }//fim do método

        public void Cadastrar()
        {
            Console.WriteLine("Informe o nome da pessoa: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o telefone da pessoa: ");
            string telefone = Console.ReadLine();
            Console.WriteLine("Informe o nome da cidade da pessoa: ");
            string cidade = Console.ReadLine();
            Console.WriteLine("Informe o endereço da pessoa: ");
            string endereco = Console.ReadLine();
            //Dados que vou inserir no BD
            conectar.inserir(nome, telefone, cidade, endereco);

        }//Fim do método cadastrar

        public void ConsultarTudo()
        {
            Console.WriteLine(conectar.ConsultarTudo());
        }//Fim do consultar tudo

        public void ConsultarIndividual()
        {
            Console.WriteLine("Informe oi código que deseja consultar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //Mostrar na tela
            Console.WriteLine(conectar.ConsultarTudo(codigo));
        }//fim do consultar

        public void MostrarMenuAtualizar()
        {
            Console.WriteLine("Escolha uma das opções abaixo: " +
                              "\n1. Nome "    +
                              "\n2. Telefone" +
                              "\n3. Cidade"   +
                              "\n4. Endereço ");
            opcao = Convert.ToInt32(Console.ReadLine());
        }//Fim do método

        public void MenuAtualizar()
        {
            MostrarMenuAtualizar();
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Informe o código do dado que deseja atualizar: ");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo nome: ");
                    string nome = Console.ReadLine();
                    //Método que deseja atualizar
                    conectar.Atualizar(codigo, "nome", nome);
                    break;
                case 2:
                    Console.WriteLine("Informe o códigpo do dado que deseja atualizar: ");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo telefone: ");
                    string telefone = Console.ReadLine();
                    //Método que deseja atualizar
                    Console.WriteLine("\n\n" + conectar.Atualizar(codigo, "telefone", telefone));
                    break;
                case 3:
                    Console.WriteLine("Informe o códigpo do dado que deseja atualizar: ");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe a nova cidade: ");
                    string cidade = Console.ReadLine();
                    //Método que deseja atualizar
                    conectar.Atualizar(codigo, "cidade", cidade);
                    break;
                case 4:
                    Console.WriteLine("Informe o códigpo do dado que deseja atualizar: ");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo endereço: ");
                    string endereco = Console.ReadLine();
                    //Método que deseja atualizar
                    conectar.Atualizar(codigo, "endereço", endereco);
                    break;
                default:
                    Console.WriteLine("Opção não é válida!");
                    break;
            }//Fim do escolha
        }//Fim do método

        public void Deletar()
        {
            Console.WriteLine("Informe um código: ");
            codigo = Convert.ToInt32(Console.ReadLine());
            //Utilizar método excluir
            Console.WriteLine("\n\n" + conectar.Excluir(codigo));
        }//Fim do método

    }//Fim da classe
}//Fim do Projeto
