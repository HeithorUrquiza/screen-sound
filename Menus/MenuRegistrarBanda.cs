using ScreenSoundEdit.Modelos;

namespace ScreenSoundEdit.Menus;

internal class MenuRegistrarBanda : Menu
{
    public static void Executar(Dictionary<string, Banda> bandas)
    {
        Console.Clear();
        FormataTitulo("REGISTRO DE BANDAS");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        bandas.Add(nomeDaBanda, new Banda(nomeDaBanda));
        Thread.Sleep(2500);
        Console.Clear();
    }
}
