using Bank;
using System;
using System.Collections.Generic;

List<Cliente> clienteList = new List<Cliente>();
CadastroCliente usuario = new CadastroCliente();
int? opcaoConsulta = usuario.CadastrosClientes();

do
{
    if (opcaoConsulta != null && opcaoConsulta <=5 && opcaoConsulta >= 0) 
    {
        if (opcaoConsulta == 1)
        {
            Cliente.CadastroConta(clienteList);
            opcaoConsulta = usuario.CadastrosClientes();
        }
        else if (opcaoConsulta == 2)
        {
            Console.Clear();
            Cliente.ConsultaCadaCliente(clienteList);
            opcaoConsulta = usuario.CadastrosClientes();
        }
        else if (opcaoConsulta == 3)
        {
            Console.Clear();
            Cliente.DepositoConta(clienteList);
            opcaoConsulta = usuario.CadastrosClientes();
        }
        else if (opcaoConsulta == 4)
        {
            Console.Clear();
            Cliente.SaqueConta(clienteList);
            opcaoConsulta = usuario.CadastrosClientes();
        }
        else if (opcaoConsulta == 5)
        {
            Console.Clear();
            Cliente.TransferenciaConta(clienteList);
            opcaoConsulta = usuario.CadastrosClientes();
        }
    }
    else
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Digite apenas as opções disponíveis");
        Console.ForegroundColor = ConsoleColor.White;
        opcaoConsulta = usuario.CadastrosClientes();
    }
} while (opcaoConsulta != 0);

