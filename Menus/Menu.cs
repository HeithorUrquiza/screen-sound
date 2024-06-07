namespace ScreenSoundEdit.Menus;

internal class Menu
{
    public static void FormataTitulo(string titulo)
    {
        int tamanhoTitulo = titulo.Length;
        string margem = string.Empty.PadLeft(tamanhoTitulo + 4, '-');

        Console.WriteLine(margem);
        Console.WriteLine($"  {titulo}");
        Console.WriteLine(margem + "\n");
    }
}
