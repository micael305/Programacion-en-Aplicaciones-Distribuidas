using Microsoft.AspNetCore.Mvc;
using Tarea_7___API_Rest.Models;

public class HomeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var httpClient = _httpClientFactory.CreateClient();

        // Hacemos la llamada a la API
        var resultado = await httpClient.GetFromJsonAsync<Resultado>("https://rickandmortyapi.com/api/character");

        return View(resultado?.results ?? new Personaje[0]);
    }
}