using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class CadastroCliente
    {

        public int CadastrosClientes()
        {

            Console.WriteLine("Menu");

            Console.WriteLine("1-Cadastro de Conta");

            Console.WriteLine("2-Consulta de Extrato");

            Console.WriteLine("3-Depósito");

            Console.WriteLine("4-Saque");

            Console.WriteLine("5-Transferência");

            Console.WriteLine("0-Sair");

            int usuario = int.Parse(Console.ReadLine());
            return usuario;

        }
    }
}
