﻿using EmpresaDistribuidora.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using Microsoft.Extensions.Options;

namespace EmpresaDistribuidora.Services
{
    public class ProductoService
    {
        private readonly Data.Connection _connection;

        public ProductoService(IOptions<Data.Connection> connection)
        {
            _connection = connection.Value;
        }

        public List<SelectListItem> GetCategoriasFromDatabase()
        {
            using (SqlConnection connection = new(_connection.DefaultConnection))
            using (SqlCommand command = new("[sp_Read_Categorias]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                List<SelectListItem> categoriasList = new();
                while (reader.Read())
                {
                    categoriasList.Add(new SelectListItem
                    {
                        Value = reader["CategoriaId"].ToString(),
                        Text = reader["NombreCategoria"].ToString()
                    });
                }

                return categoriasList;
            }
        }

        public List<SelectListItem> GetProveedoresFromDatabase()
        {
            using (SqlConnection connection = new(_connection.DefaultConnection))
            using (SqlCommand command = new("[sp_Read_Proveedor]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                List<SelectListItem> proveedorList = new();
                while (reader.Read())
                {
                    proveedorList.Add(new SelectListItem
                    {
                        Value = reader["ProveedorId"].ToString(),
                        Text = reader["NombreProveedor"].ToString()
                    });
                }

                return proveedorList;
            }
        }   

        public XElement CreateProductoXml(Producto body)
        {
            XElement producto = new("Producto",
                   new XElement("NombreProducto", body.NombreProducto),
                   new XElement("Clave", body.Clave),
                   new XElement("CategoriaId", body.CategoriaId),
                   new XElement("Precio", body.Precio),
                   new XElement("EsActivo", body.EsActivo)
            );

            XElement productoProveedor = new("ProductoProveedor");
            foreach (ProductoProveedor item in body.ProductosProveedores)
            {
                productoProveedor.Add(new XElement("Item",
                    new XElement("ProveedorId", item.ProveedorId),
                    new XElement("ClaveProveedor", item.ClaveProveedor),
                    new XElement("PrecioProveedor", item.PrecioProveedor)
                ));
            }

            producto.Add(productoProveedor);

            return producto;
        }

        public void InsertProductoXmlIntoDatabase(XElement producto)
        {
            using (SqlConnection connection = new(_connection.DefaultConnection))
            {
                connection.Open();
                SqlCommand command = new("[sp_Insert_ProductoProveedor]", connection);
                command.Parameters.Add("Producto_xml", SqlDbType.Xml).Value = producto.ToString();
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

    }
}