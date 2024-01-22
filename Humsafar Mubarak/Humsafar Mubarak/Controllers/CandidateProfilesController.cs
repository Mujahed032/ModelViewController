using Microsoft.AspNetCore.Mvc;
using Humsafar_Mubarak.Data;
using Humsafar_Mubarak.Models;
using Humsafar_Mubarak.Interface;
using Humsafar_Mubarak.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Humsafar_Mubarak.Controllers
{
    public class CandidateProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IphotoServices _photoServices;

        public CandidateProfilesController(ApplicationDbContext context, IphotoServices photoServices)
        {
            _context = context;
            _photoServices = photoServices;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfileViewModel candidateProfile)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoServices.AddPhotoAsync(candidateProfile.Image);

                var personDetails = new PersonDetails
                {
                    FirstName = candidateProfile.Person.FirstName,
                    LastName = candidateProfile.Person.LastName,
                    Employment = candidateProfile.Person.Employment,
                    Relation= candidateProfile.Person.Relation
                };

                var profile = new CandidateProfile
                {
                    Age = candidateProfile.Age,
                    DateOfBirth = candidateProfile.DateOfBirth,
                    Gender = candidateProfile.Gender,
                    MaritalStatus = candidateProfile.MaritalStatus,
                    Description = candidateProfile.Description,
                    Diet = candidateProfile.Diet,
                    BodyType = candidateProfile.BodyType,
                    Height = candidateProfile.Height,
                    Weight = candidateProfile.Weight,
                    Complexion = candidateProfile.Complexion,
                    Religion = candidateProfile.Religion,
                    Personality = candidateProfile.Personality,
                    Person = personDetails,
                    Image = result.Url.ToString(),
                };
                 _context.Add(profile);
                return RedirectToAction("SalaryDetails", new { profileId = profile.Id });
            }
            else
            {
                ModelState.AddModelError("","failed to edit the photo");
            }
            return View(candidateProfile);
        }

        public IActionResult SalaryDetails(int profileId)
        {
            ViewBag.ProfileId = profileId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SalaryDetails(int profileId, SalaryDetails salaryDetails)
        {
            if (ModelState.IsValid)
            {
                var result = await _context.CandidateProfiles.Include(p => p.Person).FirstOrDefaultAsync(p => p.Id == profileId);

                if (result != null)
                {
                    result.Salary = new SalaryDetails
                    {
                        Currency = salaryDetails.Currency,
                        SalaryAmount = salaryDetails.SalaryAmount,
                        SalaryFrequency = salaryDetails.SalaryFrequency
                    };
                    _context.SaveChanges();


                    return RedirectToAction("Create");
                }
                else
                {
                    return View(salaryDetails);
                }
            }
            return View(salaryDetails);
        }
    }
}
