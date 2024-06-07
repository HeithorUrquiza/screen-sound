using ScreenSoundEdit.Modelos;

namespace ScreenSoundEdit.Menus;

internal class MenuExibirDetalhes : Menu
{
    public static void Executar(Dictionary<string, Banda> bandas)
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
}
