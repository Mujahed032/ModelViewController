using Microsoft.EntityFrameworkCore;
using PhoneTestingApi.Data;
using PhoneTestingApi.Interface;
using PhoneTestingApi.Models;

namespace PhoneTestingApi.Repository
{
    public class PhoneRepository : IphoneRepository
    {
        private readonly ApplicationDbContext _context;

        public PhoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreatePhone(Phone phone, int categoryId)
        {
            phone.Category = _context.categories.Where(c => c.Id == categoryId).FirstOrDefault();
            _context.Add(phone);
            return save();
        }

        public bool DeletePhone(Phone phone)
        {
            _context.Remove(phone);
            return save();
        }

        public bool DoesPhoneExists(int PhoneId)
        {
            return _context.phones.Any(p => p.Id == PhoneId);
        }

        public ICollection<Phone> GetAll()
        {
           return _context.phones.OrderBy(p => p.Id).ToList();
        }

        public Category GetCategoryByPhone(int phoneId)
        {
            var phones = _context.phones.Include(p => p.Category).Where(x => x.Id ==phoneId).FirstOrDefault();
            return phones.Category;
        }

        public Phone GetPhoneById(int PhoneId)
        {
            return _context.phones.Where(p => p.Id ==PhoneId).FirstOrDefault();
        }

        public Phone GetPhoneByName(string Name)
        {
            return _context.phones.Where(p => p.Name.Contains($"{Name}")).FirstOrDefault();
        }

        public bool save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool UpdatePhone(Phone phone)
        {
            _context.Update(phone);
            return save();
        }
    }
}
