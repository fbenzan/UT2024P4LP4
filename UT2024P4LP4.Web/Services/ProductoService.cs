﻿namespace UT2024P4LP4.Web.Services;

using Microsoft.EntityFrameworkCore;
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
    public async Task<Result> Create(string nombre, string? descripcion)
    {
        try
        {
            var entity = Producto.Create(nombre, descripcion);
            dbContext.Productos.Add(entity);
            await dbContext.SaveChangesAsync();
            return Result.Success("✅Producto registrado con exito!");
        }
        catch (Exception Ex)
        {
            return Result.Failure($"☠️ Error: {Ex.Message}");
        }
    }
    public async Task<Result> Update(int Id, string nombre, string? descripcion)
    {
        try
        {
            var entity = dbContext.Productos.Where(p => p.Id == Id).FirstOrDefault();
            if (entity == null)
                return Result.Failure($"El producto '{Id}' no existe!");
            if (entity.Update(nombre, descripcion))
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
                .Select(p => new ProductoDto(p.Id, p.Nombre, p.Descripcion))
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
                .Select(p => new ProductoDto(p.Id, p.Nombre, p.Descripcion))
                .ToListAsync();
            return ResultList<ProductoDto>.Success(entities);
        }
        catch (Exception Ex)
        {
            return ResultList<ProductoDto>.Failure($"☠️ Error: {Ex.Message}");
        }
    }
}