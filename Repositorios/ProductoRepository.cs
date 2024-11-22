using Microsoft.Data.Sqlite;
class ProductoRepository : IProductoRepository
{
    public string cadena = "Data Source=db/Tienda.db";
    SqliteConnection sqlitecon;
    public ProductoRepository(){
        sqlitecon = new SqliteConnection(cadena);
    }

    public void crearProducto(Producto unProducto)
    {
        using (sqlitecon)
        {
            sqlitecon.Open();
            var consulta = @"INSERT INTO Productos (Descripcion, Precio) 
                            VALUES (@Descripcion, @Precio);";
            
            SqliteCommand command = new SqliteCommand(consulta,sqlitecon);
            command.Parameters.Add(new SqliteParameter ("@Descripcion", unProducto.Descripcion));
            command.Parameters.Add(new SqliteParameter ("@Precio", unProducto.precio));
            command.ExecuteReader();
            sqlitecon.Close();
        }
    }

    public Producto detallesProducto(int id)
    {
        throw new NotImplementedException();
    }

    public void eliminarProducto(int id)
    {
        throw new NotImplementedException();
    }

    public List<Producto> listarProductos()
    {
        List<Producto> productos = new List<Producto>();
        using (sqlitecon)
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
                productos.Add(unProducto);
            }
            sqlitecon.Close();
        }
        return productos;
    }

    public void modificarProducto(int id, Producto unProducto)
    {
        using(sqlitecon){
            sqlitecon.Open();
            var consulta = @"UPDATE Productos 
                            SET Descripcion = @Descripcion , Precio = @Precio 
                            WHERE idProducto = @idProducto;";
            
            SqliteCommand command = new SqliteCommand(consulta,sqlitecon);
            command.Parameters.Add(new SqliteParameter("@Descripcion",unProducto.descripcion));
            command.Parameters.Add(new SqliteParameter("@Precio",unProducto.precio));
            command.Parameters.Add(new SqliteParameter("@idProducto", id));
            command.ExecuteReader();
            sqlitecon.Close();
        }
    }
}