using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Cliente
    {

        public string? Nome { get; set; }
        public int Conta { get; set; }
        public double Saque { get; set; }
        public double Saldo { get; set; }
        public double Deposito { get; set; }

        static double taxaSaque = 3.0;
        static double taxaTransferencia = 2.0;

        public static void CadastroConta(List<Cliente> clienteList)
        {
            Cliente cliente = new Cliente();
            Console.WriteLine("Digite o nome: ");
            cliente.Nome = Console.ReadLine();
            cliente.Conta = cliente.GerarConta();
            cliente.Deposito = 0.0;
            cliente.Saque = 0.0;
            Console.Clear();
            Console.WriteLine($"Nº Conta {cliente.Conta}");
            clienteList.Add(cliente);
        }
        public int GerarConta()
        {
            Random numAleatorio = new Random();
            int valorInteiro = numAleatorio.Next();
            return valorInteiro;
        }

        public static void ConsultaCadaCliente(List<Cliente> clienteList)
        {
            try
            {
                Console.WriteLine("Digite o Nº da sua Conta");
                int consulta = int.Parse(Console.ReadLine());
                var consultCadastro = clienteList.Where(c => c.Conta.Equals(consulta)).FirstOrDefault();

                if (consultCadastro != null)
                {
                    Console.WriteLine("Nome: " + consultCadastro.Nome);
                    Console.WriteLine("Conta: " + consultCadastro.Conta);
                    Console.WriteLine("Saldo: " + consultCadastro.Saldo);
                }
                else
                {
                    Console.WriteLine("Cliente nao cadastrado");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Valor informado incorreto");
            }
        }
        public static void DepositoConta(List<Cliente> clienteList)
        {
            try
            {
                Console.WriteLine("Digite o Nº da sua Conta: ");
                int consulta = int.Parse(Console.ReadLine());
                var consultCadastro = clienteList.Where(c => c.Conta.Equals(consulta)).FirstOrDefault();

                if (consultCadastro != null)
                {
                    Console.Write("Digite o valor a ser depositado: R$");
                    double deposito = double.Parse(Console.ReadLine());
                    if (deposito > 0)
                    {
                        consultCadastro.Saldo += deposito;
                        Console.WriteLine($"Saldo atualizado: R${consultCadastro.Saldo}");
                    }
                    else
                    {
                        Console.WriteLine("Valor precisa ser maior que R$0");
                    }
                }
                else
                {
                    Console.WriteLine("Cliente nao cadastrado");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Valor informado incorreto");
            }

        }

        public static void SaqueConta(List<Cliente> clienteList)
        {
            try
            {
                Console.WriteLine("Digite o Nº da sua Conta: ");
                int consulta = int.Parse(Console.ReadLine());
                var consultCadastro = clienteList.Where(c => c.Conta.Equals(consulta)).FirstOrDefault();

                if (consultCadastro != null)
                {
                    Console.Write("Digite o valor a ser sacado: R$");
                    double saque = double.Parse(Console.ReadLine());

                    if (consultCadastro.Saldo >= saque + taxaSaque && saque > 0)
                    {
                        consultCadastro.Saldo -= saque + taxaSaque;
                        Console.WriteLine("Saque realizado com sucesso!");
                        Console.WriteLine($"Saldo atualizado: R${consultCadastro.Saldo}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Saldo insuficiente para o saque.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Cliente nao cadastrado");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Valor informado incorreto");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        public static void TransferenciaConta(List<Cliente> clienteList)
        {
            try
            {
                Console.WriteLine("Digite o Nº da sua Conta: ");
                int contaOrigem = int.Parse(Console.ReadLine());
                var clienteOrigem = clienteList.Where(c => c.Conta.Equals(contaOrigem)).FirstOrDefault();

                if (clienteOrigem != null)
                {
                    Console.WriteLine("Digite o Nº da conta de destino: ");
                    int contaDestino = int.Parse(Console.ReadLine());
                    var clienteDestino = clienteList.Where(c => c.Conta.Equals(contaDestino)).FirstOrDefault();

                    if (clienteDestino != null)
                    {
                        Console.Write("Digite o valor a ser transferido: R$");
                        double transferencia = double.Parse(Console.ReadLine());

                        if (clienteOrigem.Saldo >= transferencia + taxaTransferencia && transferencia > 0)
                        {
                            clienteOrigem.Saldo -= transferencia + taxaTransferencia;
                            clienteDestino.Saldo += transferencia + taxaTransferencia;

                            Console.WriteLine("Transferencia realizada com sucesso!");
                            Console.WriteLine($"Saldo da conta de origem: R${clienteOrigem.Saldo}");
                        }
                        else
                        {
                            Console.WriteLine("Saldo insuficiente para a transferencia.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Conta de destino nao cadastrada");
                    }
                }
                else
                {
                    Console.WriteLine("Cliente nao cadastrado");
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Valor informado incorreto");
            }
        }
    }
}


