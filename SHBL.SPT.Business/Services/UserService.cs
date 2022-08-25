using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.DAL.Context;
using SHBL.SPT.Model.Auth;
using SHBL.SPT.Model.Dto;

namespace SHBL.SPT.Business.Services
{
    public class UserService : IUserService
    {
        private readonly SptContext _context;

        public UserService()
        {
            _context = new SptContext();
        }

        public async Task<SptUser> GetByUserNameAsync(string username)
        {
            return await _context.SptUsers.FirstOrDefaultAsync(u => u.Username == username);
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
                from c in _context.CFTypes
                join p in _context.Persons.Where(t =>
                        t.AgeGroup == (Person.AgeGroupEnum)dto.AgeGroup &&
                        t.ProficiencyLevel == (Person.ProficiencyLevelEnum)dto.ProficiencyLevel) on c.Id equals p.CFType
                        .Id
                    into ps
                from q in ps.DefaultIfEmpty()
                select new { cf = c, cnt = q.CFType != null ? ps.Count(t => t.CFType.Id == c.Id) : 0 };

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
                    CFType = next
                }
            };

            _context.SptUsers.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}