using Microsoft.EntityFrameworkCore;
using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Dal.Core.Context;
using Shbl.Spt.Model.Core.Dto;
using Shbl.Spt.Model.Core.Entity.Auth;

namespace Shbl.Spt.Business.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly SptContext _context;

        public UserService(SptContext context)
        {
            _context = context;
        }

        public async Task<SptUser> GetByUserNameAsync(string username)
        {
            return await _context.SptUsers.Include(u => u.Person).FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<SptUser> GetByUsernameAndPasswordAsync(string username, string password)
        {
            return await _context.SptUsers.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        public async Task AddUserAsync(SptUser user)
        {
            _context.SptUsers.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserByUsernameAsync(string username, string firstName, string lastName)
        {
            var userToUpdate = await _context.SptUsers.Include(u => u.Person)
                .FirstOrDefaultAsync(u => u.Username == username);

            if (userToUpdate is null) return;

            userToUpdate.Person.FirstName = firstName;
            userToUpdate.Person.LastName = lastName;

            await _context.SaveChangesAsync();
        }

        public async Task RegisterUserAsync(RegisterUserDto dto)
        {
            if (await _context.SptUsers.AnyAsync(t => t.Username == dto.Email))
                throw new Exception("Email address is not available!");

            var cfs =
                from c in _context.CfTypes.AsEnumerable()
                join p in _context.Persons.AsEnumerable().Where(t =>
                        t.AgeGroup == (Person.AgeGroupEnum)dto.AgeGroup &&
                        t.ProficiencyLevel == (Person.ProficiencyLevelEnum)dto.ProficiencyLevel) 
                    on c.Id equals p.CfType.Id
                    into ps
                from q in ps.DefaultIfEmpty()
                select new { cf = c, cnt = q?.CfType is null ? 0 : ps.Count(t => t.CfType.Id == c.Id) };

            var next = cfs.OrderBy(t => t.cnt).ThenBy(t => t.cf.Id).First().cf;

            var user = new SptUser
            {
                Username = dto.Email,
                Password = dto.Password,
                IsAdmin = false,
                Person = new Person
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Gender = dto.Gender,
                    AgeGroup = (Person.AgeGroupEnum)dto.AgeGroup,
                    ProficiencyLevel = (Person.ProficiencyLevelEnum)dto.ProficiencyLevel,
                    CfType = next
                }
            };

            _context.SptUsers.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}