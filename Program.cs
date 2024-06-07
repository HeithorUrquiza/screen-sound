using ScreenSoundEdit.Menus;
using ScreenSoundEdit.Modelos;

internal class Program
{
    private static void Main(string[] args)
    {
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
                        MenuRegistrarBanda.Executar(bandasRegistradas);
                        break;
                    case 2:
                        MenuRegistrarAlbum.Executar(bandasRegistradas);
                        break;
                    case 3:
                        MenuExibirBandas.Executar(bandasRegistradas);
                        break;
                    case 4:
                        MenuAvaliarBanda.Executar(bandasRegistradas);
                        break;
                    case 5:
                        MenuExibirDetalhes.Executar(bandasRegistradas);
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
    }
}