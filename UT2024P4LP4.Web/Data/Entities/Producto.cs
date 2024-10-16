using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UT2024P4LP4.Web.Data.Entities;
[Table("Productos")]
public class Producto
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }

    #region Metodos
    public static Producto Create(string nombre, string? descripcion = null)
        => new() { Nombre = nombre, Descripcion = descripcion};
    public bool Update(string nombre, string? descripcion = null)
    {
        var save = false;
        if(Nombre != nombre)
        {
            Nombre = nombre; save = true;
        }
        if(Descripcion != descripcion)
        {
            Descripcion = descripcion; save = true;
        }
        return save;
    }
    #endregion Metodos
}
