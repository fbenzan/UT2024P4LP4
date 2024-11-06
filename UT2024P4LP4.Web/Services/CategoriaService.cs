using Microsoft.EntityFrameworkCore;
using UT2024P4LP4.Web.Data;
using UT2024P4LP4.Web.Data.Dtos;
using UT2024P4LP4.Web.Data.Entities;

namespace UT2024P4LP4.Web.Services;

public interface ICategoriaService
{
    Task<Result> Create(CategoriaRequest request);
    Task<Result> Delete(int Id);
    Task<ResultList<CategoriaDto>> GetAll(CancellationToken cancellationToken = default);
    Task<Result<CategoriaDto>> GetById(int Id);
    Task<Result> Update(CategoriaRequest request);
}

public class CategoriaService(IApplicationDbContext dbContext) : ICategoriaService
{
    public async Task<ResultList<CategoriaDto>> GetAll(CancellationToken cancellationToken = default)
    {
        var categorias = await dbContext.Categorias
        .Select(x => x.ToDto())
        .ToListAsync(cancellationToken);
        return ResultList<CategoriaDto>.Success(categorias);
    }
    public async Task<Result> Create(CategoriaRequest request)
    {
        try
        {
            var entity = Categoria.Create(request.Nombre);
            dbContext.Categorias.Add(entity);
            await dbContext.SaveChangesAsync();
            return Result.Success("✅Categoría registrada con exito!");
        }
        catch (Exception Ex)
        {
            return Result.Failure($"☠️ Error: {Ex.Message}");
        }
    }
    public async Task<Result> Update(CategoriaRequest request)
    {
        try
        {
            var entity = dbContext.Categorias.Where(p => p.Id == request.Id).FirstOrDefault();
            if (entity == null)
                return Result.Failure($"La categoría '{request.Id}' no existe!");
            if (entity.Update(request.Nombre))
            {
                await dbContext.SaveChangesAsync();
                return Result.Success("✅Categoría modificada con exito!");
            }
            return Result.Success("🐫 No has realizado ningun cambio!");
        }
        catch (Exception Ex)
        {
            return Result.Failure($"☠️ Error: {Ex.Message}");
        }
    }
    public async Task<Result> Delete(int Id)
    {
        try
        {
            var entity = dbContext.Categorias.Where(p => p.Id == Id).FirstOrDefault();
            if (entity == null)
                return Result.Failure($"La categoría '{Id}' no existe!");
            dbContext.Categorias.Remove(entity);
            await dbContext.SaveChangesAsync();
            return Result.Success("✅Categoría eliminada con exito!");
        }
        catch (Exception Ex)
        {
            return Result.Failure($"☠️ Error: {Ex.Message}");
        }
    }
    public async Task<Result<CategoriaDto>> GetById(int Id)
    {
        try
        {
            var entity = await dbContext.Categorias.Where(p => p.Id == Id)
                .Select(p => new CategoriaDto{ Id = p.Id, Nombre = p.Nombre })
                .FirstOrDefaultAsync();
            if (entity == null)
                return Result<CategoriaDto>.Failure($"El producto '{Id}' no existe!");

            return Result<CategoriaDto>.Success(entity);
        }
        catch (Exception Ex)
        {
            return Result<CategoriaDto>.Failure($"☠️ Error: {Ex.Message}");
        }
    }
}
