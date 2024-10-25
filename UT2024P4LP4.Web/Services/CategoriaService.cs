using Microsoft.EntityFrameworkCore;
using UT2024P4LP4.Web.Data;
using UT2024P4LP4.Web.Data.Dtos;

namespace UT2024P4LP4.Web.Services;

public interface ICategoriaService
{
    Task<ResultList<CategoriaDto>> GetAll(CancellationToken cancellationToken = default);
}

public class CategoriaService(IApplicationDbContext context) : ICategoriaService
{
    public async Task<ResultList<CategoriaDto>> GetAll(CancellationToken cancellationToken = default)
    {
        var categorias = await context.Categorias
        .Select(x => x.ToDto())
        .ToListAsync(cancellationToken);
        return ResultList<CategoriaDto>.Success(categorias);
    }
}
