namespace EmpresaDistribuidora.Models
{
    public class ProductoProveedor
    {
        public int ProductoProveedorId { get; set; }
        public int ProductoId { get; set; }
        public int ProveedorId { get; set; }
        public string ClaveProveedor { get; set; }
        public decimal PrecioProveedor { get; set; }

        // Propiedades de navegación
        public Producto Producto { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
