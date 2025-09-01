using AlquilerPeliculas;


//Crear video club
VideoClub videoClub = new VideoClub();

//Crear socios
Socio socio1 = new Socio("Carlos Fuentes", 42524922, 201);
Socio socio2 = new Socio("Laura Pausini", 42524923, 202);

//Crear Peliculas
Pelicula pelicula1 = new Pelicula(1, "Inception", "Ciencia Ficción");
Pelicula pelicula2 = new Pelicula(2, "The Godfather", "Drama");
Pelicula pelicula3 = new Pelicula(3, "Pulp Fiction", "Crimen");

//Crear Alquileres
Alquiler alq1 = new Alquiler(socio1, pelicula1);

Alquiler alq2 = new Alquiler(socio2, pelicula3);
alq2.FechaDevolucion = DateTime.Now.AddDays(5); //La devolvio 5 dias despues

Alquiler alq3 = new Alquiler(socio1, pelicula2);

//agregar socios al video club
videoClub.Socios.Add(socio1);
videoClub.Socios.Add(socio2);

//agregar peliculas al video club
videoClub.Peliculas.Add(pelicula1);
videoClub.Peliculas.Add(pelicula2);
videoClub.Peliculas.Add(pelicula3);

//Agregar alquileres al video club
videoClub.Alquileres.Add(alq1);
videoClub.Alquileres.Add(alq2);
videoClub.Alquileres.Add(alq3);

#region pruebas 
// Polimorfismo
Console.WriteLine("--- Polimorfismo: Mostrar estado de los alquileres --");
Console.WriteLine(alq1); // pendiente
Console.WriteLine(alq2); // Ya fue devuelto
Console.WriteLine(alq3); // pendiente
Console.WriteLine("------------------------------------------------------\n");

// Consultas Linq
videoClub.MostrarAlquileresPendientes();
Console.WriteLine("-------------------------------------------\n");

// Encapsulamiento: Ingresar DNI negativo
Console.WriteLine("--- Encapsulamiento: Ingresar DNI negativo ---");
try
{
    videoClub.Socios[0].DNI = -123;
}
catch (ArgumentException e)
{
    Console.WriteLine($"Error controlado: {e.Message}");
}
Console.WriteLine("-------------------------------------------------");
#endregion
