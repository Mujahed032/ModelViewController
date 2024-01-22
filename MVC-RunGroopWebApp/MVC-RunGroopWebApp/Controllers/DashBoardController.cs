using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using MVC_RunGroopWebApp.Interfaces;
using MVC_RunGroopWebApp.Models;
using MVC_RunGroopWebApp.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MVC_RunGroopWebApp.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IDashBoardRespository _dashBoardRespository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;

        public DashBoardController(IDashBoardRespository dashBoardRespository, IHttpContextAccessor httpContextAccessor, IPhotoService photoService)
        {
            _dashBoardRespository = dashBoardRespository;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
        }

        private void MapUserEdit(AppUser user,EditUserDashBoardViewModel editVm, ImageUploadResult photoResult)
        {
            user.Id = editVm.Id;
            user.Pace = editVm.Pace;
            user.Mileage = editVm.Mileage;
            user.ProfileImageUrl = photoResult.Url.ToString();
            user.State = editVm.State;
            user.City = editVm.City;
        }
        public async Task<IActionResult> Index()
        {
            var userClub = await _dashBoardRespository.GetAllUserClubs();
            var userRace = await _dashBoardRespository.GetAllUserRaces();
            var user = new DashBoardViewModel()
            {
                Races = userRace,
                Clubs = userClub
            };
            return View(user);
        }

        public async Task<IActionResult> EditUserProfile()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            var user = await _dashBoardRespository.GetUserById(userId);
            if (user == null) return View("error");
            var editViewModel = new EditUserDashBoardViewModel()
            {
                Id = userId,
                Pace = user.Pace,
                Mileage = user.Mileage,
                ProfileImageUrl = user.ProfileImageUrl,
                City = user.City,
                State = user.State
            };
            return View(editViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserprofile(EditUserDashBoardViewModel editVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","failed to edit the User profile");
                return View("EditUserprofile", editVM);
            }
            AppUser user = await _dashBoardRespository.GetByIdNoTracking(editVM.Id);

            if(user.ProfileImageUrl == "" || user.ProfileImageUrl == null)
            {
                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                MapUserEdit(user, editVM, photoResult);
                _dashBoardRespository.Update(user);

                return RedirectToAction("Index");
            }
            else
            {
                try
                {
                   await _photoService.DeletePhotoAsync(user.ProfileImageUrl);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("","Could not delete the photo");
                    return View(editVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                MapUserEdit(user, editVM, photoResult);
                _dashBoardRespository.Update(user);
                return RedirectToAction("Index");
            }
        }

        
    }
}
