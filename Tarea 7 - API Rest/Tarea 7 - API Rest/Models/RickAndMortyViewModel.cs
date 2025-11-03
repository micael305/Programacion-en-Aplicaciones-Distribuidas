namespace Tarea_7___API_Rest.Models;
public class Resultado
{
    public Personaje[]? results { get; set; }
}

public class Personaje
{
    public int id { get; set; }
    public string name { get; set; }
    public string image { get; set; }
}