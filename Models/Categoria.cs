using Microsoft.AspNetCore.Mvc;
using NuGet.ProjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;

namespace EmpresaDistribuidora.Models
{
    public class Categoria
    {

        public int CategoriaId { get; set; }

        public string? NombreCategoria { get; set; }

        public string? Descripcion { get; set; }

    }
}
