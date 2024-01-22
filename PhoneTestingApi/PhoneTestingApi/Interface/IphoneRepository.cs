using PhoneTestingApi.Models;

namespace PhoneTestingApi.Interface
{
    public interface IphoneRepository
    {
        public ICollection<Phone> GetAll();

        public Phone GetPhoneByName(string Name);

        public Phone GetPhoneById(int PhoneId);

        public bool DoesPhoneExists(int PhoneId);

        public Category GetCategoryByPhone(int phoneId);

        public bool CreatePhone(Phone phone, int categoryId);

        public bool save();

        public bool UpdatePhone(Phone phone);

        public bool DeletePhone(Phone phone);

    }
}
