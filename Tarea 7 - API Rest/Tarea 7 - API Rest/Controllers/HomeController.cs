
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

        string apiUrl = "https://localhost:7255/Medicamentos";

        List<Medicamento>? medicamentos = null;
        try
        {
            medicamentos = await httpClient.GetFromJsonAsync<List<Medicamento>>(apiUrl);
        }
        catch (HttpRequestException ex)
        {
            ViewData["ErrorMessage"] = $"Error al conectar con la API: {ex.Message}. ¿Está la API ejecutándose en {apiUrl}?";
        }
        return View(medicamentos ?? new List<Medicamento>());
    }
}