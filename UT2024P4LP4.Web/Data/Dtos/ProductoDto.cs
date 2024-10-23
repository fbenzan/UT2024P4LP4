namespace UT2024P4LP4.Web.Data.Dtos;
public record ProductoDto(int Id, string Nombre, string? Descripcion, int? CategoriaId,string Categoria, decimal Precio)
{
    public string PrecioText => $"RD$ {Precio.ToString("N2")}";
    public ProductoRequest ToRequest()
    => new() { 
        Id = this.Id, 
        Nombre = this.Nombre,
        Descripcion = this.Descripcion,
        CategoriaId = this.CategoriaId,
        Precio = this.Precio
    };
};
public class ProductoRequest
{
    public int Id { get; set; } = 0;
    public string Nombre { get; set; } = "";
    public string? Descripcion { get; set; } = null;
    public int? CategoriaId { get; set; }
    public decimal Precio { get; set; }
}
