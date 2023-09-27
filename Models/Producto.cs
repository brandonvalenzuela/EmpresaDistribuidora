namespace EmpresaDistribuidora.Models
{
    public class Producto
    {
        public Producto()
        {
            ProductosProveedores = new List<ProductoProveedor>();
        }

        public int ProductoId { get; set; }

        public string NombreProducto { get; set; }

        public string Clave { get; set; }

        public decimal Precio { get; set; }

        public int CategoriaId { get; set; }

        public bool EsActivo { get; set; }

        // Propiedad de navegación para la relación con Categoria
       // public Categoria Categoria { get; set; }

        // Colección de ProductosProveedores para la relación muchos a muchos
        public List<ProductoProveedor> ProductosProveedores { get; set; }
    }
}
