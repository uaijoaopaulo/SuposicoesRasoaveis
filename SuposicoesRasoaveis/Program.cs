using System;

namespace SuposicoesRasoaveis
{
    class Program
    {
        static int maiorQntChute = -1;
        static int menorQntChute = 9999999;
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                SuposicaoAutomatica();
            }
            Console.WriteLine("Maior quantidade de chute: " + maiorQntChute);
            Console.WriteLine("Menor quantidade de chute: " + menorQntChute);
            Console.ReadKey();
        }

        static void SuposicaoAutomatica()
        {
            Random rdn = new Random();

            int qntChutes = 1;
            int min = 1;
            int max = 100;
            bool correto = false;

            int numeroEscolhido = rdn.Next(min, max);

            while (correto == false)
            {
                var numeroChutado = (min + max) / 2;

                if (numeroChutado == numeroEscolhido)
                {
                    maiorQntChute = maiorQntChute < qntChutes ? qntChutes : maiorQntChute;
                    menorQntChute = menorQntChute > qntChutes ? qntChutes : menorQntChute;
                    correto = true;
                }
                else
                {
                    if (numeroChutado > numeroEscolhido)
                        max = numeroChutado;
                    else
                        min = numeroChutado;
                }
                qntChutes++;
            }
        }
        static void SuposicaoManual()
        {
            Random rdn = new Random();

            int qntChutes = 0;
            int min = 1;
            int max = 100;
            bool correto = false;

            Console.WriteLine("Escolha um numero de 1 a 100 \nAperte qualquer botão para continuar");
            Console.ReadKey();

            while (correto == false)
            {
                var numeroChutado = 0;
                if (qntChutes == 0)
                    numeroChutado = rdn.Next(min, max);
                else
                    numeroChutado = (min + max) / 2;

                string choice = "";
                while (choice != "N" & choice != "Y")
                {
                    qntChutes++;
                    Console.WriteLine("\n" + numeroChutado + " é o seu numero?? (Y/N)");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "Y":
                            Console.WriteLine("\nAcertei");
                            Console.WriteLine("Quantidade de chutes: " + qntChutes);
                            correto = true;
                            break;
                        case "N":
                            string choice2 = "";
                            while (choice2 != "MAIOR" & choice2 != "MENOR")
                            {
                                Console.WriteLine("\nO numero que chutei é MAIOR ou MENOR que o escolhido? (MAIOR/MENOR)");
                                choice2 = Console.ReadLine();
                                switch (choice2)
                                {
                                    case "MAIOR":
                                        max = numeroChutado;
                                        break;
                                    case "MENOR":
                                        min = numeroChutado;
                                        break;
                                    default:
                                        Console.WriteLine("\nAs opções são MAIOR e MENOR");
                                        break;
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("\nAs opções são Y para SIM e N para NÃO");
                            break;
                    }
                }
            }
        }
    }
}
