using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using EmpresaDistribuidora.Models;

namespace EmpresaDistribuidora.Controllers
{
    public class ProductoController : Controller
    {

        
        private readonly string connectionString;

        private static List<Producto> productoList = new();

        public ProductoController()
        {
            // Obtener la cadena de conexión desde appsettings.json
            var coonfigurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = coonfigurationBuilder.Build();
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        

        [HttpGet]
        public IActionResult Inicio(string Clave)
        {
            productoList = new();

            using (SqlConnection connection = new(connectionString))
            using (SqlCommand command = new("SELECT * FROM Producto", connection)) {
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

                    if (!string.IsNullOrEmpty(Clave))
                    {
                        productoList = productoList.Where(p => p.Clave.StartsWith(Clave)).ToList();
                    }

                }
            }
            return View(productoList);
        }


        [HttpGet]
        public  IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Producto producto)
        {
            using (SqlConnection connection = new(connectionString))
            using (SqlCommand command = new("[sp_Insert_Producto]", connection))
            {

                command.Parameters.AddWithValue("NombreProducto", producto.NombreProducto);
                command.Parameters.AddWithValue("Clave", producto.Clave);
                command.Parameters.AddWithValue("Precio", producto.Precio);
                command.Parameters.AddWithValue("CategoriaId", producto.CategoriaId);
                command.Parameters.AddWithValue("EsActivo", producto.EsActivo);

                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                command.ExecuteNonQuery();
            };
            return RedirectToAction("Inicio");

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
            using (SqlConnection connection = new(connectionString))
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
            using (SqlConnection connection = new(connectionString))
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
