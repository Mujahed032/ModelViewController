using PhoneTestingApi.Models;

namespace PhoneTestingApi.Data
{
    public class InsertData
    {
        private readonly ApplicationDbContext _context;

        public InsertData(ApplicationDbContext context)
        {
            _context = context;
        }

        public void enterData()
        {
            var categoryAndroid = new Category { PhoneType = "Android" };
            var categoryIOS = new Category { PhoneType = "IOS" };
            var categoryWindows = new Category { PhoneType = "Windows" };

            var phoneSnmsungS20 = new Phone { Category= categoryAndroid, Name="SnmsungS20" };
            var phoneSnsungS10x = new Phone { Category = categoryAndroid, Name = "SnmsungS10x" };
            var phoneNokiaN95 = new Phone { Category = categoryWindows, Name = "NokiaN95" };
            var phoneIphone6 = new Phone { Category = categoryIOS, Name = "Iphone6" };

            _context.phones.Add(phoneSnmsungS20);
            _context.phones.Add(phoneSnsungS10x);
            _context.phones.Add(phoneNokiaN95);
            _context.phones.Add(phoneIphone6);

            _context.SaveChanges();
        }
    }
}
