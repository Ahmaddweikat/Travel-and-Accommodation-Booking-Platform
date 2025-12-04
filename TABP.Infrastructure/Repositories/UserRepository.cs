using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TABP.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TABPDbContext context) : base(context)
        {
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            return _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
