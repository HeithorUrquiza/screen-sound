namespace ScreenSoundEdit.Modelos;

internal class Avaliacao
{
    public Avaliacao(int nota)
    {
        if (nota < 0) Nota = 0;
        if (nota > 10) Nota = 10;
        Nota = nota;
    }

    public int Nota { get; }

    public static Avaliacao Parse(string notaInput)
    {
        var nota = int.Parse(notaInput);
        return new Avaliacao(nota);
    }
}
