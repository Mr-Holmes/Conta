using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta
{
    class Program
    {
        public class Contabanco
        {
            public int numconta;
            protected String tipo;
            private String dono;
            private int banco;
            private Double saldo;
            private Boolean status;

            public Contabanco()
            {
                saldo = 0;
                Status = false;
            }

            public int Banco
            {
                get { return banco; }
                set { banco = value; }
            }

            public int Numconta
            {
                get { return numconta; }
                set { numconta = value; }
            }

            public String Tipo
            {
                get { return tipo; }
                set { tipo = value; }
            }

            public String Dono
            {
                get { return dono; }
                set { dono = value; }
            }

            public double Saldo
            {
                get { return saldo; }
                set { saldo = value; }
            }

            public Boolean Status
            {
                get { return status; }
                set { status = value; }
            }
            
            public void AbrirConta(String tipo)
            {
                Tipo = tipo.ToUpper();
                Status = true;
                
                if("CC".Equals(Tipo))
                {
                    Saldo = 50;
                }
                else if("CP".Equals(Tipo))
                {
                   Saldo = 150;
                }
                Console.WriteLine("Conta Aberta com sucesso");
            }

            public void FecharConta()
            {
                if(Saldo > 0)
                {
                    Console.WriteLine("Conta com dinheiro");
                }
                else if(Saldo < 0)
                {
                    Console.WriteLine("Sua conta esta em débito");
                }
                else
                {
                    Status = false;
                    Console.WriteLine("Conta fechada com sucesso");
                }
            }

            public void Depositar(Double valor)
            {
                if (Status)
                {
                    Saldo = Saldo + valor;
                    Console.WriteLine("Valor depositado na conta de " + Dono);
                }
                else
                {
                    Console.WriteLine("Conta esta fechada");
                    Console.WriteLine("Valor não depositado");
                }
            }

            public void Sacar(Double valor)
            {
                if (Status)
                {
                    if (Saldo >= valor)
                    {
                        Saldo = Saldo - valor;
                        Console.WriteLine("Retire seu dinheiro");
                    }
                    else
                    {
                        Console.WriteLine("Saldo Inuficiente para Saque");
                    }
                }
                else
                {
                    Console.WriteLine("Impossivel sacar conta fechada");    
                }
                    
            }

            public void EstadoAtual()
            {
                Console.WriteLine("$$$$$$$$$$$$ Banco $$$$$$$$$$$$");
                Console.WriteLine("Número da conta: " + Numconta);
                Console.WriteLine("Tipo da conta: " + Tipo);
                Console.WriteLine("Dono: " + Dono);
                Console.WriteLine("Saldo: " + Saldo);
                Console.WriteLine("Status: " + Status);
                Console.WriteLine(" ");
            }

            public override string ToString()
            {
                String painel = " ";

                painel += String.Format("Escolha uma das opções\n");
                painel += String.Format("(1) - Abrir Conta\n");
                painel += String.Format("(2) - Deposito\n");
                painel += String.Format("(3) - Saque\n");
                painel += String.Format("(4) - Saldo\n");
                painel += String.Format("(5) - Fechar conta\n");
                painel += String.Format("(6) - Sair");
                return painel;
            }

        }

        static void Main(string[] args)
        {

            Contabanco contabanco = new Contabanco();

            Random random = new Random();

            int button = 0;
            Boolean executando;
            String pergunta;

            do
            {

                Console.WriteLine(contabanco.ToString());
                button = Convert.ToInt32(Console.ReadLine());
                executando = true;



                switch (button)
                {

                    case 1:
                        Console.WriteLine("Digite o seu nome: ");
                        contabanco.Dono = Console.ReadLine();
                        contabanco.Numconta = random.Next(100, 2000);
                        Console.WriteLine("Dgite o seu tipo de conta: ");
                        contabanco.AbrirConta(Console.ReadLine());
                        break;

                    case 2:
                        Console.WriteLine("Quanto vai depositar em sua conta");
                        contabanco.Depositar(Convert.ToDouble(Console.ReadLine()));
                        break;

                    case 3:
                        Console.WriteLine("Quanto vai sacar?");
                        contabanco.Sacar(Convert.ToDouble(Console.ReadLine()));
                        break;

                    case 4:
                        contabanco.EstadoAtual();
                        break;

                    case 5:
                        contabanco.FecharConta();
                        break;

                    case 6:
                        Console.WriteLine("Até a proxíma");
                        executando = false;
                        break;

                    default:
                        Console.WriteLine("Tecla invalida re-digite por favor!");
                        break;


                }

            } while (executando);

            Console.ReadKey();
        }
    }
}
