using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UT2024P4LP4.Web.Data.Dtos;

namespace UT2024P4LP4.Web.Data.Entities;

[Table("Categorias")]
public class Categoria
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; } =null!;

    public virtual ICollection<Producto>? Productos { get; set; }

    public CategoriaDto ToDto() => new()
    {
        Id  = this.Id,
        Nombre = this.Nombre,
    };
}
