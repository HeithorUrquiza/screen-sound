using ScreenSoundEdit.Modelos;

namespace ScreenSoundEdit.Menus;

internal class MenuExibirBandas : Menu
{
    public static void Executar(Dictionary<string, Banda> bandas)
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
}
