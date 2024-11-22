using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace tl2_tp5_2024_claudioxx.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;
        ProductoRepository productoRepositorio = new ProductoRepository();
        private List<Producto> productos = new List<Producto>();

        public ProductoController(ILogger<ProductoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Producto")]
        public IActionResult crearProducto(Producto producto)
        {
            // Producto productoNuevo = new Producto(productos.Count,descripcion,precio);
            productoRepositorio.crearProducto(producto);

            return Ok(producto);
        }

        [HttpGet]
        [Route("Productos")]
        public IActionResult listarProductos(){
            List<Producto> productos = productoRepositorio.listarProductos();
            return Ok(productos);
        }

        [HttpPut]
        [Route("Producto/{id}")]
        public IActionResult modificarProducto (int id, Producto unProducto){
            productoRepositorio.modificarProducto(id,unProducto);
            return Ok(unProducto);
        }
    }
}