using ScreenSoundEdit.Modelos;

namespace ScreenSoundEdit.Menus;

internal class MenuAvaliarBanda : Menu
{
    public static void Executar(Dictionary<string, Banda> bandas)
    {
        Console.Clear();
        FormataTitulo("AVALIAÇÃO DE BANDA");
        Console.Write("Informe o nome da banda que deseja avaliar: ");
        string bandaEscolhida = Console.ReadLine()!;

        if (bandas.ContainsKey(bandaEscolhida))
        {
            Console.Write("Digite o valor da nota: ");

            var nota = Avaliacao.Parse(Console.ReadLine()!);
            bandas[bandaEscolhida].AdicionarNota(nota);

            Console.WriteLine("\nRegistrando nota. Aguarde...");
            Thread.Sleep(2200);
            Console.WriteLine($"Nota registrada com sucesso para a banda {bandaEscolhida}");
            Thread.Sleep(2000);
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
