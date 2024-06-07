namespace ScreenSoundEdit.Modelos;

class Banda
{
    private List<Album> albuns = [];
    private List<int> notas = [];

    public Banda(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }
    public List<Album> Albuns { get => albuns; }
    public double Media 
    {
        get
        {
            if (notas.Count == 0) return 0.0;
            else return notas.Average();
        }        
    }

    public void AdicionarAlbum(Album album)
    {
        albuns.Add(album);
    }

    public void AdicionarNota(int nota)
    {
        notas.Add(nota);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"\nDiscografia da banda {Nome}\n");
        albuns.ForEach(albun => Console.WriteLine($"Álbum: {albun.Nome} {albun.DuracaoTotal/60.0:F2}min"));
    }
}