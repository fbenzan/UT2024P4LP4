using UT2024P4LP4.Web.Data.Dtos;
using UT2024P4LP4.Web.Data.Entities;

namespace UT2024P4LP4.Web.Services
{
    public interface IProductoService
    {
        Task<Result> Create(ProductoRequest producto);
        Task<Result> Delete(int Id);
        Task<ResultList<ProductoDto>> Get(string filtro = "");
        Task<Result<ProductoDto>> GetById(int Id);
        Task<Result> Update(ProductoRequest producto);
    }
}