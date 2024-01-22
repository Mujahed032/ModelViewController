using Humsafar_Mubarak.Models;

namespace Humsafar_Mubarak.Interface
{
    public interface ICandidateProfileRepository
    {

        Task<IEnumerable<CandidateProfile>> GetAllCandidateProfiles();
        Task<CandidateProfile> GetCandidateProfileById(int id);

        Task<CandidateProfile> GetCandidateProfileByIdAsNoTracking(int id);

        bool Add(CandidateProfile candidateProfile);

        bool Update(CandidateProfile candidateProfile);

        bool Delete(int id);

        bool Save();

    }
}
