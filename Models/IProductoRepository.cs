interface IProductoRepository
{
    void crearProducto (Producto unProducto);
    void modificarProducto (int id, Producto unProducto);
    List<Producto> listarProductos ();
    Producto detallesProducto (int id);
    void eliminarProducto(int id);
}