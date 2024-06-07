namespace ScreenSoundEdit.Modelos;

internal class Album
{
    private List<Musica> musicas = [];

    public Album(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }
    public int DuracaoTotal 
    {
        get
        {
            if (musicas.Count == 0) return 0;
            else return musicas.Sum(musica => musica.Duracao);
        }
    }

    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"\nLista de músicas do álbum {Nome}:\n");
        musicas.ForEach(musica => Console.WriteLine($"Música: {musica.Nome} {musica.Duracao}sec"));
        Console.WriteLine($"\nPara ouvir este álbum inteiro você precisa de {DuracaoTotal/60.0:F2} min");
    }
}