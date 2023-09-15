using AutoMapper;
using ComeBack.API.Context;
using ComeBack.API.DAO;
using ComeBack.API.Models;
using ComeBack.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ComeBack.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlServerContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDAO>> GetAllProducts()
        {
            var allProducts = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDAO>>(allProducts);
        }

        public async Task<ProductDAO> InsertProduct(ProductDAO productDAO)
        {
            var daoToObj = _mapper.Map<Product>(productDAO);
            await _context.Products.AddAsync(daoToObj);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDAO>(daoToObj);
        }
    }
}
