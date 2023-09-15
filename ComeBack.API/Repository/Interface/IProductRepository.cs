using ComeBack.API.DAO;

namespace ComeBack.API.Repository.Interface
{
    public interface IProductRepository
    {
        Task<ProductDAO> InsertProduct(ProductDAO productDAO);
        Task<List<ProductDAO>> GetAllProducts();
    }
}
