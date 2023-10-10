using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using EmpresaDistribuidora.Models;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmpresaDistribuidora.Services;

namespace EmpresaDistribuidora.Controllers
{
    public class ProductoController : Controller
    {
        private static List<Producto> productoList = new();

        private static List<SelectListItem> categoriasList = new();

        private static List<SelectListItem> proveedorList = new();

        private readonly ProductoService _productoService;

        private readonly Data.Connection _connection;

        public ProductoController(IOptions<Data.Connection> connection, ProductoService productoService)
        {
            _connection = connection.Value;
            _productoService = productoService;
        }

        [HttpGet]
        public IActionResult Inicio(string Clave, string Categoria)
        {
            productoList = new();

            using (SqlConnection connection = new(_connection.DefaultConnection))
            using (SqlCommand command = new("SELECT * FROM Producto", connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Producto producto = new()
                    {
                        ProductoId = Convert.ToInt32(reader["ProductoId"]),
                        NombreProducto = reader["NombreProducto"].ToString(),
                        Clave = reader["Clave"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        CategoriaId = Convert.ToInt32(reader["CategoriaId"]),
                        EsActivo = Convert.ToBoolean(reader["EsActivo"])
                    };
                    productoList.Add(producto);

                    if (!string.IsNullOrEmpty(Clave) && !string.IsNullOrEmpty(Categoria))
                    {
                        productoList = productoList.Where(p => p.Clave.StartsWith(Clave)).ToList();
                        productoList = productoList.Where(p => p.CategoriaId.ToString().Contains(Categoria)).ToList();
                    }
                    else if (string.IsNullOrEmpty(Clave) && !string.IsNullOrEmpty(Categoria))
                    {
                        productoList = productoList.Where(p => p.CategoriaId.ToString().Contains(Categoria)).ToList();

                    }
                }
            }

            categoriasList = _productoService.GetCategoriasFromDatabase();

            ViewData["Categorias"] = categoriasList;

            return View(productoList);
        }

        [HttpGet]
        public  IActionResult Registrar()
        {
            proveedorList = _productoService.GetProveedoresFromDatabase();

            categoriasList = _productoService.GetCategoriasFromDatabase();

            ViewData["Proveedor"] = proveedorList;
            ViewData["Categorias"] = categoriasList;

            return View();
        }

        [HttpPost]
        public JsonResult Registrar([FromBody] Producto body)
        {
            try
            {
                XElement producto = _productoService.CreateProductoXml(body);

                _productoService.InsertProductoXmlIntoDatabase(producto);

                return Json(new { respuesta = true });
            }
            catch (Exception ex)
            {
                return Json(new { error = "Error en el servidor: " + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Editar(int? productoId)
        { 
            if (productoId == null) return RedirectToAction("Inicio");

            Producto producto = productoList.Where(c => c.ProductoId == productoId).FirstOrDefault();


            return View(producto);
        }

        [HttpPost]
        public IActionResult Editar(Producto producto)
        {
            using (SqlConnection connection = new(_connection.DefaultConnection))
            using (SqlCommand command = new("[sp_Update_Producto]", connection))
            {
                command.Parameters.AddWithValue("ProductoId", producto.ProductoId);    
                command.Parameters.AddWithValue("NombreProducto", producto.NombreProducto);
                command.Parameters.AddWithValue("Clave", producto.Clave);
                command.Parameters.AddWithValue("Precio", producto.Precio);

                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.ExecuteNonQuery();
            };
            return RedirectToAction("Inicio");
        }

        [HttpGet]
        public IActionResult Eliminar(int? productoId)
        {
            if (productoId == null) return RedirectToAction("Inicio");

            Producto producto = productoList.Where(p => p.ProductoId == productoId).FirstOrDefault();

            return View(producto);
        }

        [HttpPost]
        public IActionResult Eliminar(string productoId)
        {
            using (SqlConnection connection = new(_connection.DefaultConnection))
            using (SqlCommand command = new("[sp_Delete_Producto]", connection))
            {
                command.Parameters.AddWithValue("ProductoId", productoId);

                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.ExecuteNonQuery();
            };
            return RedirectToAction("Inicio");

        }
    }
}
