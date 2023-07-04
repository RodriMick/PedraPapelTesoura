using System;

class Program
{

    static int rodadas;

    public static void Main(string[] args)
    {
        Start();
    }

    public static void Start()
    {
        DesenhaCabecalhio(3);
        Console.WriteLine("Digite \"1\" para começar");

        int iniciar;
        iniciar = Int32.Parse(Console.ReadLine());

        while (iniciar != 1)
        {
            DesenhaCabecalhio(3);
            Console.WriteLine("Opção Inválida! Digite 1 para começar: ");
            iniciar = Int32.Parse(Console.ReadLine());
        }

        DefineRodadas();
    }

    public static void DesenhaCabecalhio(int linhasExtras)
    {

        Console.Clear();

        Console.WriteLine("*******************************");
        Console.WriteLine("*   Pedra, Papel ou Tesoura   *"); Console.WriteLine("*******************************");

        for (int i = 0; i < linhasExtras; i++)
        {
            Console.WriteLine("\n");
        }
    }

    public static void DefineRodadas()
    {

        DesenhaCabecalhio(3);
        Console.WriteLine("Quantas rodadas você quer jogar? 3, 5 ou 7");
        rodadas = Int32.Parse(Console.ReadLine());

        while (rodadas != 3 && rodadas != 5 && rodadas != 7)
        {
            DesenhaCabecalhio(3);

            Console.WriteLine("Você digitou um valor inválido.Escolha entre os números 3, 5 ou 7 para começar: ");
            rodadas = Int32.Parse(Console.ReadLine());
        }

        ControlaRodadas();
    }
    public static void ControlaRodadas()
    {
        int rodadaAtual = 1;
        int pontosUsuarios = 0;
        int pontosComput = 0;
        bool fimDeJogo = false;

        while (fimDeJogo != true)
        {
            DesenhaCabecalhio(0);
            Console.WriteLine("          Rodada " + rodadaAtual.ToString() + "/" + rodadas.ToString() + "           ");
            Console.WriteLine();
            Console.WriteLine("User: " + pontosUsuarios.ToString() + " pontos  |  CPU: " + pontosComput.ToString() + " pontos");

            switch (ExibeRodada())
            {
                case 0:
                    break;
                case 1:
                    pontosUsuarios++;
                    rodadaAtual++;
                    if (pontosUsuarios > rodadas / 2)
                    {
                        Console.WriteLine("Usuario venceu");
                        fimDeJogo = true;
                    }
                    break;
                case 2:
                    pontosComput++;
                    rodadaAtual++;
                    if (pontosComput > rodadas / 2)
                    {
                        Console.WriteLine("Computador venceu");
                        fimDeJogo = true;
                    }
                    break;
            }
            if (fimDeJogo == true)
            {
                DesenhaCabecalhio(3);
                if (pontosUsuarios > pontosComput)
                {
                    Console.WriteLine("Parabéns !!! Você Venceu !!!");
                }
                else
                {
                    Console.WriteLine("Não foi dessa vez !");
                }
                Console.WriteLine("\n\n");
                Console.WriteLine("Digite qualquer tecla para continuar");
                Console.ReadLine();
                Console.WriteLine();
                Start();
            }
            else
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Digite 1 para continuar ou 0 para sair");
                if (Int32.Parse(Console.ReadLine()) == 0)
                {
                    Start();
                }
            }
        }

    }
    public static int ExibeRodada()
    {
        string escolhaDoUsuario;
        string escolhaDoPrograma;

        string[] opcoes =  {
      "PEDRA",
      "PAPEL",
      "TESOURA"
    };

        Console.WriteLine();
        Console.WriteLine("Escolha uma das opções: Pedra, Papel ou Tesoura?");
        escolhaDoUsuario = Console.ReadLine().ToUpper();

        while (escolhaDoUsuario != "PEDRA" && escolhaDoUsuario != "PAPEL" && escolhaDoUsuario != "TESOURA")
        {
            Console.WriteLine("Você fez uma escolha inválida. Digite novamente: Pedra, Papel ou Tesoura?");
            escolhaDoUsuario = Console.ReadLine().ToUpper();
        }

        Random rand = new Random();
        int sorteio = rand.Next(opcoes.Length);
        escolhaDoPrograma = opcoes[sorteio];

        Console.WriteLine();
        Console.WriteLine("A escolha do computador foi:");
        Console.WriteLine(escolhaDoPrograma);
        Console.WriteLine();

        if (escolhaDoUsuario == escolhaDoPrograma)
        {
            Console.WriteLine("Deu empate");
            return 0;
        }
        else if (escolhaDoUsuario == "PEDRA" && escolhaDoPrograma == "TESOURA")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else if (escolhaDoUsuario == "TESOURA" && escolhaDoPrograma == "PAPEL")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else if (escolhaDoUsuario == "PAPEL" && escolhaDoPrograma == "PEDRA")
        {
            Console.WriteLine("Parabéns! Você ganhou!");
            return 1;
        }
        else
        {
            Console.WriteLine("Seu Noob !");
            return 2;
        }

    }
}