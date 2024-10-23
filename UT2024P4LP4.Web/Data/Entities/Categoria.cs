using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UT2024P4LP4.Web.Data.Entities;

[Table("Categorias")]
public class Categoria
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; } =null!;

    public virtual ICollection<Producto>? Productos { get; set; }
}
