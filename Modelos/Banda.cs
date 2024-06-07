namespace ScreenSoundEdit.Modelos;

internal class Banda
{
    private List<Album> albuns = [];
    private List<Avaliacao> notas = [];

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
            else return notas.Average(avaliacao => avaliacao.Nota);
        }        
    }

    public void AdicionarAlbum(Album album)
    {
        albuns.Add(album);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }

    private void ExibirDiscografia()
    {
        if (Albuns.Count == 0)
        {
            Console.WriteLine("\nSem álbuns registrados no momento");
        }
        else
        {
            Console.WriteLine($"\nDiscografia da banda {Nome}\n");
            Albuns.ForEach(albun => Console.WriteLine($"Álbum: {albun.Nome} {albun.DuracaoTotal / 60.0:F2}min"));
        }
    }

    private void ExibirMusicas()
    {
        if (Albuns.Count >= 0)
        {
            foreach (var album in Albuns)
            {
                Console.WriteLine("\n---------------------------------------------------------");
                album.ExibirMusicasDoAlbum();
            }
        }
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"\nA banda {Nome} tem uma média de aprovação de {Media:F2}");
        Console.WriteLine("\n---------------------------------------------------------");

        ExibirDiscografia();
        ExibirMusicas();
    }
}