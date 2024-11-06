namespace UT2024P4LP4.Web.Data.Dtos;

public class CategoriaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;

    public CategoriaRequest ToRequest() => new() { 
        Nombre = Nombre, 
        Id = Id };
}
