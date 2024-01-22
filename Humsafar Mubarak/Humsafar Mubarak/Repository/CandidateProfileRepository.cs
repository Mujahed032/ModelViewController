using Humsafar_Mubarak.Data;
using Humsafar_Mubarak.Interface;
using Humsafar_Mubarak.Models;
using Microsoft.EntityFrameworkCore;

namespace Humsafar_Mubarak.Repository
{
    public class CandidateProfileRepository : ICandidateProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidateProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(CandidateProfile candidateProfile)
        {
            _context.Add(candidateProfile);
            return Save();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CandidateProfile>> GetAllCandidateProfiles()
        {
            throw new NotImplementedException();
        }

        public Task<CandidateProfile> GetCandidateProfileById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CandidateProfile> GetCandidateProfileByIdAsNoTracking(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var Saved = _context.SaveChanges();
            return Saved > 0 ? true : false;
        }

        public bool Update(CandidateProfile candidateProfile)
        {
            throw new NotImplementedException();
        }
    }
}
