using Microsoft.EntityFrameworkCore;
using UT2024P4LP4.Web.Data.Entities;

namespace UT2024P4LP4.Web.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Producto> Productos { get; set; }
        DbSet<Categoria> Categorias { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}