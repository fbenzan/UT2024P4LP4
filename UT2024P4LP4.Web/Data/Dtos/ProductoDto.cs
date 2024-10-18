namespace UT2024P4LP4.Web.Data.Dtos;
public record ProductoDto(int Id, string Nombre, string? Descripcion)
{
    public ProductoRequest ToRequest()
    => new() { Id = this.Id, Nombre = this.Nombre,Descripcion = this.Descripcion };
};
public class ProductoRequest
{
    public int Id { get; set; } = 0;
    public string Nombre { get; set; } = "";
    public string? Descripcion { get; set; } = null;
}
