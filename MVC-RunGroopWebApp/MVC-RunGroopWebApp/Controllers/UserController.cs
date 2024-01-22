using Microsoft.AspNetCore.Mvc;
using MVC_RunGroopWebApp.Interfaces;
using MVC_RunGroopWebApp.ViewModels;

namespace MVC_RunGroopWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("Users")]
        public async Task<IActionResult> Index()
        {
            var user = await _userRepository.GetAppUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var item in result)
            {
                var userViewModel = new UserViewModel()
                { 
                    Id = item.Id,
                    UserName = item.UserName,
                    Pace = item.Pace,
                    Mileage = item.Mileage,
                    ProfileImageUrl = item.ProfileImageUrl,
                   
                };
                result.Add(userViewModel);
            }
            return View(result);
        }

        public async Task<IActionResult> Detail(string Id)
        {
            var user = await _userRepository.GetUserById(Id);
            if (user == null)
            {
                var result = new UserDetailViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Pace = user.Pace,
                    Mileage = user.Mileage
                };
            }
            return View(user);
        }
        
    }
}
