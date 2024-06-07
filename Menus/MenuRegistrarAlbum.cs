using ScreenSoundEdit.Modelos;

namespace ScreenSoundEdit.Menus;

internal class MenuRegistrarAlbum : Menu
{
    public static void Executar(Dictionary<string, Banda> bandas)
    {
        Console.Clear();
        FormataTitulo("REGISTRO DE ÁLBUM");
        Console.Write("Digite o nome da banda para registro do novo álbum: ");
        var bandaEscolhida = Console.ReadLine()!;

        if (bandas.ContainsKey(bandaEscolhida))
        {
            Console.Write("Informe o nome do novo ábum: ");
            var novoAlbum = new Album(Console.ReadLine()!);

            Console.Write("Informe a quantidade de músicas: ");
            var qtdMusicas = int.Parse(Console.ReadLine()!);
            Console.WriteLine();

            for (int i = 0; i < qtdMusicas; i++)
            {
                Console.Write("Digite as informações da música no seguinte formato 'Nome - Duracao': ");
                var infoMusica = Console.ReadLine()!.Split("-");
                novoAlbum.AdicionarMusica(new Musica(infoMusica[0].Trim(), bandas[bandaEscolhida], int.Parse(infoMusica[1].Trim())));
            }

            bandas[bandaEscolhida].AdicionarAlbum(novoAlbum);

            Console.WriteLine("\nÁlbum adicionado com sucesso");
            Thread.Sleep(2500);
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
