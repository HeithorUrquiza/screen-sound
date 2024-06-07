using ScreenSoundEdit.Modelos;

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
    Console.WriteLine("Boas vindas ao Screen Sound");
}

void FormataTitulo(string titulo)
{
    int tamanhoTitulo = titulo.Length;
    string margem = string.Empty.PadLeft(tamanhoTitulo + 4, '-');

    Console.WriteLine(margem);
    Console.WriteLine($"  {titulo}");
    Console.WriteLine(margem + "\n");
}

int ColetarEscolhaMenu()
{
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbun de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite -1 para sair\n");

    Console.Write("Informe sua opção: ");
    return int.Parse(Console.ReadLine()!);
}

void RegistrarBanda(Dictionary<string, Banda> bandas)
{
    Console.Clear();
    FormataTitulo("REGISTRO DE BANDAS");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandas.Add(nomeDaBanda, new Banda(nomeDaBanda));
    Thread.Sleep(2500);
    Console.Clear();
}

void RegistrarAlbum(Dictionary<string, Banda> bandas)
{
    Console.Clear();
    FormataTitulo("REGISTRO DE ÁLBUM");
    Console.Write("Digite o nome da banda para registro do novo álbum: ");
    var bandaEscolhida = Console.ReadLine()!;

    if (bandas.ContainsKey(bandaEscolhida))
    {
        Console.Write("Informe o nome do novo ábum: ");
        var novoAlbum = new Album(Console.ReadLine()!);

        Console.Write("Informe a quantidade de músicas: ");
        var qtdMusicas = int.Parse(Console.ReadLine()!);
        Console.WriteLine();

        for (int i = 0; i < qtdMusicas; i++)
        {
            Console.Write("Digite as informações da música no seguinte formato 'Nome - Duracao': ");
            var infoMusica = Console.ReadLine()!.Split("-");
            novoAlbum.AdicionarMusica(new Musica(infoMusica[0].Trim(), bandas[bandaEscolhida], int.Parse(infoMusica[1].Trim())));
        }

        bandas[bandaEscolhida].AdicionarAlbum(novoAlbum);

        Console.WriteLine("\nÁlbum adicionado com sucesso");
        Thread.Sleep(2500);
        Console.Clear();
    }
    else
    {
        Console.WriteLine($"\nA banda {bandaEscolhida} não foi encontrada nos registros");
        Console.Write("Pressione qualquer tecla para voltar para o menu inicial ");
        Console.ReadKey();
        Console.Clear();
    }

}

void ExibirTodasAsBandasSalvas(Dictionary<string, Banda> bandas)
{
    Console.Clear();
    FormataTitulo("BANDAS REGISTRADAS");

    foreach (string banda in bandas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.Write("\nDigite uma tecla para retornar ao menu");
    Console.ReadKey();
    Console.Clear();
}

void AvaliarBanda(Dictionary<string, Banda> bandas)
{
    Console.Clear();
    FormataTitulo("AVALIAÇÃO DE BANDA");
    Console.Write("Informe o nome da banda que deseja avaliar: ");
    string bandaEscolhida = Console.ReadLine()!;

    if (bandas.ContainsKey(bandaEscolhida))
    {
        Console.Write("Digite o valor da nota: ");

        int nota = int.Parse(Console.ReadLine()!);
        bandas[bandaEscolhida].AdicionarNota(new Avaliacao(nota));

        Console.WriteLine("\nRegistrando nota. Aguarde...");
        Thread.Sleep(2500);
        Console.WriteLine($"Nota registrada com sucesso para a banda {bandaEscolhida}");
        Thread.Sleep(2500);
        Console.Clear();
    }
    else
    {
        Console.WriteLine($"\nA banda {bandaEscolhida} não foi encontrada nos registros");
        Console.Write("Pressione qualquer tecla para voltar para o menu inicial ");
        Console.ReadKey();
        Console.Clear();
    }
}

void ExibirDetalhes(Dictionary<string, Banda> bandas)
{
    Console.Clear();
    FormataTitulo("DETALHES DA BANDA");
    Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
    string bandaEscolhida = Console.ReadLine()!;

    if (bandas.ContainsKey(bandaEscolhida))
    {
        bandas[bandaEscolhida].ExibirDetalhes();

        Console.WriteLine("\nDigite uma tecla para votar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
    else
    {
        Console.WriteLine($"\nA banda {bandaEscolhida} não foi encontrada nos registros");
        Console.Write("Pressione qualquer tecla para voltar para o menu inicial ");
        Console.ReadKey();
        Console.Clear();
    }
}

void ExecutarPrograma()
{
    bool parar = false;
    var bandasRegistradas = new Dictionary<string, Banda>()!;
    var skillet = new Banda("Skillet");

    skillet.AdicionarNota(new Avaliacao(10));
    skillet.AdicionarNota(new Avaliacao(9));
    skillet.AdicionarNota(new Avaliacao(10));

    bandasRegistradas.Add("Skillet", skillet);

    do
    {
        ExibirLogo();
        int opcaoEscolhida = ColetarEscolhaMenu();
        switch (opcaoEscolhida)
        {
            case 1:
                RegistrarBanda(bandasRegistradas);
                break;
            case 2:
                RegistrarAlbum(bandasRegistradas);
                break;
            case 3:
                ExibirTodasAsBandasSalvas(bandasRegistradas);
                break;
            case 4:
                AvaliarBanda(bandasRegistradas);
                break;
            case 5:
                ExibirDetalhes(bandasRegistradas);
                break;
            case -1:
                Console.WriteLine("Tchau tchau :)");
                parar = true;
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    } while (!parar);
}


ExecutarPrograma();
