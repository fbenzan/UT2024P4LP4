using UT2024P4LP4.Web.Data;
using UT2024P4LP4.Web.Data.Dtos;

namespace UT2024P4LP4.Web.Services
{
    public interface IProductoService
    {
        Task<Result> Create(string nombre, string? descripcion);
        Task<Result> Delete(int Id);
        Task<ResultList<ProductoDto>> Get(string filtro = "");
        Task<Result<ProductoDto>> GetById(int Id);
        Task<Result> Update(int Id, string nombre, string? descripcion);
    }
}