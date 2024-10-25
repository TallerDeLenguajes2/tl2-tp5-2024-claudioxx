using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace tl2_tp5_2024_claudioxx.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        var sqlitecon = new SqliteConnection("Data Source=db/Tienda.db");
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Producto> Get()
    {
        var cadena = "Data Source=db/Tienda.db";
        List<Producto> prodcutos = new List<Producto>();
        using (var sqlitecon = new SqliteConnection(cadena))
        {
            sqlitecon.Open();
            var consulta = @"SELECT * FROM productos;";
            SqliteCommand command = new SqliteCommand(consulta,sqlitecon);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["idProducto"]);
                string nombre = reader["Descripcion"].ToString();
                int precio = Convert.ToInt32(reader["Precio"]);
                Producto unProducto = new Producto(id,nombre,precio);
                prodcutos.Add(unProducto);
            }
            sqlitecon.Close();
        }
        return prodcutos;
    }
}
