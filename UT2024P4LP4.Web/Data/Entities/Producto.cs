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
    public int? CategoriaId { get; set; }
    [Column(TypeName = "decimal(18,6)")]
    public decimal Precio { get; set; } = 0;

    #region Metodos
    public static Producto Create(string nombre, string? descripcion = null, int? categoriaId = null, decimal precio = 0)
        => new() 
        { 
            Nombre = nombre, 
            Descripcion = descripcion, 
            CategoriaId = categoriaId, 
            Precio = precio
        };
    public bool Update(string nombre, string? descripcion = null, int? categoriaId = null, decimal precio = 0)
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
        if(CategoriaId != categoriaId)
        {
            CategoriaId = categoriaId; save = true;
        }
        if(Precio != precio)
        {
            Precio = precio; save = true;
        }
        return save;
    }
    #endregion Metodos
    #region Relaciones
    [ForeignKey(nameof(CategoriaId))]
    public virtual Categoria? Categoria { get; set; }
    
    #endregion
}
