namespace UT2024P4LP4.Web.Services;

using Microsoft.EntityFrameworkCore;
using UT2024P4LP4.Web;
using UT2024P4LP4.Web.Data;
using UT2024P4LP4.Web.Data.Dtos;
using UT2024P4LP4.Web.Data.Entities;

public partial class ProductoService : IProductoService
{
    private readonly IApplicationDbContext dbContext;

    public ProductoService(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    //CRUD
    public async Task<Result> Create(ProductoRequest producto)
    {
        try
        {
            var entity = Producto.Create(producto.Nombre, producto.Descripcion, producto.CategoriaId, producto.Precio);
            dbContext.Productos.Add(entity);
            await dbContext.SaveChangesAsync();
            return Result.Success("✅Producto registrado con exito!");
        }
        catch (Exception Ex)
        {
            return Result.Failure($"☠️ Error: {Ex.Message}");
        }
    }
    public async Task<Result> Update(ProductoRequest producto)
    {
        try
        {
            var entity = dbContext.Productos.Where(p => p.Id == producto.Id).FirstOrDefault();
            if (entity == null)
                return Result.Failure($"El producto '{producto.Id}' no existe!");
            if (entity.Update(producto.Nombre, producto.Descripcion, producto.CategoriaId,producto.Precio))
            {
                await dbContext.SaveChangesAsync();
                return Result.Success("✅Producto modificado con exito!");
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
            var entity = dbContext.Productos.Where(p => p.Id == Id).FirstOrDefault();
            if (entity == null)
                return Result.Failure($"El producto '{Id}' no existe!");
            dbContext.Productos.Remove(entity);
            await dbContext.SaveChangesAsync();
            return Result.Success("✅Producto eliminado con exito!");
        }
        catch (Exception Ex)
        {
            return Result.Failure($"☠️ Error: {Ex.Message}");
        }
    }
    public async Task<Result<ProductoDto>> GetById(int Id)
    {
        try
        {
            var entity = await dbContext.Productos.Where(p => p.Id == Id)
                .Select(p => new ProductoDto(p.Id, p.Nombre, p.Descripcion, p.CategoriaId,p.Categoria!.Nombre??"No definida", p.Precio))
                .FirstOrDefaultAsync();
            if (entity == null)
                return Result<ProductoDto>.Failure($"El producto '{Id}' no existe!");

            return Result<ProductoDto>.Success(entity);
        }
        catch (Exception Ex)
        {
            return Result<ProductoDto>.Failure($"☠️ Error: {Ex.Message}");
        }
    }
    public async Task<ResultList<ProductoDto>> Get(string filtro = "")
    {
        try
        {
            var entities = await dbContext.Productos
                .Where(p => p.Nombre.ToLower().Contains(filtro.ToLower()))
                .Select(p => new ProductoDto(p.Id, p.Nombre, p.Descripcion, p.CategoriaId, p.Categoria!.Nombre ?? "No definida", p.Precio))
                .ToListAsync();
            return ResultList<ProductoDto>.Success(entities);
        }
        catch (Exception Ex)
        {
            return ResultList<ProductoDto>.Failure($"☠️ Error: {Ex.Message}");
        }
    }
}
