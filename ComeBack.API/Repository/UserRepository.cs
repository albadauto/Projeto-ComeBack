using AutoMapper;
using ComeBack.API.Context;
using ComeBack.API.DAO;
using ComeBack.API.Models;
using ComeBack.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ComeBack.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private SqlServerContext _context;
        private IMapper _mapper;
        public UserRepository(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<List<UserDAO>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserDAO>>(users);
        }

        public async Task<UserDAO> InsertNewUser(UserDAO userDAO)
        {
            var user = _mapper.Map<User>(userDAO);
            user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDAO>(user); 
        }

        public async Task<LoginDAO> SearchUser(LoginDAO userDAO)
        {
            var user = _mapper.Map<User>(userDAO);
            var result = await _context.Users.FirstOrDefaultAsync(x => x.email == user.email);
            return _mapper.Map<LoginDAO>(result);
        }
    }
}
