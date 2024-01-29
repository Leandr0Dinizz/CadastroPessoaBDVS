using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    public class Program
    {
        static void Main(string[] args)
        {
            ControlPessoa pessoa = new ControlPessoa();//Conectando a control e a model
            pessoa.operacao();
            Console.ReadLine();//Manter o Prompt aberto
        }//Fim do método
    }//Fim da classe
}//Fim do rpojeto
