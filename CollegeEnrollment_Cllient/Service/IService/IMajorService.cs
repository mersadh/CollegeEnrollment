using CollegeEnrollment_Models;

namespace CollegeEnrollment_Cllient.Service.IService
{
    public interface IMajorService
    {
        public Task<IEnumerable<MajorDTO>> GetAll();
        public Task<MajorDTO> Get(int majorId);

    }
}
