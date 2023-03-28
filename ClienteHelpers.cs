using Bank;
using System;
using System.Collections.Generic;
using System.Linq;

internal static class ClienteHelpers
{
    public static void Deposito(List<Cliente> ClienteList)
    {
        int Consulta;
        Console.WriteLine("Digite o Nº da sua Conta");
        Consulta = int.Parse(Console.ReadLine());
        var ConsultCadastro = ClienteList.Where(c => c.GerarConta().Equals(Consulta)).FirstOrDefault();

        if (ConsultCadastro != null)
        {
            Console.WriteLine("Nome: " + ConsultCadastro.Nome);
            Console.WriteLine("CPF: " + ConsultCadastro.Saldo);
        }
        else
        {
            Console.WriteLine("Cliente nao cadastrado");
        }


    }
}