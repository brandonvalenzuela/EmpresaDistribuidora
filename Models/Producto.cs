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
        public Categoria Categoria { get; set; }
        public List<ProductoProveedor> ProductosProveedores { get; set; }
    }
}
