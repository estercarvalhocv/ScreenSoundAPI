using ScreenSoundAPI.Modelos;
using System.Text.Json;
using ScreenSoundAPI.Filtros;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta);
        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        //LinqFilter.FiltrarMusicasDeUmArtista(musicas, "U2");

        var musicasPreferidas = new MusicasPreferidas("Ester");
        musicasPreferidas.AdicionarMusicasFavoritas(musicas[1]);
        musicasPreferidas.AdicionarMusicasFavoritas(musicas[2]);
        musicasPreferidas.AdicionarMusicasFavoritas(musicas[3]);
        musicasPreferidas.AdicionarMusicasFavoritas(musicas[4]);
        musicasPreferidas.AdicionarMusicasFavoritas(musicas[5]);

        musicasPreferidas.ExibirMusicasFavoritas();

        musicasPreferidas.GerarArquivoJson();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"temos um problema: {ex.Message}");
    }
}